using System.Runtime.InteropServices;

namespace Codes.Text
{
    static class Text
    {
        public static String[] GenerateSubstrings(String word)
        {
            List<string> substrings = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = i + 1; j <= word.Length; j++)
                {
                    substrings.Add(word.Substring(i, j - i));
                }
            }

            for (int len = 1; len <= word.Length; len++)
            {
                for (int i = 0; i <= word.Length - len; i++)
                {
                    if (!substrings.Contains(word.Substring(i, len)))
                        substrings.Add(word.Substring(i, len));
                }
            }

            return substrings.ToArray();
        }
        public static uint TimesInString(String s1, String s2)
        {
            uint brojac = 0;
            int p = 0;
            while ((p = s1.IndexOf(s2, p)) != -1)
            {
                brojac++;
                p++;
            }
            return brojac;
        }
        public static bool Contains(String s1, String s2)
        {
            return Text.TimesInString(s1, s2) > 0;
        }
        public static bool IsPeriodic(String word)
        {
            bool periodicna = false;

            for (int p = 1; 2 * p <= word.Length; p++)
            {
                bool greska = false;

                for (int i = 0; i + p < word.Length; i++)
                    if (word[i] != word[i + p])
                    {
                        greska = true;
                        break;
                    }

                if (!greska)
                {
                    periodicna = true;
                    break;
                }
            }
            return periodicna;
        }
        public static bool IsPalindrome(String word)
        {
            int len = word.Length;
            if (len % 2 != 0)
            {
                int middleIndex = (int)Math.Floor(len / 2.0);
                String left = word.Substring(0, (len - 1) / 2);
                String right = word.Substring(middleIndex + 1, (len - 1) / 2);
                right = string.Join("", right.Reverse());
                return left == right;
            }
            else
            {
                String left = word.Substring(0, len / 2);
                String right = word.Substring(len / 2, len / 2);
                right = string.Join("", right.Reverse());
                return left == right;
            }
        }
        public static String LongestPalindrome(String word)
        {
            String[] substring = Text.GenerateSubstrings(word);
            return substring.ToList()
                .Where(w => Text.IsPalindrome(w)).ToList()
                .OrderByDescending(p => p.Length)
                .First();
        }
        public static String MinimalExpensionToPalindrome(String word)
        {
            if (Text.IsPalindrome(word)) return word;

            String[] substrings = Text.GenerateSubstrings(word);
            String palindromeToRemove = substrings.ToList()
                .Where(w => Text.IsPalindrome(w)).ToList()
                .OrderByDescending(p => p.Length)
                .First();

            String str = string.Join("", word.Replace(palindromeToRemove, "").Reverse());
            return word + str;
        }
    }
}
