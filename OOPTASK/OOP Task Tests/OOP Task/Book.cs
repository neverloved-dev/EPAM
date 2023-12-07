using System;
using System.Collections.Generic;

namespace OOP_Task
{
    public class Book : Document
    {
        public string ISBN {  get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages {  get; set; }
        public List<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }

        public Book(string iSBN) : base(iSBN, DocumentType.BOOK, TimeSpan.FromDays(1)) { }


        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        public Book Search(string Title)
        {
            throw new NotImplementedException();
        }
    }
}
