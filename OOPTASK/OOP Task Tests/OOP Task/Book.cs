using System;
using System.Collections.Generic;

namespace OOP_Task
{
    public class Book : IDocument
    {
        public string ISBN {  get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages {  get; set; }
        public List<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
