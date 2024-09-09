namespace System
{
    using System.Collections.Generic;
    using System.Text;
    public class GenericLogic
    {
        public static DateTime IstNow
        {
            get
            {
                return System.DateTime.UtcNow.AddHours(5.5);
            }
        }

        public static string DisplayDateFormat
        {
            get
            {
                return "MMM-dd-yyyy, hh:mm:ss tt, ddd";
            }
        }

        public static string StringGenerate(int lenght = 16)
        {
            NameGenerator();
            Random random = new Random();
            StringBuilder buffer = new StringBuilder(lenght);
            for (int i = 0; i < lenght; i++)
            {
                int randomNumber = random.Next(0, _characters.Count);
                char randomChar = _characters[randomNumber];
                buffer.Append(randomChar);
            }
            return buffer.ToString();
        }
        private static List<char> _characters;
        private static void NameGenerator()
        {
            _characters = new List<char>();
            // Fill character list with A-Z.
            for (int i = 65; i <= 90; i++)
            {
                _characters.Add((char)i);
            }
            // Fill character list with a-z.
            for (int i = 97; i <= 122; i++)
            {
                _characters.Add((char)i);
            }
            // Fill character list with 0-9.
            for (int i = 48; i <= 57; i++)
            {
                _characters.Add((char)i);
            }
        }
    }
}
