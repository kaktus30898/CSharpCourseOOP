using VectorTask;

namespace MatrixTask;

public class Program
{
    static void Main()
    {
        Matrix matrix = new Matrix(new double[,]
        {
            { 2, 4, 0 },
            { -2, 1, 3 },
            { -1, 0, 1 }
        });

        Vector vector = new Vector(new double[] { 1, 2, -1 });

        Vector vector1 = matrix.MultiplicationByVector(vector);
        
        Console.WriteLine(vector1);
    }
}