using System;
using System.Collections.Generic;

namespace OOP_Task
{
    public class Patent : IDocument
    {
        public int Id {  get; set; }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Publisher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DatePublished { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ExpirationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> Authors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
