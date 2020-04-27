using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Homework_3_Csharp_Courses.Views.Home
{
    public class EncryptOperations
    {
        static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string ParseWord(IFormFile file)
        {
            string result = "";
            if (Path.GetExtension(file.FileName).ToLower() == ".docx")
            {
                using (Stream fs = file.OpenReadStream())
                {
                    var doc = DocX.Load(fs);
                    for (int i = 0; i < doc.Paragraphs.Count; i++)
                    {
                        result += doc.Paragraphs[i].Text;
                        if (i != doc.Paragraphs.Count - 1) result += "\n";
                    }
                }
            }
            else throw Exceptions.CallExcepton(1);
            return result;
        }

        public static string Encoder(string stringToEncode, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("Вы не ввели ключ.");
            StringBuilder res = new StringBuilder(); 
            int i = 0;
            foreach (var symbol in stringToEncode)
            {
                if (alphabet.Contains(char.ToLower(symbol)))
                {
                    if (char.IsUpper(symbol))
                    {
                        res.Append(char.ToUpper(alphabet[(alphabet.IndexOf(symbol.ToString().ToLower()) + alphabet.IndexOf(key[i % key.Length])) % alphabet.Length]));
                    }
                    else
                    {
                        res.Append(char.ToLower(alphabet[(alphabet.IndexOf(symbol.ToString().ToLower()) + alphabet.IndexOf(key[i % key.Length])) % alphabet.Length]));
                    }
                    i++;
                }
                else
                {
                    res.Append(symbol);
                }
            }
            return res.ToString();
        }

        public static string Decoder(string stringToDecode, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new Exception("Вы не ввели ключ.");
            StringBuilder res = new StringBuilder();
            int i = 0;
            foreach (var symbol in stringToDecode)
            {
                if (alphabet.Contains(char.ToLower(symbol)))
                {
                    if (char.IsUpper(symbol))
                    {
                        res.Append(char.ToUpper(alphabet[(alphabet.IndexOf(symbol.ToString().ToLower()) - alphabet.IndexOf(key[i % key.Length]) + alphabet.Length) % alphabet.Length]));
                    }
                    else
                    {
                        res.Append(char.ToLower(alphabet[(alphabet.IndexOf(symbol.ToString().ToLower()) - alphabet.IndexOf(key[i % key.Length]) + alphabet.Length) % alphabet.Length]));
                    }
                    i++;
                }
                else
                {
                    res.Append(symbol);
                }
            }
            return res.ToString();
        }

        



    }
}
