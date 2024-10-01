using System;
using System.IO;
using System.Linq;

namespace SentenceCapitalization
{
    public static class StringExtensions
    {
        public static string CapitalizeSentences(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] sentenceEndings = { '.', '!', '?' };
            var sentences = input.Split(sentenceEndings)
                                 .Select(s => s.Trim()) // Убираем лишние пробелы
                                 .Where(s => !string.IsNullOrEmpty(s)) // Фильтруем пустые предложения
                                 .Select(s => char.ToUpper(s[0]) + s.Substring(1)); // Делаем первую букву заглавной

            string result = string.Join(". ", sentences) + ".";

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string filePath = "C:\\Users\\sadev\\OneDrive\\Рабочий стол\\ДЗ.txt"; // Путь к файлу
                var lines = File.ReadAllLines(filePath);

                var capitalizedLines = lines.Select(line => line.CapitalizeSentences()).ToList();

                foreach (var line in capitalizedLines)
                {
                    Console.WriteLine(line);
                }

                string outputPath = "C:\\Users\\sadev\\OneDrive\\Рабочий стол\\output.txt";
                File.WriteAllLines(outputPath, capitalizedLines);

                Console.WriteLine("Файл успешно обработан. Результат сохранен в 'output.txt'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
