using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OOP_Task
{
    public class DocumentService : IDocumentService
    {

        private const string connectionString = @"C:\Users\x0nr\Desktop\EPAM\OOPTASK\OOP Task Tests\OOP Task\Database";
        private Dictionary<string, (IDocument document, DateTime expirationTime)> documentCache = new Dictionary<string, (IDocument, DateTime)>();
        public void CacheDocument(IDocument document, string documentNumber, TimeSpan cacheDuration)
        {
            if (!documentCache.ContainsKey(documentNumber))
            {
                DateTime expirationTime = DateTime.UtcNow.Add(cacheDuration);
                documentCache[documentNumber] = (document, expirationTime);
            }
        }

        public IDocument GetCachedDocument(string documentNumber)
        {
            if (documentCache.TryGetValue(documentNumber, out var cachedDocument))
            {
                if (DateTime.UtcNow < cachedDocument.expirationTime)
                {
                    return cachedDocument.document;
                }
                else
                {
                    RemoveCachedDocument(documentNumber);
                }
            }
            return null; // The document is not in cache or it is expired
        }

        public void RemoveCachedDocument(string documentNumber)
        {
            if (documentCache.ContainsKey(documentNumber))
            {
                documentCache.Remove(documentNumber);
            }
        }

        public List<IDocument> SearchByDocumentNumber(string documentNumber)
        {

            List<IDocument> foundDocuments = new List<IDocument>();

            string[] files = Directory.GetFiles(connectionString, $"*_{documentNumber}.json", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                IDocument document = DeserializeDocument(json); 
                foundDocuments.Add(document);
            }

            return foundDocuments;
        }

        private IDocument DeserializeDocument(string json)
        {
            try
            {
                JsonDocumentOptions options = new JsonDocumentOptions
                {
                    AllowTrailingCommas = true
                };

                using (JsonDocument doc = JsonDocument.Parse(json, options))
                {
                    JsonElement root = doc.RootElement;

                    string documentType = root.GetProperty("DocumentType").GetString();

                    switch (documentType)
                    {
                        case "Patent":
                            return JsonSerializer.Deserialize<Patent>(json);
                        case "Book":
                            return JsonSerializer.Deserialize<Book>(json);
                        case "LocalizedBook":
                            return JsonSerializer.Deserialize<LocalizedBook>(json);
                        case "Magazine":
                            return JsonSerializer.Deserialize<Magazine>(json);
                        default:
                            throw new InvalidOperationException("Unknown document type encountered during deserialization.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing document: {ex.Message}");
                return null;
            }
        }
    }
}
