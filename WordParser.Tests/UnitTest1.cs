using NUnit.Framework;
using Homework_3_Csharp_Courses.Views.Home;
using Homework_3_Csharp_Courses.Controllers;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Logging;
using System;
using Homework_3_Csharp_Courses;

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
            home.DownloadFile("����� ��� ���� ������ ���������� ����� �� ����� ���.", "Download as docx");
            Assert.Pass();
        }

        [Test]
        public void FileGeneratingTest2()
        {
            HomeController home = new HomeController(null);
            home.DownloadFile("����� ��� ���� ������ ���������� ����� �� ����� ���.", "Download as txt");
            Assert.Pass();
        }

        [Test]
        public void FileDOwnloadingTest()
        {
            string res = "���� ���� ���������� ������.\r\n�����.";
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\test.docx"))
                Assert.AreEqual(res, EncryptOperations.ParseWord(new TestClass(stream, "\\text.docx")));
        }
        [Test]
        public void FileDOwnloadingTest5()
        {
            string res = "�����������������������, � ���� ����!!! � �� ���� �� ������...\r\n";
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\test.txt"))
                Assert.AreEqual(res, EncryptOperations.ParseWord(new TestClass(stream, "\\text.txt")));
        }

        [Test]
        public void FileDOwnloadingTest3()
        {
            string res = "Hello, fellow humans!\r\nI love you.";
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\testEng.docx"))
                Assert.AreEqual(res, EncryptOperations.ParseWord(new TestClass(stream, "\\testEng.docx")));
        }

        [Test]
        public void FileDOwnloadingTest4()
        {
            string res = "Hello, fellow humans!\r\nI love you.";
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\testEng.txt"))
                Assert.AreEqual(res, EncryptOperations.ParseWord(new TestClass(stream, "\\testEng.txt")));
        }


        [Test]
        public void FileDOwnloadingTest2()
        {
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\text.xlsx"))
            {
                var ex = Assert.Throws<Exceptions.WrongFileException>(() => EncryptOperations.ParseWord(new TestClass(stream, "\\text.xlsx")));
                Assert.That(ex.Message, Is.EqualTo("You have downloaded an unsupported file format."));
            }
        }

        [Test]
        public void EncryptTest()
        {
            string res1 = EncryptOperations.Encoder("���� � ����� ����� �������", "�������", "Rus");
            string res = "���� � ����� ����� �������";
            Assert.AreEqual(res, res1);
        }
        [Test]
        public void EncryptTest2()
        {
            string res1 = EncryptOperations.Encoder("Hello, fellow humans!", "creep", "Eng");
            string res = "Jvppd, hvppdy yyqppj!";
            Assert.AreEqual(res, res1);
        }

        [Test]
        public void EncryptTest3()
        {
            string res1 = EncryptOperations.Encoder("Hello, fellow humans!", "��������", "Rus");
            string res = "Hello, fellow humans!";
            Assert.AreEqual(res, res1);
        }
        [Test]
        public void DecryptTest()
        {
            string res1 = EncryptOperations.Decoder("���� � ����� ����� �������", "�������", "Rus");
            string res = "���� � ����� ����� �������";
            Assert.AreEqual(res, res1);
        }
        [Test]
        public void DecryptTest2()
        {
            string res1 = EncryptOperations.Decoder("Jvppd, hvppdy yyqppj!", "creep", "Eng");
            string res = "Hello, fellow humans!";
            Assert.AreEqual(res, res1);
        }

        [Test]
        public void DecryptTest3()
        {
            string res1 = EncryptOperations.Decoder("Jvppd, hvppdy yyqppj!", "����", "Rus");
            string res = "Jvppd, hvppdy yyqppj!";
            Assert.AreEqual(res, res1);
        }

        [Test]
        public void FilesEncrDecr()
        {
            var ex = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Decoder("���� � ����� ����� �������", "", "Rus"));
            var ex2 = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Encoder("���� � ����� ����� �������", "", "Rus"));
            Assert.That(ex.Message, Is.EqualTo("Incorrect key."));
            Assert.That(ex2.Message, Is.EqualTo("Incorrect key."));
        }

        [Test]
        public void FilesEncrDecr2()
        {
            var ex = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Decoder("���� � ����� ����� �������", "kekeke", "Rus"));
            var ex2 = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Encoder("���� � ����� ����� �������", "kekekek", "Rus"));
            Assert.That(ex.Message, Is.EqualTo("Incorrect key."));
            Assert.That(ex2.Message, Is.EqualTo("Incorrect key."));
        }
        [Test]
        public void FilesEncrDecr3()
        {
            var ex = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Decoder("Hello, fellow humans!", "�����", "Eng"));
            var ex2 = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Encoder("Hello, fellow humans!", "������", "Eng"));
            Assert.That(ex.Message, Is.EqualTo("Incorrect key."));
            Assert.That(ex2.Message, Is.EqualTo("Incorrect key."));
        }
        [Test]
        public void FilesEncrDecr4()
        {
            var ex = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Decoder("Hello, fellow humans!", "Sss�����", "Eng"));
            var ex2 = Assert.Throws<Exceptions.WrongKeyException>(() => EncryptOperations.Encoder("Hello, fellow humans!", "Ssss������", "Eng"));
            Assert.That(ex.Message, Is.EqualTo("Incorrect key."));
            Assert.That(ex2.Message, Is.EqualTo("Incorrect key."));
        }

    }
}