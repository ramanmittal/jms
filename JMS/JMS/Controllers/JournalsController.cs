﻿using JMS.Service.Enums;
using JMS.Service.ServiceContracts;
using JMS.Setting;
using JMS.ViewModels.Journals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using static JMS.Models.Journals.EditJournalModel;
using JMS.Models.EmailModels;
using System.Collections.Generic;
using System.Net.Mail;
using JMS.Service.Settings;
using ElmahCore;

namespace JMS.Controllers
{
    [Authorize(Roles = RoleName.SystemAdmin)]
    public class JournalsController : BaseController
    {
        private readonly ITenantService _tenantService;
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        public JournalsController(ITenantService tenantService, IFileService fileService, IUserService userService)
        {
            _tenantService = tenantService;
            _fileService = fileService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new JMS.Models.Journals.CreateJournalModel();
            model.IsActive = true;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Journals.CreateJournalModel model)
        {
            if (ModelState.IsValid)
            {
                await _tenantService.CreateTenant(new ViewModels.Journals.CreateJournalModel
                {
                    IsActive = model.IsActive,
                    JournalName = model.JournalName,
                    JournalPath = model.JournalPath,
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    JournalTitle = model.JournalTitle
                }, model.Logo.OpenReadStream(), model.Logo.FileName);
                var emailModel = new AddUserEmailNotificationModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    JournalName = model.JournalName,
                    JournalPath = model.JournalPath,
                    RoleNames = new List<string> { RoleName.Admin }
                };
                try
                {
                    await SendAdminEmail(emailModel,model.Email);
                }
                catch (System.Exception ex)
                {
                    HttpContext.RiseError(ex);
                    AddFailMessage("Journal has been Created  but failed to send confirmation email to Admin.");
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(long id)
        {
            var journal = _tenantService.GetTenant(id);
            var users = _userService.GetTenantUserByRole(id, Role.JournalAdmin.ToString());
            var journalModel = new Models.Journals.EditJournalModel
            {
                JournalId = id,
                IsActive = !journal.IsDisabled.GetValueOrDefault(),
                JournalName = journal.JournalName,
                JournalTitle = journal.JournalTitle,
                LogoPath = _fileService.GetFile(journal.JournalLogo),
                JounralAdmins = users.Select(x => new JournalAdminModel
                {
                    Active = !x.IsDisabled.GetValueOrDefault(),
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserId = x.Id,
                    PhoneNumber = x.PhoneNumber,
                }).ToList(),
            };

            return View(journalModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Journals.EditJournalModel model)
        {
            if (ModelState.IsValid)
            {
                _tenantService.EditTenant(new ViewModels.Journals.EditJournalModel
                {
                    JournalId = model.JournalId,
                    IsActive = model.IsActive,
                    JournalName = model.JournalName,
                    JournalTitle = model.JournalTitle
                }, model.Logo?.OpenReadStream(), model.Logo?.FileName);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            _tenantService.DeleteTenant(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetAdmin(long userId)
        {
            var user = _userService.GetUser(userId);
            var model = new JournalAdminModel
            {
                Active = !user.IsDisabled.GetValueOrDefault(),
                Email = user.Email,
                FirstName = user.FirstName,
                UserId = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAdmin(JournalAdminModel model)
        {
            if (ModelState.IsValid)
            {
                _tenantService.SaveTenantAdmin(new EditJournalAdminModel
                {
                    Active = model.Active,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UserId = model.UserId
                });
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        public IActionResult CreateAdmin(long tenantId)
        {
            return PartialView(new Models.Journals.CreateJournalAdminModel { TenantId = tenantId, Active = true });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(Models.Journals.CreateJournalAdminModel model)
        {
            if (ModelState.IsValid)
            {
                await _tenantService.CreateTenantAdmin(new ViewModels.Journals.CreateJournalAdminModel
                {
                    Active = model.Active,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    TenantId=model.TenantId
                });
                var journal = _tenantService.GetTenant(model.TenantId);
                var emailModel = new AddUserEmailNotificationModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    JournalName = journal.JournalName,
                    JournalPath = journal.JournalPath,
                    RoleNames = new List<string> { RoleName.Admin }
                };
                try
                {
                    await SendAdminEmail(emailModel, model.Email);
                }
                catch (System.Exception ex)
                {
                    HttpContext.RiseError(ex);
                    AddFailMessage("Journal has been Created  but failed to send confirmation email to Admin.");
                }
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJournalAdmin(long id)
        {
            await _tenantService.DeleteTenantAdmin(id);
            return Json(new { Success = true });
        }

        private async Task SendAdminEmail(AddUserEmailNotificationModel emailModel,string email)
        {
            var emailBody = await GetService<IRazorViewToStringRenderer>().RenderViewToStringAsync(@"/Views/EmailTemplates/AddUserNotification.cshtml", emailModel);
            var mailMessage = new MailMessage(_configuration[JMSSetting.SenderEmail], email, _configuration[JMSSetting.AccountConfirmationEmailSubject], emailBody) { IsBodyHtml = true };
            GetService<IEmailSender>().SendEmail(mailMessage);
        }
    }
}