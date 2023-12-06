using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public interface IDocument
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
