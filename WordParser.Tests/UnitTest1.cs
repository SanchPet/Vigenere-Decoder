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
            home.DownloadFile("Съешь ещё этих мягких французких булок да выпей чаю.");
            Assert.Pass();
        }

        [Test]
        public void FileDOwnloadingTest()
        {
            string res = "Этот тест невозможно пройти.\nУдачи.";
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\test.docx"))
                Assert.AreEqual(res, EncryptOperations.ParseWord(new TestClass(stream, "\\text.docx")));
        }

        [Test]
        public void FileDOwnloadingTest2()
        {
            using (var stream = File.OpenRead(Directory.GetCurrentDirectory() + "\\text.xlsx"))
            {
                var ex = Assert.Throws<Exceptions.WrongFileException>(() => EncryptOperations.ParseWord(new TestClass(stream, "\\text.xlsx")));
                Assert.That(ex.Message, Is.EqualTo("Вы загрузили неподдерживаемый формат файла."));
            }
        }

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