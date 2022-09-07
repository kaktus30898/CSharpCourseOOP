using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    public class Vector
    {
        private double[] _components;

        public Vector(double[] components)
        {
            _components = components;
        }

        public Vector(int size)
        {
            _components = new double[size];
        }

        public Vector(Vector vector) : this(vector._components.ToArray())
        {
        }

        public Vector(int size, double[] components)
        {
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

        private int ExtendIfNeeded(int neededSize)
        {
            int size = GetSize();

            if (neededSize <= size)
            {
                return size;
            }

            double[] oldComponents = _components;
            _components = new double[neededSize];

            for (int i = 0; i < oldComponents.Length; i++)
            {
                _components[i] = oldComponents[i];
            }

            return neededSize;
        }

        public void Add(Vector otherVector)
        {
            int otherVectorSize = otherVector.GetSize();
            int size = ExtendIfNeeded(otherVectorSize);

            for (int i = 0; i < size && i < otherVectorSize; i++)
            {
                _components[i] += otherVector._components[i];
            }
        }

        public void Sub(Vector otherVector)
        {
            int otherVectorSize = otherVector.GetSize();
            int size = ExtendIfNeeded(otherVectorSize);

            for (int i = 0; i < size && i < otherVectorSize; i++)
            {
                _components[i] -= otherVector._components[i];
            }
        }
    }
}
