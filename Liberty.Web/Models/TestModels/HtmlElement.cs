using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberty.Web.Models.TestModels
{
    public class HtmlElementModel
    {
        public HtmlElementModel()
        {
            this.AvailableItems = new List<SelectListItem>();
        }

        public List<int> SelectedItems { get; set; }
        public IList<SelectListItem> AvailableItems { get; set; }
    }
}