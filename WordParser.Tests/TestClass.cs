using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordParser.Tests
{
    class TestClass : IFormFile
    {
        public string ContentDisposition { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }

        public IHeaderDictionary Headers { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public Stream stream;

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            return stream;
        }

        public TestClass(FileStream s, string fileName)
        {
            this.FileName = fileName;
            stream = s;
        }
    }
}
