using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;

public static class Program
{
    public static void Main()
    {
        String skocko = Skocko.gen(4, 6);
        Console.WriteLine(skocko);
        while (true)
        {
            Console.Write("Unos: ");
            String input = Console.ReadLine()!;
            int[] guess = Skocko.guess(skocko, input);
            if (guess[0] == 4)
            {
                Console.WriteLine("POBEDIO SI!");
                break;
            }

            Console.WriteLine($"Na mestu: {guess[0]}");
            Console.WriteLine($"Nije na mestu: {guess[1]}");
        }

    }
}

static class Skocko
{
    static char[] to(String input) =>
        input.ToCharArray();
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
                if (correctCombination[i] == combination[j])
                    if (combination[j] != '-' && correctCombination[i] != '-')
                    {
                        nije_na_mestu++;
                    }
            }
        return new int[2] { na_mestu, nije_na_mestu };
    }


}
