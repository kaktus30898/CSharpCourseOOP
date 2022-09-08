using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    public class Program
    {
        static void Main()
        {
            Vector vectorA = new Vector(new double[] { 1, 2, 3, 4 });
            Vector vectorB = new Vector(2);
            Vector vectorC = new Vector(3, new double[] { 5, 6, 7, 8 });
            double number = 2;

            Console.WriteLine($"{vectorA} + {vectorC} = {Vector.Sum(vectorA, vectorC)}");
            Console.WriteLine($"{vectorA} - {vectorC} = {Vector.Sub(vectorA, vectorC)}");
            Console.WriteLine($"{vectorA} * {vectorB} = {Vector.ScalarMultiply(vectorA, vectorB)}");
            Console.WriteLine($"{vectorA} * {number} = {Mul(vectorA, number)}");
            Console.WriteLine($"-{vectorA} = {Reverse(vectorA)}");
            Console.WriteLine($"Length of {vectorA} = {vectorA.GetLength()}");
        }

        private static Vector Mul(Vector vector, double multiplier)
        {
            Vector result = new Vector(vector);
            result.Mul(multiplier);
            return result;
        }

        private static Vector Reverse(Vector vector)
        {
            Vector result = new Vector(vector);
            result.Reverse();
            return result;
        }
    }
}
