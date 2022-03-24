// See https://aka.ms/new-console-template for more information

namespace ClassLibrary
{
    public class Class1
    {
        public static void Main()
        {
            Console.WriteLine("Podaj 3 liczby: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Class1 klasa = new Class1();
            double result0 = klasa.Add(a,b,c);
            double result1 = klasa.Sub(a,b,c); 
            double result2 = klasa.Mult(a,b,c);
            double result3 = klasa.Div(a,b,c);
            Console.WriteLine("Dodawanie:");
            Console.WriteLine(result0);
            Console.WriteLine("Odejmowanie:");
            Console.WriteLine(result1);
            Console.WriteLine("Mnożenie:");
            Console.WriteLine(result2);
            Console.WriteLine("Dzielenie:");
            Console.WriteLine(result3);
        }

        public double Add(double a, double b, double c) { return a + b + c; }  
        public double Sub(double a, double b, double c) { return a - b - c; }   
        public double Mult(double a, double b, double c) { return a * b * c; }
        public double Div(double a, double b, double c) { return a / b / c; }
    }
}