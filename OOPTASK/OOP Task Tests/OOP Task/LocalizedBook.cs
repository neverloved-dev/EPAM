using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class LocalizedBook : Book
    {
        public string OriginalPublisher {  get; set; }
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }
    }
}
