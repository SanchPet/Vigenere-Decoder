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
            home.DownloadFile("����� ��� ���� ������ ���������� ����� �� ����� ���.");
            Assert.Pass();
        }

        [Test]
        public void FileDOwnloadingTest()
        {
            string res = "���������, ����, ��� � ���� ��������.\n�����.";
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
            string res1 = EncryptOperations.Encoder("���� � ����� ����� �������", "�������");
            string res = "���� � ����� ����� �������";
            Assert.AreEqual(res, res1);
        }

        [Test]
        public void DecryptTest()
        {
            string res1 = EncryptOperations.Decoder("���� � ����� ����� �������", "�������");
            string res = "���� � ����� ����� �������";
            Assert.AreEqual(res, res1);
        }
    }
}