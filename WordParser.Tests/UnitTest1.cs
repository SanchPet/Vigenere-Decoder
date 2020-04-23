using NUnit.Framework;
using Homework_3_Csharp_Courses.Views.Home;
using Homework_3_Csharp_Courses.Controllers;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Logging;

namespace WordParser.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FileGeneratingTest()
        {
            HomeController home = new HomeController(null);
            home.DownloadFile("Съешь ещё этих мягких французких булок да выпей чаю.");
            Assert.Pass();
        }

        [Test]
        public void FileDOwnloadingTest()
        {
            string res = "Александр, знай, что я тебя ненавижу.\nУдачи.";
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\test.docx"))
                Assert.AreEqual(res, EncryptOperations.ParseWord(new TestClass(stream)));
        }

        //[Test]
        //public void FileDOwnloadingTest2()
        //{
        //    using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\test.xlxs"))
        //        Assert.Throws();
        //}

        [Test]
        public void EncryptTest()
        {
            string res1 = EncryptOperations.Encoder("Карл у Клары украл кораллы", "кларнет");
            string res = "Хлрь б Пюкьы дшхтц цобнрюё";
            Assert.AreEqual(res, res1);
        }

        [Test]
        public void DecryptTest()
        {
            string res1 = EncryptOperations.Decoder("Хлрь б Пюкьы дшхтц цобнрюё", "кларнет");
            string res = "Карл у Клары украл кораллы";
            Assert.AreEqual(res, res1);
        }
    }
}