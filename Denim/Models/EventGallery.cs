using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Denim.Models
{
    public class EventGallery
    {
        public List<Gallery> files { get; set; }
        public List<Event> eventList { get; set; }
        public IEnumerable<News> NewsList { get;set; }
        
    }
}