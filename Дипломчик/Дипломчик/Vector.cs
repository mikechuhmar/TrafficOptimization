using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public delegate double Function(Vector x);
    public class Vector : IEnumerable
    {
        public List<double> elements;
        public double this[int i]
        {
            get
            {
                return elements[i];
            }
            set
            {
                elements[i] = value;
            }
        }
        public void Add(double d)
        {
            elements.Add(d);
        }
        public int Count
        {
            get
            {
                return elements.Count;
            }
        }

        public Vector(List<double> elements)
        {
            this.elements = elements;
        }
        public Vector()
        {
            elements = new List<double>();
        }
        public Vector(Vector vector, double d)
        {
            elements = new List<double>();
            foreach (var var in vector.elements)
            {
                elements.Add(var * d);
            }
        }
        public Vector(Vector vector)
        {
            elements = new List<double>();
            foreach (var var in vector.elements)
            {
                elements.Add(var);
            }
        }
        public Vector(byte[] array, int stride)
        {
            elements = new List<double>();
            for (int i = 0; i < array.Length; i += stride)
            {
                if (array[i] < 128 && array[i + 1] < 128 && array[i + 2] < 128)
                    elements.Add(1);
                else
                    elements.Add(-1);
            }

        }
        public override string ToString()
        {
            string str = "";
            foreach (var element in elements)
            {
                str += element.ToString() + " ";
            }
            return str;
        }
        public Vector InnerProduct(Vector vector)
        {
            List<double> answerElements = new List<double>(vector.Count);

            for (int i = 0; i < this.Count; i++)
            {
                answerElements.Add(this[i] * vector[i]);
            }
            return new Vector(answerElements);
        }
        public double Sum()
        {
            return elements.Sum();
        }
        public bool IsEquivalent(Vector vector)
        {
            bool var = true;
            for (int i = 0; i < vector.Count; i++)
            {
                if (this[i] != vector[i])
                {
                    var = false;
                    break;
                }

            }
            return var;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)elements).GetEnumerator();
        }
    }
}
