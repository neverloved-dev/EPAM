using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class Magazine : Document
    {
        public string Number { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ReleaseNumber { get; set; }
        public DateTime DatePublished { get; set; }

        public Magazine(string number):base(number,DocumentType.MAGAZINE,TimeSpan.FromDays(1)) { }

        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        public Magazine Search(string T)
        {
            throw new NotImplementedException();
        }
    }
}
