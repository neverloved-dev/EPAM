using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public abstract class Document : IDocument
    {
        protected string Number { get; }
        protected DocumentType Type { get; }
        protected TimeSpan CacheTime { get; }

        protected Document(string number,DocumentType type,TimeSpan cacheTime) 
        {
            Number = number;
            Type = type;
            CacheTime = cacheTime;
        }
        
        public void SaveInfo()
        {
            throw new NotImplementedException();
        }
        public void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
