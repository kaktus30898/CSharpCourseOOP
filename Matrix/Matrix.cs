using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorTask;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] _components;

        public Matrix(double[] components)
        {
            if (components is null || components.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            _components = components;
        }

        public Matrix(int height, int width)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Matrix height can't be less than 1");
            }

            if (width <= 0)
            {
                throw new ArgumentException("Matrix width can't be less than 1");
            }

            _components = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                _components[i] = new Vector(width);
            }
        }

        public Matrix(Matrix source)
        {
            if (source is null)
            {
                throw new ArgumentException(nameof(source), "Source can't be null");
            }

            

            _components = source._components.ToArray();
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Array size can't be less than 1");
            }

            _components = new double[size];

            for (int i = 0; i < size && i < components.Length; i++)
            {
                _components[i] = components[i];
            }
        }

        public int GetSize()
        {
            return _components.Length;
        }

        public double GetLength()
        {
            double result = 0;

            for (int i = 0; i < _components.Length; i++)
            {
                result += _components[i] * _components[i];
            }

            return Math.Sqrt(result);
        }

        public double GetComponent(int index)
        {
            if (index >= _components.Length)
            {
                return 0;
            }

            return _components[index];
        }

        public void SetComponent(int index, double value)
        {
            ExtendIfNeeded(index + 1);
            _components[index] = value;
        }

        public override string ToString()
        {
            StringBuilder vectorInfo = new StringBuilder();
            vectorInfo.Append("{");

            for (int i = 0; i < _components.Length; i++)
            {
                vectorInfo.Append(_components[i].ToString());
                vectorInfo.Append(", ");
            }

            vectorInfo.Remove(vectorInfo.Length - 2, 2);
            vectorInfo.Append("}");
            return vectorInfo.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Vector v = (Vector)obj;

            if (_components.Length != v._components.Length)
            {
                return false;
            }

            for (int i = 0; i < _components.Length; i++)
            {
                if (_components[i] != v._components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;
            hash = prime * hash + _components.Length;

            for (int i = 0; i < _components.Length; i++)
            {
                hash = prime * hash + _components[i].GetHashCode();
            }

            return hash;
        }

        private void ExtendIfNeeded(int neededSize)
        {
            if (neededSize <= GetSize())
            {
                return;
            }

            double[] oldComponents = _components;
            _components = new double[neededSize];

            for (int i = 0; i < oldComponents.Length; i++)
            {
                _components[i] = oldComponents[i];
            }
        }

        public void Add(Vector otherVector)
        {
            int otherVectorSize = otherVector.GetSize();
            ExtendIfNeeded(otherVectorSize);

            for (int i = 0; i < otherVectorSize; i++)
            {
                _components[i] += otherVector._components[i];
            }
        }

        public void Sub(Vector otherVector)
        {
            int otherVectorSize = otherVector.GetSize();
            ExtendIfNeeded(otherVectorSize);

            for (int i = 0; i < otherVectorSize; i++)
            {
                _components[i] -= otherVector._components[i];
            }
        }

        public void Mul(double multiplier)
        {
            for (int i = 0; i < _components.Length; i++)
            {
                _components[i] *= multiplier;
            }
        }

        public void Reverse()
        {
            Mul(-1);
        }

        public static Vector Sum(Vector a, Vector b)
        {
            int size = Math.Max(a.GetSize(), b.GetSize());
            Vector result = new Vector(size);
            result.Add(a);
            result.Add(b);
            return result;
        }

        public static Vector Sub(Vector a, Vector b)
        {
            int size = Math.Max(a.GetSize(), b.GetSize());
            Vector result = new Vector(size);
            result.Add(a);
            result.Sub(b);
            return result;
        }

        public static double ScalarMultiply(Vector a, Vector b)
        {
            int size = Math.Max(a.GetSize(), b.GetSize());

            double result = 0;

            for (int i = 0; i < size; i++)
            {
                result += a.GetComponent(i) * b.GetComponent(i);
            }

            return result;
        }
    }
}
