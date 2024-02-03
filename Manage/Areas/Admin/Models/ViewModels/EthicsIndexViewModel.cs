using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.ViewModels
{
    public class EthicsIndexViewModel
    {
        public PageMainPhoto MainPhoto { get; set; }

        public List<EthicsComponent> Components { get; set; }

        public List<EthicsFileComponent> FileComponents { get; set; }

        public PageAccessComponent PageAccessComponent { get; set; }
    }
}
