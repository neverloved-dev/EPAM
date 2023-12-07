using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class LocalizedBook : Document
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public List<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public string OriginalPublisher {  get; set; }
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }

        public LocalizedBook(string ISBN):base(ISBN,DocumentType.LOCALIZED_BOOK,TimeSpan.FromDays(2)) { }

        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        public LocalizedBook Search(string T)
        {
            throw new NotImplementedException();
        }
    }
}
