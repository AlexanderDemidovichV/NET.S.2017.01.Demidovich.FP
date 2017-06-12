using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Services;

namespace MvcPL.Models.View
{
    public class KnowledgesViewModel
    {
        public List<FieldViewModel> fields { get; set; }

        public KnowledgesViewModel()
        {
            fields = new List<FieldViewModel>();
        }
    }
}