using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_iframe.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Phones { get; set; }
    }
}