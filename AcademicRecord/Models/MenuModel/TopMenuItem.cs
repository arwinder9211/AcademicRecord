using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicRecord.Models.MenuModel
{
    /// <summary>
    /// MenuModel class for top navigation links
    /// </summary>
    public class TopMenuItem
    {
        public string AspArea { get; set; }
        public string AspController { get; set; }
        public string AspAction { get; set; }
        public string DisplayText { get; set; }
    }
}