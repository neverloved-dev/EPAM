using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public abstract class Document:IDocument
    {
        protected string DocumentNumber { get; }
        protected DocumentType Type { get; }
        protected TimeSpan CacheTime { get; }

        string IDocument.DocumentNumber => DocumentNumber;

        protected Document(string number,DocumentType type,TimeSpan cacheTime) 
        {
            DocumentNumber = number;
            Type = type;
            CacheTime = cacheTime;
        }
        
       
    }
}
