using System;

class MyMatrix
{
    private int[,] matrix;
    private int n, m;
    public MyMatrix(int n, int m, int min_val, int max_val)
    {
        this.n = n;
        this.m = m;
        matrix = new int[n, m];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) { matrix[i, j] = rand.Next(min_val, max_val + 1); }
        }
    }
    public void Fill(int min_val, int max_val)
    {
        Random rand = new Random();
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; j++) { matrix[i, j] = rand.Next(min_val, max_val + 1); }
        }
    }
    public int this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }
    public MyMatrix ChangeSize(int new_n, int new_m, int min_val, int max_val)
    {
        MyMatrix result = new MyMatrix(new_n, new_m, 0, 0);
        Random rand = new Random();
        for (int i = 0; i < new_n; i++)
        {
            for (int j = 0; j < new_m; j++)
            {
                if (i >= n || j >= m) { result.matrix[i, j] = rand.Next(min_val, max_val + 1); }
                else { result.matrix[i, j] = matrix[i, j]; }
            }
        }
        return result;
    }
    public void ShowPartialy(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) { Console.Write($"{matrix[i, j]} "); }
            Console.WriteLine();
        }
    }
    public void Show() { ShowPartialy(n, m); }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Enter the minimum value: ");
        int min_val = int.Parse(Console.ReadLine());

        Console.Write("Enter the maximum value: ");
        int max_val = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(n, m, min_val, max_val);

        Console.WriteLine("Matrix:");
        matrix.Show();

        Console.WriteLine("\nChanging the matrix size: ");
        Console.Write("Enter the new number of rows: ");
        int new_n = int.Parse(Console.ReadLine());

        Console.Write("Enter the new number of columns: ");
        int new_m = int.Parse(Console.ReadLine());

        MyMatrix new_matrix = matrix.ChangeSize(new_n, new_m, min_val, max_val);

        Console.WriteLine("New matrix:");
        new_matrix.Show();

        Console.WriteLine("\nDisplaying a portion of the matrix: ");
        matrix.ShowPartialy(2, 1);

        Console.WriteLine("\nChanging an element of the matrix: ");
        Console.Write("Enter the row index: ");
        int n_i = int.Parse(Console.ReadLine());

        Console.Write("Enter the column index: ");
        int m_j = int.Parse(Console.ReadLine());

        Console.Write("Enter the new value: ");
        int new_val = int.Parse(Console.ReadLine());

        matrix[n_i, m_j] = new_val;

        Console.WriteLine("Modified matrix:");
        matrix.Show();
    }
}
