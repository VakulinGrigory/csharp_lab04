public class MyMatrix
{
    private int[,] matrix;
    public int Rows { get; }
    public int Cols { get; }
    
    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        Rows = rows;
        Cols = cols;
        matrix = new int[rows, cols];
        Random rand = new Random();
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue + 1);
            }
        }
    }
    
    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
        {
            throw new ArgumentException("Матрицы должны быть одного размера для сложения.");
        }
        
        MyMatrix result = new MyMatrix(a.Rows, a.Cols, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
        {
            throw new ArgumentException("Матрицы должны быть одного размера для вычитания.");
        }

        MyMatrix result = new MyMatrix(a.Rows, a.Cols, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.Cols != b.Rows)
        {
            throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
        }
        
        MyMatrix result = new MyMatrix(a.Rows, b.Cols, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Cols; j++)
            {
                for (int k = 0; k < a.Cols; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    public static MyMatrix operator *(MyMatrix a, int scalar)
    {
        MyMatrix result = new MyMatrix(a.Rows, a.Cols, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }
        return result;
    }

    public static MyMatrix operator /(MyMatrix a, int scalar)
    {
        MyMatrix result = new MyMatrix(a.Rows, a.Cols, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] / scalar;
            }
        }
        return result;
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                result += matrix[i, j] + "\t";
            }
            result += "\n";
        }
        return result;
    }
}

class exercise1
{
    public static void Main(string[] args)
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество столбцов: ");
        int cols = int.Parse(Console.ReadLine());
        
        Console.Write("Введите минимальное значение: ");
        int minValue = int.Parse(Console.ReadLine());
        
        Console.Write("Введите максимальное значение: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix1 = new MyMatrix(rows, cols, minValue, maxValue);
        MyMatrix matrix2 = new MyMatrix(rows, cols, minValue, maxValue);
        

        Console.WriteLine("Матрица 1:");
        Console.WriteLine(matrix1);
        
        Console.WriteLine("Матрица 2:");
        Console.WriteLine(matrix2);

        Console.WriteLine("Сложение матриц:");
        Console.WriteLine(matrix1 + matrix2);

        Console.WriteLine("Вычитание матриц:");
        Console.WriteLine(matrix1 - matrix2);

        Console.WriteLine("Умножение матрицы на число:");
        Console.WriteLine(matrix1 * 3);

        Console.WriteLine("Деление матрицы на число:");
        Console.WriteLine(matrix1 / 3);
    }
}