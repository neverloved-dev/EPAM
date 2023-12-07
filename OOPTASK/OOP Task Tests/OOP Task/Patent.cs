using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OOP_Task
{
    public class Patent : Document
    {
        public string Id {  get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime DatePublished { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<string> Authors { get; set; }

        public Patent(string id) : base(id,DocumentType.PATENT,TimeSpan.FromDays(1)) { }
        

        public Patent Search(string T)
        {
            throw new NotImplementedException();
        }

        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }
    }
}
