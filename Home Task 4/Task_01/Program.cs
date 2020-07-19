/*Задание 1.
Разработать абстрактный класс «Геометрическая Фигура» с методами «Площадь Фигуры» и «Периметр Фигуры».
Разработать классы-наследники: Треугольник, Квадрат,
Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг,
Эллипс.Реализовать конструкторы, которые однозначно
определяют объекты данных классов.
Реализовать класс «Составная Фигура», который
может состоять из любого количества «Геометрических
Фигур». Для данного класса определить метод нахождения
площади фигуры.Создать диаграмму взаимоотношений классов.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Task_01
{
    public abstract class GeometricFigure
    {
        public string _typeFigure;
        public GeometricFigure(string typeFigure)
        {
            _typeFigure = typeFigure;
        }
        public abstract double Area();
        public abstract double Perim();
        public override string ToString()
        {
            return $"\n\t\tТип фигуры: {_typeFigure} \nПерметр равен: {Perim()} \nПлощадь равна: {Area()}";
        }
    }
    class Circle : GeometricFigure
    {
        double _radius;
        public Circle (string typeFigure, double radius) : base(typeFigure)
        {
            _radius = radius;
        }
        public double getRadius(double rad) { return _radius = rad; }
        public void setRadius()
        {
            Write("\nВведите радиус окружности: ");
            double rad1 = Convert.ToDouble(ReadLine());
            getRadius(rad1);
        }
        public override double Perim()
        {
            return 2 * 3.1415 * _radius;
        }
        public override double Area()
        {
            return 3.1415 * _radius * _radius;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nРадиус {_typeFigure} равен {_radius}";
        }
    }
    class Ellips : GeometricFigure
    {
        double a, b;
        public Ellips (string typeFigure, double _a, double _b) : base(typeFigure)
        {
            a = _a;
            b = _b;
        }

        public override double Perim()
        {
            return 4*(3.1415*a*b + (a-b))/(a+b);
        }

        public override double Area()
        {
            return 3.1415*a*b;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nмалая полуось равена {(a<b?a:b)} \nбольшая полуось равна {(b>a?b:a)}";
        }
    }
    class Triangle : GeometricFigure
    {
        double a, b, c;
        public Triangle(string typeFigure, double _a, double _b, double _c) : base(typeFigure)
        {
            a = _a;
            b = _b;
            c = _c;
        }
        public override double Perim()
        {
            return a + b + c;
        }
        public override double Area()
        {
            double p = 0.5 * (a + b + c);
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }
        public override string ToString()
        {
            return base.ToString() + $"\nСтороны треугольника равны А = {a}, B = {b}, C = {c}";
        }
    }
    class Square : GeometricFigure
    {
        double a;
        public Square(string typeFigure, double _a) : base(typeFigure)
        {
            a = _a;
        }
        public override double Perim()
        {
            return 4 * a;
        }
        public override double Area()
        {
            return a * a;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nСторона квадрата равна А = {a}";
        }
    }
    class Rhombus : GeometricFigure
    {
        double a, h;
        public Rhombus(string typeFigure, double _a, double _h) : base(typeFigure)
        {
            a = _a;
            h = _h;
        }
        public override double Perim()
        {
            return 4 * a;
        }
        public override double Area()
        {
            return a * h;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nДлина основания ромба А = {a}, длина высоты ромба Н = {h}";
        }
    }
    class Rectangle : GeometricFigure
    {
        double a, b;
        public Rectangle(string typeFigure, double _a, double _b) : base(typeFigure)
        {
            a = _a;
            b = _b;
        }
        public override double Perim()
        {
            return 2 * (a + b);
        }
        public override double Area()
        {
            return a * b;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nДлина основания прямоугольника А = {a}, длина высоты прямоугольника В = {b}";
        }
    }
    class Parallelogram : GeometricFigure
    {
        double a, b, h;
        public Parallelogram(string typeFigure, double _a, double _b, double _h) : base(typeFigure)
        {
            a = _a;
            b = _b;
            h = _h;
        }
        public override double Perim()
        {
            return 2 * (a + b);
        }
        public override double Area()
        {
            return a * h;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nДлина основания параллелограмма А = {a}, длина высоты параллелограмма h = {h}";
        }
    }
    class Trapezoid : GeometricFigure
    {
        double a, b, c1, c2, h;
        public Trapezoid(string typeFigure, double _a, double _b, double _c1, double _c2, double _h) : base(typeFigure)
        {
            a = _a;
            b = _b;
            c1 = _c1;
            c2 = _c2;
            h = _h;
        }
        public override double Perim()
        {
            return a + b + c1 + c2;
        }
        public override double Area()
        {
            return 0.5 * (a + b) * h;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nОснование трапеции А = {a}, длина высоты трапеции h = {h}";
        }
    }
    class SostavFigure : GeometricFigure
    {
        public SostavFigure(string typeFigure) : base(typeFigure)
        {
        }
        public double allArea = 0;
        public override double Perim()
        {
            throw new NotImplementedException();
        }
        public override double Area()
        {
            throw new NotImplementedException();
        }
        public double sostavArea(GeometricFigure[] fig)
        {
            foreach (GeometricFigure item in fig)
            {
                allArea += item.Area();
            }
            return allArea;
        }
        public void Show()
        {
            WriteLine($"\nОбщая площадь {_typeFigure} равна {allArea}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //можно раскомментировать добавленные фигуры или добавить новые в масссив
            //тем самым будет меняться Площадь Составной фигуры
            GeometricFigure[] figures =
            {
                //new Circle("ОКРУЖНОСТЬ", 17),
                //new Ellips("ЭЛЛИПС", 24, 17.5),
                //new Triangle("ТРЕУГОЛЬНИК", 3, 4, 5),
                //new Square ("КВАДРАТ", 11),
                //new Rhombus ("РОМБ", 17, 4),
                new Rectangle ("ПРЯМОУГОЛЬНИК", 7, 12),
                new Parallelogram ("ПАРАЛЛЕЛОГРАММ", 14.5, 12.5, 8),
                new Trapezoid ("ТРАПЕЦИЯ", 18, 10, 11, 12, 8),
            };

            foreach (GeometricFigure item in figures)
            {
                WriteLine(item);
                item.Perim();
                item.Area();
            }

            SostavFigure obj = new SostavFigure("Составная Фигура");
            obj.sostavArea(figures);
            obj.Show();

            //Circle circle1 = new Circle("OKRUG", 0);
            //circle1.setRadius();
            //WriteLine(circle1);
            //circle1.Perim();
            //circle1.Area();
            
            ReadKey();
        }
    }
}
