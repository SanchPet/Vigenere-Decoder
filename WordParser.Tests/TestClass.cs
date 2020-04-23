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
        public string ContentDisposition => throw new NotImplementedException();

        public string ContentType => throw new NotImplementedException();

        public string FileName => throw new NotImplementedException();

        public IHeaderDictionary Headers => throw new NotImplementedException();

        public Stream stream;

        public long Length => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

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

        public TestClass(FileStream s)
        {
            stream = s;
        }
    }
}
