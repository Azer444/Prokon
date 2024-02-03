﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ProjectPageViewModel
    {
        public PageMainPhoto PageMainPhoto { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

        public ContentAccessComponent ContentAccessComponent { get; set; }
    }
}
