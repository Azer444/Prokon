﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ServicesIndexViewModel
    {
        public PageMainPhoto PageMainPhoto { get; set; }

        public List<ServicesComponent> ServicesComponents { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
