using System.Collections.Generic;

namespace OptimizationSystem{
    public class Vector
    {
        //Крмпоненты вектора
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
        //Количество компонент
        public int Count
        {
            get
            {
                return elements.Count;
            }
        }
        //Конструкторы
        public Vector()
        {
            elements = new List<double>();
        }
        public Vector(int amount)
        {
            elements = new List<double>(amount);
            for (int i =0; i < amount; i++)
            {
                elements.Add(0);
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
        //Вывод вектора
        public override string ToString()
        {
            string str = "";
            foreach (var element in elements)
            {
                str += (element - element % 1).ToString() + "    ";
            }
            return str;
        }
    }
}
