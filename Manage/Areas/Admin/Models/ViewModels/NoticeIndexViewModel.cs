using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class NoticeIndexViewModel
    {
        public PageMainPhoto NoticeMainPhoto { get; set; }

        public NoticeComponent NoticeComponent { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
