using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradient_Method2
{
	internal class Program
	{
		static void Main(string[] args){
			double[]X1_2 = Gradient_Method(1,1, 0.1, 1E-6);
			Console.WriteLine($"f({X1_2[0]}, {X1_2[1]}) = {f(X1_2[0], X1_2[1])}.");
		}
		private static double[] Gradient_Method(double x1, double x2, double alpha, double epsilome) {
			double Xk1 = x1_next(x1, x2, ref alpha);
			double Xk2 = x2_next(x1, x2, ref alpha);
			for (int i = 0; Math.Abs(f(x1, x2) - f(x1 - df_dx2(x1, x2) * alpha, x2 - df_dx2(x1, x2) * alpha)) > epsilome; i++){
				Xk1 = x1_next(x1, x2, ref alpha);
				Xk2 = x2_next(x1, x2, ref alpha);
				x1 = Xk1;
				x2 = Xk2;
				Console.WriteLine($"Итерация {i + 1}: x1 = {x1}, x2 = {x2} f({x1}, {x2}) = {f(x1,x2)}.");
			}
			return new double[] {Xk1, Xk2};
		}
		private static double x1_next(double x1, double x2, ref double alpha) {
			/*while (f(x1, x2) > f(x1 - df_dx2(x1, x2) * alpha, x2 - df_dx2(x1, x2) * alpha)) alpha *= 0.5;
			return x1 - df_dx2(x1, x2) * alpha;*/
			//double f_n = f(x1, x2);
			//double fn = f(x1 - df_dx1(x1, x2) * alpha, x2 - df_dx2(x1, x2) * alpha);
			while (f(x1, x2) < f(x1 - df_dx1(x1, x2) * alpha, x2 - df_dx2(x1, x2) * alpha)) alpha *= 0.5;
			return x1 - df_dx2(x1, x2) * alpha;
		}
		private static double x2_next(double x1, double x2, ref double alpha) {
			while (f(x1, x2) < f(x1 - df_dx1(x1, x2) * alpha, x2 - df_dx2(x1, x2) * alpha)) alpha *= 0.5;
			return x2 - df_dx2(x1, x2) * alpha;
		}
		private static double f(double x1, double x2) {
			return Math.Pow(x1, 2) + Math.Pow(Math.E, Math.Pow(x1, 2) + Math.Pow(x2, 2)) + 4 * x1 + 3 * x2;
		}
		private static double df_dx1(double x1, double x2) {
			return 2 * x1 + 2 * Math.Pow(Math.E, Math.Pow(x1, 2) + Math.Pow(x2, 2)) + 4;
		}
		private static double df_dx2(double x1, double x2) {
			return 2 * x2 * Math.Pow(Math.E, Math.Pow(x1, 2) + Math.Pow(x2, 2)) + 2 * x2 + 3;
		}
	}
}
