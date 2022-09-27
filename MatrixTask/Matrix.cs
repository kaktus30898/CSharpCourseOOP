using System.Text;
using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        private readonly Vector[] _components;

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
                throw new ArgumentOutOfRangeException(nameof(width), width, "Matrix width can't be less than 1");
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
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index can't be less than 0");
                }

                if (index >= _components.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index can't be more than or equal to size");
                }

                return _components[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index can't be less than 0");
                }

                if (index >= _components.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index can't be more than or equal to size");
                }

                if (value.Size != Width)
                {
                    throw new ArgumentException("The size of the vector must be equal to the width of the matrix", nameof(value));
                }

                _components[index] = new Vector(value);
            }
        }

        public Vector GetColumn(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index can't be less than 0");
            }

            if (index >= Width)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index can't be more than or equal to width");
            }

            Vector vector = new Vector(_components.Length);

            for (int i = 0; i < _components.Length; i++)
            {
                vector[i] = _components[i][index];
            }

            return vector;
        }

        public Matrix Transpose()
        {
            Matrix matrix = new Matrix(Width, _components.Length);

            for (int i = 0; i < _components.Length; i++)
            {
                matrix[i] = GetColumn(i);
            }

            return matrix;
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

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Matrix m = (Matrix)obj;

            if (_components.Length != m._components.Length || Width != m.Width)
            {
                return false;
            }

            for (int i = 0; i < _components.Length; i++)
            {
                if (!_components[i].Equals(m._components[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;

            foreach (var component in _components)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }

        public void Add(Matrix matrix)
        {
            if (Width != matrix.Width || _components.Length != matrix._components.Length)
            {
                throw new ArgumentException("Matrices must have the same height and width");
            }

            for (int i = 0; i < _components.Length; i++)
            {
                _components[i].Add(matrix._components[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (Width != matrix.Width || _components.Length != matrix._components.Length)
            {
                throw new ArgumentException("Matrices must have the same height and width");
            }

            for (int i = 0; i < _components.Length; i++)
            {
                _components[i].Subtract(matrix._components[i]);
            }
        }

        public void MultiplyByScalar(double multiplier)
        {
            foreach (var component in _components)
            {
                component.MultiplyByScalar(multiplier);
            }
        }

        public Matrix GetAlgebraicAddition(int row, int column)
        {
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(row), row, "Row can't be less than 0");
            }

            if (row >= _components.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(row), row, "Row can't be more than or equal to height");
            }

            if (column < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column), column, "Column can't be less than 0");
            }

            if (column >= Width)
            {
                throw new ArgumentOutOfRangeException(nameof(column), column, "Column can't be more than or equal to width");
            }

            Matrix matrix = new Matrix(_components.Length - 1, Width - 1);

            for (int targetRowIndex = 0; targetRowIndex < _components.Length - 1; targetRowIndex++)
            {
                int sourceRowIndex = targetRowIndex < row ? targetRowIndex : targetRowIndex + 1;

                for (int targetColumnIndex = 0; targetColumnIndex < Width - 1; targetColumnIndex++)
                {
                    int sourceColumnIndex = targetColumnIndex < column ? targetColumnIndex : targetColumnIndex + 1;
                    matrix[targetRowIndex][targetColumnIndex] = _components[sourceRowIndex][sourceColumnIndex];
                }
            }

            return matrix;
        }

        public double CalculateDeterminant()
        {
            if (_components.Length != Width)
            {
                throw new ArgumentException("The width of the matrix must be equal to its height");
            }

            if (_components.Length == 1)
            {
                return _components[0][0];
            }

            double determinant = 0;

            for (int i = 0; i < Width; i++)
            {
                double sign = i % 2 == 0 ? 1 : -1;
                determinant += sign * _components[0][i] * GetAlgebraicAddition(0, i).CalculateDeterminant();
            }

            return determinant;
        }

        public Vector MultiplicationByVector(Vector vector)
        {
            if (vector.Size != Width)
            {
                throw new ArgumentException("The width of the matrix must match the size of the vector.");
            }

            Vector resultVector = new Vector(vector.Size);

            for (int i = 0; i < Width; i++)
            {
                resultVector[i] = Vector.GetScalarMultiply(_components[i], vector);
            }

            return resultVector;
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

        /*  public static double GetScalarMultiply(Vector vector1, Vector vector2)
          {
              int size = Math.Min(vector1.Size, vector2.Size);
  
              double result = 0;
  
              for (int i = 0; i < size; i++)
              {
                  result += vector1._components[i] * vector2._components[i];
              }
  
              return result;
          }*/
    }
}