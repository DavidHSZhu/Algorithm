using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtown
{
    class Program
    {     // declare a delegate for a function in one variable
        public delegate double F_x_(double x);
        static void Main(string[] args)
        {
            double xstart = 5;
            NewtonRaphson(xstart, new F_x_(Poly), new F_x_(DevPoly));

            Console.ReadKey();

        }
        /// <summary>
        /// Print a table of calculated values given a start value,
        /// a non linear function and its derivative.
        /// Show a root if possible and often depending on the starting value.
        /// </summary>
        /// <param name="startvalue">value to start the iteration</param>
        /// <param name="XFunc">A non linear function</param>
        /// <param name="DevXFunc">The derivative function of XFunc</param>
        /// <return>output to the console</return>
        static void NewtonRaphson(double startvalue, F_x_ XFunc, F_x_ DevXFunc)
        {
            const int cMaxIterations = 25;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(79, 30); //pos 80 for cr

            double Xn, Xn1 = 0.0;
            string Title = "NEWTON-RAPHSON";
            Title = Title.PadRight(Console.WindowWidth);
            Console.WriteLine(Title);
            string linestr = string.Empty;
            linestr = linestr.PadRight(Console.WindowWidth, '-');
            Console.WriteLine(linestr);
            Console.WriteLine("| {0,-15}| {1,-15} | {2,-15} | {3,-15} |       ", "Iteration", "x", "f(x)", "f'(x)");
            Console.WriteLine(linestr);
            Console.WriteLine("|     {0,-10} | {1,15:0.00000} | {2,15:0.00000} | {3,15:0.00000} |       ", 0, startvalue, XFunc(startvalue), DevXFunc(startvalue));
            Xn = startvalue;
            for (int iter = 1; iter < cMaxIterations; iter++)
            {
                Xn1 = Xn - XFunc(Xn) / DevXFunc(Xn); // calculate iteration
                Console.WriteLine("|     {0,-10} | {1,15:0.00000} | {2,15:0.00000} | {3,15:0.00000} |       ", iter, Xn1, XFunc(Xn1), DevXFunc(Xn1));
                if (Math.Abs(Xn - Xn1) < 0.0000001)
                {
                    Console.WriteLine(linestr);
                    Console.WriteLine("Root = {0,15:0.00000}".PadRight(Console.WindowWidth), Xn1);
                    break;
                }
                else
                {
                    Xn = Xn1;
                }
            }
            Console.ResetColor();
        }
        static double Poly(double x)
        {
            //define a non linear function in x
            return x * x * x - 5.0 * x + 5.0;
        }
        static double DevPoly(double x)
        {
            //define the derivative of the above  non linear function
            return 3.0 * x * x - 5.0;
        }
    }
}
