using System.ComponentModel;

int[,] generate(int col, int row)
{
    int[,] mat = new int[col, row];
    for (int i = 0; i < col; i++)
        for (int j = 0; j < row; j++)
            mat[i, j] = 0;
    return mat;
}

bool[] rows = new bool[9];
bool[] cols = new bool[9];
bool[] quadrants = new bool[9];
int[] check_arr = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


bool win = false;
bool lose = false;
int[,] grid = new int[,]
{
    {5, 3, 0, 0, 7, 0, 0, 0, 0},
    {6, 0, 0, 1, 9, 5, 0, 0, 0},
    {0, 9, 8, 0, 0, 0, 0, 6, 0},
    {8, 0, 0, 0, 6, 0, 0, 0, 3},
    {4, 0, 0, 8, 0, 3, 0, 0, 1},
    {7, 0, 0, 0, 2, 0, 0, 0, 6},
    {0, 6, 0, 0, 0, 0, 2, 8, 0},
    {0, 0, 0, 4, 1, 9, 0, 0, 5},
    {0, 0, 0, 0, 8, 0, 0, 7, 9}
};
bool[,] start = new bool[grid.GetLength(0), grid.GetLength(1)];
for (int i = 0; i < start.GetLength(0); i++)
    for (int j = 0; j < start.GetLength(1); j++)
        if (grid[i, j] == 0)
            start[i, j] = false;
        else
            start[i, j] = true;

for (int i = 0; i < 9; i++)
{
    quadrants[i] = false;
    rows[i] = false;
    cols[i] = false;
}

void print(int[,] matrix, bool[,] isFixed, bool[] invalidRows, bool[] invalidColumns, bool[] invalidQuadrants)
{
    Console.WriteLine("    0 1 2   3 4 5   6 7 8\n");

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write(i + "   ");

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int element = matrix[i, j];
            bool isFixedValue = isFixed[i, j];
            string output = (element == 0) ? " " : $"{element}";

            if (!isFixedValue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            if (invalidRows[j] || invalidColumns[i] || invalidQuadrants[i + j ])
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }

            Console.Write(output.PadRight(2));

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            if ((j + 1) % 3 == 0 && j != matrix.GetLength(1) - 1)
            {
                Console.Write("| ");
            }
        }

        if ((i + 1) % 3 == 0 && i != matrix.GetLength(0) - 1)
        {
            Console.WriteLine();
            Console.WriteLine("    " + new string('-', 21));
        }
        else
        {
            Console.WriteLine();
        }
    }
}

void p(int[,] mat)
{
    for (int i = 0; i < mat.GetLength(0); i++)
    {
        for (int j = 0; j < mat.GetLength(1); j++)
        {
            int el = mat[i, j];
            String o = el == 0 ? "  " : $"{el} ";
            Console.Write(o);
            Console.ForegroundColor = ConsoleColor.White;
            if ((j + 1) % 3 == 0 && j != mat.GetLength(1) - 1)
                Console.Write("| ");
        }
        if ((i + 1) % 3 == 0 && i != mat.GetLength(0) - 1)
        {
            Console.WriteLine();
            String o = new string('-', 21);
            Console.WriteLine(o);
        }
        else
            Console.WriteLine();
    }
}
void row_valid(int[,] grid, int row)
{
    bool[] usedNumbers = new bool[10];
    for (int col = 0; col < 9; col++)
    {
        int num = grid[row, col];
        if (num != 0)
        {
            if (usedNumbers[num])
            {
                rows[row] = false;
                return;
            }
            usedNumbers[num] = true;
        }
    }
    rows[row] = true;
}
void col_valid(int[,] grid, int col)
{
    bool[] usedNumbers = new bool[10];
    for (int row = 0; row < 9; row++)
    {
        int num = grid[row, col];
        if (num != 0)
        {
            if (usedNumbers[num])
            {
                cols[col] = false;
                return;
            }
            usedNumbers[num] = true;
        }
    }
    cols[col] = true;
}

void quad_valid(int[,] grid, int y, int x)
{
    int index = y / 3 * 3 + x / 3;
    int quadrantRow = index / 3;
    int quadrantCol = index % 3;

    bool[] usedNumbers = new bool[10];
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            int num = grid[quadrantRow * 3 + i, quadrantCol * 3 + j];
            if (num != 0)
            {
                if (usedNumbers[num])
                {
                    quadrants[quadrantRow * 3 + quadrantCol] = false;
                    return;
                }
                usedNumbers[num] = true;
            }
        }
    }
    quadrants[quadrantRow * 3 + quadrantCol] = true;
}


int[,] mat = new int[9, 9];
for (int i = 0; i < 9; i++)
    for (int j = 0; j < 9; j++)
        mat[i, j] = rows[j] ? 1 : 0;

while (!win || !lose)
{
    print(grid, start);

    Console.Write("\nUnos (x,y,br): ");
    String[] s1 = Console.ReadLine()!.Split(" ");
    int i = int.Parse(s1[0]);
    int j = int.Parse(s1[1]);
    int broj = int.Parse(s1[2]);
    if (i >= 0 && i < 9 && j >= 0 && j < 9)
    {
        if (!start[i, j])
            grid[i, j] = broj;
        else
        {
            Console.WriteLine("Ne mozete da upisete na to polje!");
            Console.Write("Dalje...");
            Console.ReadLine();
        }
    }
    else
    {
        Console.WriteLine("Ne mozete da upisete na to polje!");
        Console.Write("Dalje...");
        Console.ReadLine();
    }

    row_valid(grid, j);
    col_valid(grid, i);
    quad_valid(grid, i, j);

    Console.Clear();
}
