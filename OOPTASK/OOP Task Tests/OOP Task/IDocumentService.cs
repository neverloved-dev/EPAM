using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public interface IDocumentService
    {
        List<IDocument> SearchByDocumentNumber(string documentNumber);
        public void CacheDocument(IDocument document, string documentNumber, TimeSpan cacheDuration);
        IDocument GetCachedDocument(string documentNumber);
        void RemoveCachedDocument(string documentNumber);
    }
}
