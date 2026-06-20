using System.Text;
using System.Text.RegularExpressions;

namespace Compressor
{
    public static class CompressorDecompressor
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aaabbcccdde -> " + Compress("aaabbcccdde"));
            Console.WriteLine("a3b2c3d2e -> " + Decompress("a3b2c3d2e"));
        }


        public static string Compress(string input)
        {
            Regex letterGroupRegex = new Regex(@"(\w)\1*", RegexOptions.Compiled); // повторяющийся символ
            StringBuilder result = new StringBuilder();

            // валидация
            if (input.Length == 0)
                return "";
            if (!input.All(char.IsLetter))
                throw new InvalidDataException("Во входных данных разрешены лишь буквы");

            // разбиваем строку на блоки из повторяющихся символов
            MatchCollection allLetterGroups = letterGroupRegex.Matches(input);
            // записываем символ и его количество из каждого блока в промежуточный результат
            foreach (Match match in allLetterGroups)
                result.Append(match.Value[0] + (match.Value.Length > 1 ? match.Value.Length.ToString() : ""));

            return result.ToString();
        }


        public static string Decompress(string input)
        {
            Regex letterMaybeNumberRegex = new Regex(@"[a-z]\d*", RegexOptions.Compiled); // буквачисло или буква
            StringBuilder result = new StringBuilder();

            // валидация
            if (input.Length == 0)
                return "";
            if (char.IsDigit(input[0]))
                throw new InvalidDataException("Строка не может начинаться с цифры");
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c))
                    throw new InvalidDataException("В строке должны быть лишь буквы и цифры");
            }

            // разбиваем строку на блоки "буква-число" или "буква"
            MatchCollection allLetterNumberGroups = letterMaybeNumberRegex.Matches(input);
            foreach (Match match in allLetterNumberGroups)
            {
                int symbolCount = match.Value.Length > 1 ? Convert.ToInt32(match.Value.Substring(1)) : 1;
                result.Append(new string(match.Value[0], symbolCount));
            }

            return result.ToString();
        }









        //public static string Decompress(string input)
        //{
        //    var result = new StringBuilder();
        //    char currentCharacter;
        //    var characterCount = new StringBuilder();
        //    bool parsingCount;

        //    // валидация
        //    if (input.Length == 0)
        //    {
        //        return "";
        //    }
        //    foreach (char c in input)
        //    {
        //        if (!char.IsLetterOrDigit(c))
        //        {
        //            throw new InvalidDataException("В строке должны быть лишь буквы и цифры");
        //        }
        //    }

        //    // перебираем буквы и их количества
        //    parsingCount = false;
        //    currentCharacter = '-'; // еще не успели считать букву
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (char.IsLetter(input[i]))
        //        {
        //            // если мы считывали количество и наткнулись на букву, это конец очередной пары
        //            // записываем предыдущий символ в промежуточный результат
        //            if (parsingCount)
        //            {
        //                result.Append(new string(currentCharacter, int.Parse(characterCount.ToString())));
        //                parsingCount = false;
        //                characterCount.Clear();
        //            }
        //            // новая буква
        //            else
        //            {
        //                if (currentCharacter != '-')
        //                    result.Append(currentCharacter);
        //                currentCharacter = input[i];
        //                parsingCount = true;
        //            }
        //        }
        //        // новая цифра
        //        else
        //        {
        //            if (currentCharacter == '-')
        //                throw new InvalidDataException("Строка не может начинаться с числа");
        //            else
        //                characterCount.Append(input[i]);
        //        }
        //    }
        //    // записываем последний символ
        //    if (characterCount.Length > 0)
        //        result.Append(new string(currentCharacter, int.Parse(characterCount.ToString())));
        //    else
        //        result.Append(currentCharacter);

        //    return result.ToString();
        //}


        //public static string Compress(string input)
        //{
        //    var result = new StringBuilder("");
        //    var splittedInput = new List<string>();
        //    char currentCharacter;
        //    int characterCount;

        //    // валидация
        //    if (input.Length == 0)
        //    {
        //        return "";
        //    }
        //    if (!input.All(char.IsLetter))
        //    {
        //        throw new InvalidDataException("Во входных данных разрешены лишь буквы");
        //    }

        //    // проходим по входной строке. Пока символы повторяются - увеличиваем счетчик
        //    // если встречаем новый символ - записываем предыдущий символ и его счетчик в промежуточный результат
        //    currentCharacter = input[0];
        //    characterCount = 1;
        //    for (int i = 1; i < input.Length; i++)
        //    {
        //        if (input[i] == currentCharacter)
        //        {
        //            characterCount++;
        //        }
        //        else
        //        {
        //            result.Append(currentCharacter + (characterCount == 1 ? "" : characterCount.ToString()));
        //            currentCharacter = input[i];
        //            characterCount = 1;
        //        }
        //    }
        //    result.Append(currentCharacter + (characterCount == 1 ? "" : characterCount.ToString()));

        //    return result.ToString();
        //}
    }
}