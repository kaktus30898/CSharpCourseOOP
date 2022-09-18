namespace VectorTask
{
    public class Program
    {
        static void Main()
        {
            Vector vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            Vector vector2 = new Vector(2);
            Vector vector3 = new Vector(3, new double[] { 5, 6, 7, 8 });
            double number = 2;

            Console.WriteLine($"{vector1} + {vector3} = {Vector.GetSum(vector1, vector3)}");
            Console.WriteLine($"{vector1} - {vector3} = {Vector.GetDifference(vector1, vector3)}");
            Console.WriteLine($"{vector1} * {vector2} = {Vector.GetScalarMultiply(vector1, vector2)}");
            Console.WriteLine($"{vector1} * {number} = {MultiplyVectorByScalar(vector1, number)}");
            Console.WriteLine($"-{vector1} = {ReverseVector(vector1)}");
            Console.WriteLine($"Length of {vector1} = {vector1.Length}");
        }

        private static Vector MultiplyVectorByScalar(Vector vector, double multiplier)
        {
            Vector result = new Vector(vector);
            result.MultiplyByScalar(multiplier);
            return result;
        }

        private static Vector ReverseVector(Vector vector)
        {
            Vector result = new Vector(vector);
            result.Reverse();
            return result;
        }
    }
}
