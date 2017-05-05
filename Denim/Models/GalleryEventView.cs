using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denim.Models
{
    public class GalleryEventView
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
    }
}