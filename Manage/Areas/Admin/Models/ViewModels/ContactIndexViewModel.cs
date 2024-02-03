using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class ContactIndexViewModel
    {
        public PageMainPhoto PageMainPhoto { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }

        public List<ContactComponent> ContactComponents { get; set; }
    }
}
