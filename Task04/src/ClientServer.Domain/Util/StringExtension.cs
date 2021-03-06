﻿namespace ClientServer.Domain.Util
{
    /// <summary>
    /// Class with string extension
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Method for transliteration from Russian into English.
        /// </summary>
        /// <param name="message">Input messege.</param>
        /// <returns> Returns a string after transliteration.</returns>
        public static string MakeTransliterationFromRusIntoEnglish(this string message)
        {
            string resultMessage = string.Empty;
            string rusPattern = "абвгдеёжзийк" + "лмнопрстуфхцчшщ" + "ьыъэюя" + "АБВГДЕЁЖЗИЙКЛМНО" + "ПРСТУФХЦЧШЩЬЫЪЭЮЯ";
            string[] latPatternArr = {"a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch",
                "'", "y", "'", "e", "yu", "ya",
                "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O",
                "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "'", "Y", "'", "E", "Yu", "Ya"};
            char messageLetter = default;
            string patternLatLetter = string.Empty;
            bool letterIsEquel = false;

            for (int i = 0; i < message.Length; i++)
            {
                messageLetter = message[i];
                letterIsEquel = false;

                for (int j = 0; j < rusPattern.Length; j++)
                {
                    if (messageLetter == rusPattern[j])
                    {
                        letterIsEquel = true;
                        patternLatLetter = latPatternArr[j];
                        break;
                    }
                }

                if (letterIsEquel)
                    resultMessage += patternLatLetter;
                else
                    resultMessage += messageLetter;
            }

            return resultMessage;
        }
    }
}
