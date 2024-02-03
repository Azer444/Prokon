using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class UploadSuccess
    {
        public int Uploaded { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
