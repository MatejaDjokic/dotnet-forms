namespace plm
{
    public static class Plm
    {
        public static String ListToString(List<int> list)
        {
            if (list == null) return "Null";
            String str = String.Empty;

            if (list.Count == 1)
                str = list[0].ToString();
            else
                foreach (int i in list)
                {
                    str += $"{i.ToString()}, ";
                }

            return str;
        }
        public static Dictionary<T, int> ListToDict<T>(List<T> list)
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
        {
            Dictionary<T, int> dict = new();
            foreach (T key in list)
            {
                if (!dict.ContainsKey(key))
                    dict.Add(key, 1);
                else
                    dict[key] = 1;
            }
            return dict;
        }
        public static bool AllKeyEq<T, U>(Dictionary<T, U> dict, T key)
        {
            foreach (T k in dict.Keys)
                if (!k!.Equals(key))
                    return false;
            return true;
        }
        public static bool AllValsEq<T, U>(Dictionary<T, U> dict, U val)
        {
            foreach (U v in dict.Values)
                if (!v!.Equals(val))
                    return false;
            return true;
        }
        public static bool AnyKeyEq<T, U>(Dictionary<T, U> dict, T key)
        {
            foreach (T k in dict.Keys)
                if (k!.Equals(key))
                    return true;
            return false;
        }
        public static bool AnyValsEq<T, U>(Dictionary<T, U> dict, U val)
        {
            foreach (U v in dict.Values)
                if (v!.Equals(val))
                    return true;
            return false;
        }
        public static void PrintEnumerable<T>(IEnumerable<T> enumerable, bool enumerate = false, bool len = false)
        {
            int i = 0;
            foreach (T item in enumerable)
            {
                String t = item.GetType() == typeof(T) && len ? $"{item.ToString().Length}\t " : "";
                String en = enumerate ? $"{i + 1}. " : item.GetType() == typeof(T) && len ? "" : "";
                Console.Write($"{t}{en}{item} ");
                Console.WriteLine();
                i++;
            }
        }
        public static void ShiftListRight<T>(List<T> list)
        {
            if (list.Count > 0)
            {
                T lastItem = list.Last();
                list.RemoveAt(list.Count - 1);
                list.Insert(0, lastItem);
            }
        }
        public static void ShiftListLeft<T>(List<T> list)
        {
            if (list.Count > 0)
            {
                T firstItem = list.First();
                list.RemoveAt(0);
                list.Add(firstItem);
            }
        }
        public static T[] ShiftArrayRight<T>(T[] array)
        {
            if (array.Length > 0)
            {
                T lastElement = array[array.Length - 1];

                for (int i = array.Length - 1; i > 0; i--)
                    array[i] = array[i - 1];

                array[0] = lastElement;
            }
            return array;
        }
        public static T[] ShiftArrayLeft<T>(T[] array)
        {
            if (array.Length > 0)
            {
                T firstElement = array[0];

                for (int i = 0; i < array.Length - 1; i++)
                    array[i] = array[i + 1];

                array[array.Length - 1] = firstElement;

            }
            return array;
        }
        public static void ElapsedTime(DateTime start, DateTime end)
        {
            TimeSpan elapsedTime = end - start;
            Console.WriteLine("Time elapsed:");

            if (elapsedTime.Days > 0)
                Console.WriteLine($"{elapsedTime.Days} days");

            if (elapsedTime.Hours > 0)
                Console.WriteLine($"{elapsedTime.Hours} hours");

            if (elapsedTime.Minutes > 0)
                Console.WriteLine($"{elapsedTime.Minutes} minutes");

            if (elapsedTime.Seconds > 0)
                Console.WriteLine($"{elapsedTime.Seconds} seconds");

            if (elapsedTime.Milliseconds > 0)
                Console.WriteLine($"{elapsedTime.Milliseconds} milliseconds");
        }
        public static async Task<T[,]> ArrayToSquareMatrix<T>(T[] array)
        {
            double len = (double)array.Length;
            double sqrt = Math.Sqrt(len);
            if ((sqrt * sqrt) / len != 1)
                throw new Exception($"Array length must be n*n! Which {len} isn't!");

            T[,] matrix = new T[(int)sqrt, (int)sqrt];

            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = array[index];
                    index++;
                }
            }

            return matrix;
        }
        public static async Task Delay(int miliseconds) => await Task.Delay(miliseconds);
    }
}
