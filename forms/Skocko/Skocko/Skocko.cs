using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skocko
{
    static class Skocko
    {
        static char[] to(String input) =>
            input.ToCharArray();
        public static String to_numbers(String input, char[] chars)
        {
            String result = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                int index = chars.ToList().IndexOf(c);
                result += (index + 1).ToString();
            }
            return result;
        }
        public static String gen(int char_len, int chars)
        {
            String result = String.Empty;

            Random r = new Random();
            for (int i = 0; i < char_len; i++)
                result += r.Next(chars) + 1;
            return result;
        }

        public static int[] guess(String correct, String comb)
        {
            char[] combination = to(comb);
            char[] correctCombination = to(correct);
            int na_mestu = 0;
            int nije_na_mestu = 0;

            if (correctCombination.Length != combination.Length) throw new Exception();
            for (int i = 0; i < combination.Length; i++)
                if (correctCombination[i] == combination[i])
                {
                    na_mestu++;
                    combination[i] = '-';
                    correctCombination[i] = '-';
                }
            for (int i = 0; i < combination.Length; i++)
                for (int j = 0; j < combination.Length; j++)
                {
                    if (combination[i] == correctCombination[j])
                        if (combination[i] != '-' && correctCombination[j] != '-')
                            nije_na_mestu++;
                }
            return new int[2] { na_mestu, nije_na_mestu };
        }
    }
}
