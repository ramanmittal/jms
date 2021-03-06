﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMS.ViewModels.Submissions
{
    public class EditorSubmissionViewModel
    {
        public long SubmissionId { get; set; }
        public string Prefix { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Abstract { get; set; }
        public string Keywords { get; set; }
        public string Comments { get; set; }
        public List<SubmissionFileListModel> Files { get; set; }
        [Display(Name ="Status")]
        public string SubmissionStatus { get; set; }
        [Display(Name = "Editor")]
        public long? EditorId { get; set; }
        public IDictionary<long,string> Editors { get; set; }
    }

    
}
