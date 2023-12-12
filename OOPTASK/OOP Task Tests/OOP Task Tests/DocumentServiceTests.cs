using OOP_Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Task_Tests
{
    public class DocumentServiceTests
    {

        private const string TestDocumentsPath = @"C:\Users\x0nr\Desktop\EPAM\OOPTASK\OOP Task Tests\OOP Task\Database";

        [Fact]
        public void CacheDocument_Should_AddDocumentToCache()
        {
            // Arrange
            var documentService = new DocumentService();
            var testDocument = new TestDocument() { DocumentNumber = "123", Content = "Test content" };
            var cacheDuration = TimeSpan.FromMinutes(10);

            // Act
            documentService.CacheDocument(testDocument, testDocument.DocumentNumber, cacheDuration);

            // Assert
            var cachedDocument = documentService.GetCachedDocument(testDocument.DocumentNumber);
            Assert.NotNull(cachedDocument);
            Assert.Equal(testDocument.Content, ((TestDocument)cachedDocument).Content);
        }

        [Fact]
        public void GetCachedDocument_Should_ReturnNull_When_DocumentExpired()
        {
            // Arrange
            var documentService = new DocumentService();
            var testDocument = new TestDocument() { DocumentNumber = "456", Content = "Test content" };
            var cacheDuration = TimeSpan.FromSeconds(1);

            // Act
            documentService.CacheDocument(testDocument, testDocument.DocumentNumber, cacheDuration);

            // Wait for the cache to expire
            System.Threading.Thread.Sleep(cacheDuration.Add(TimeSpan.FromSeconds(1)));

            // Assert
            var cachedDocument = documentService.GetCachedDocument(testDocument.DocumentNumber);
            Assert.Null(cachedDocument);
        }

        [Fact]
        public void GetCachedDocument_Should_ReturnCachedDocument_When_WithinCacheExpiration()
        {
            // Arrange
            var documentService = new DocumentService();
            var testDocument = new TestDocument() { DocumentNumber = "789", Content = "Test content" };
            var cacheDuration = TimeSpan.FromSeconds(2);

            // Act
            documentService.CacheDocument(testDocument, testDocument.DocumentNumber, cacheDuration);

            // Wait for the cache to be within the expiration period
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            // Assert
            var cachedDocument = documentService.GetCachedDocument(testDocument.DocumentNumber);
            Assert.NotNull(cachedDocument);
            Assert.Equal(testDocument.Content, ((TestDocument)cachedDocument).Content);
        }

        [Fact]
        public void RemoveCachedDocument_Should_RemoveDocumentFromCache()
        {
            // Arrange
            var documentService = new DocumentService();
            var testDocument = new TestDocument() { DocumentNumber = "111", Content = "Test content" };
            var cacheDuration = TimeSpan.FromMinutes(10);

            // Act
            documentService.CacheDocument(testDocument, testDocument.DocumentNumber, cacheDuration);
            documentService.RemoveCachedDocument(testDocument.DocumentNumber);

            // Assert
            var cachedDocument = documentService.GetCachedDocument(testDocument.DocumentNumber);
            Assert.Null(cachedDocument);
        }

        // Helper class for testing
        public class TestDocument : IDocument
        {
            public string DocumentNumber { get; set; }
            public string Content { get; set; }
        }
    }
}
