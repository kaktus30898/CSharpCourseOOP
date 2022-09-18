using System.Text;
using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        private Vector[] _components;

        public int Height => _components.Length;

        public int Width { get; }

        public Matrix(double[,] components)
        {
            if (components is null)
            {
                throw new ArgumentNullException(nameof(components), "Array can't be null");
            }

            int height = components.GetLength(0);
            int width = components.GetLength(1);

            if (height == 0 || width == 0)
            {
                throw new ArgumentException("Width or height cannot be equal to 0", nameof(components));
            }

            _components = new Vector[height];
            Width = width;

            for (int i = 0; i < height; i++)
            {
                _components[i] = new Vector(width);

                for (int j = 0; j < width; j++)
                {
                    _components[i][j] = components[i, j];
                }
            }
        }

        public Matrix(int height, int width)
        {
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "Matrix height can't be less than 1");
            }

            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width,"Matrix width can't be less than 1");
            }

            _components = new Vector[height];
            Width = width;

            for (int i = 0; i < height; i++)
            {
                _components[i] = new Vector(width);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix can't be null");
            }

            _components = new Vector[matrix._components.Length];
            Width = matrix.Width;

            for (int i = 0; i < matrix._components.Length; i++)
            {
                _components[i] = new Vector(matrix._components[i]);
            }
        }

        public Matrix(Vector[] components)
        {
            if (components is null)
            {
                throw new ArgumentNullException(nameof(components), "Array can't be null");
            }

            if (components.Length == 0)
            {
                throw new ArgumentException("Array can't be empty", nameof(components));
            }

            _components = new Vector[components.Length];
            Width = components[0].Size;

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i].Size != Width)
                {
                    throw new ArgumentException("All vectors must have the same size", nameof(components));
                }
                
                _components[i] = new Vector(components[i]);
            }
        }

        public Vector this[int index]
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
                
                // TODO проверить что value.Size == Width

                _components[index] = new Vector(value);
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
