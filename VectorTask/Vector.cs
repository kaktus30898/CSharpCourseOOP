using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] _components;

        public Vector(double[] components)
        {
            if (components is null)
            {
                throw new ArgumentNullException(nameof(components), "Array can't be null");
            }

            if (components.Length == 0)
            {
                throw new ArgumentException("Array can't be empty", nameof(components));
            }

            _components = components.ToArray();
        }

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size,"Size can't be less than 1");
            }

            _components = new double[size];
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "Source can't be null");
            }

            _components = vector._components.ToArray();
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Array size can't be less than 1");
            }

            _components = new double[size];
            Array.Copy(components, _components, Math.Min(size, components.Length));
        }

        public int Size => _components.Length;

        public double Length
        {
            get
            {
                double sum = 0;

                foreach (var component in _components)
                {
                    sum += component * component;
                }

                return Math.Sqrt(sum);
            }
        }
        
        public double this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new  ArgumentOutOfRangeException(nameof(index), index,"Index can't be less than 0");
                }
            
                if (index >= _components.Length)
                {
                    throw new  ArgumentOutOfRangeException(nameof(index), index,"Index can't be more than or equal to size");
                }
            
                return _components[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new  ArgumentOutOfRangeException(nameof(index), index,"Index can't be less than 0");
                }
            
                if (index >= _components.Length)
                {
                    throw new  ArgumentOutOfRangeException(nameof(index), index,"Index can't be more than or equal to size");
                }
            
                _components[index] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('{');

            foreach (var component in _components)
            {
                stringBuilder.Append(component);
                stringBuilder.Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append('}');
            return stringBuilder.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is not Vector v)
            {
                return false;
            }

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

            foreach (var component in _components)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }

        private void ExtendIfNeeded(int neededSize)
        {
            if (neededSize <= Size)
            {
                return;
            }
            
            Array.Resize(ref _components, neededSize);
        }

        public void Add(Vector vector)
        {
            int otherVectorSize = vector.Size;
            ExtendIfNeeded(otherVectorSize);

            for (int i = 0; i < otherVectorSize; i++)
            {
                _components[i] += vector._components[i];
            }
        }

        public void Subtract(Vector otherVector)
        {
            int otherVectorSize = otherVector.Size;
            ExtendIfNeeded(otherVectorSize);

            for (int i = 0; i < otherVectorSize; i++)
            {
                _components[i] -= otherVector._components[i];
            }
        }

        public void MultiplyByScalar(double multiplier)
        {
            for (int i = 0; i < _components.Length; i++)
            {
                _components[i] *= multiplier;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            result.Add(vector2);
            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            result.Subtract(vector2);
            return result;
        }

        public static double GetScalarMultiply(Vector vector1, Vector vector2)
        {
            int size = Math.Min(vector1.Size, vector2.Size);

            double result = 0;

            for (int i = 0; i < size; i++)
            {
                result += vector1._components[i] * vector2._components[i];
            }

            return result;
        }
    }
}