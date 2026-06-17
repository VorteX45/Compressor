using System.Text;

namespace Compressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static string Compress(string input)
        {
            var result = new StringBuilder("");
            var splittedInput = new List<string>();
            char currentCharacter;
            int characterCount;

            // валидация
            if (input.Length == 0)
            {
                return "";
            }
            if (!input.All(char.IsLetter))
            {
                throw new InvalidDataException("Во входных данных разрешены лишь буквы");
            }

            // проходим по входной строке. Пока символы повторяются - увеличиваем счетчик
            // если встречаем новый символ - записываем предыдущий и счетчик в промежуточный результат
            currentCharacter = input[0];
            characterCount = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == currentCharacter)
                {
                    characterCount++;
                }
                else
                {
                    result.Append(currentCharacter + (characterCount == 1 ? "" : characterCount.ToString()));
                    currentCharacter = input[i];
                    characterCount = 1;
                }
            }
            result.Append(currentCharacter + (characterCount == 1 ? "" : characterCount.ToString()));

            return result.ToString();
        }
    }
}