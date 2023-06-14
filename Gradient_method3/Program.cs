using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradient_method3
{
	internal class Program
	{
		static void Main(string[] args){
			double[] Xmin = Gradient_const_step(1, 1, 0.1, 1E-6);
			Console.WriteLine($"x1 = {Xmin[0]}, x2 = {Xmin[1]} f({Xmin[0]},{Xmin[1]}) = {f(Xmin[0], Xmin[1])}");
			Console.ReadKey();
		}
		private static double[] Gradient_const_step(double x1, double x2, double alpha, double epsilome) {
			double Xk1 = x1_next(x1, x2, alpha);
			double Xk2 = x2_next(x1, x2, alpha);
			for (int i = 0; Math.Abs(f(Xk1, Xk2) - f(x1, x2)) > epsilome; i++ ) {
				x1 = Xk1;
				x2 = Xk2;
				Xk1 = x1_next(x1, x2, alpha);
				Xk2 = x2_next(x1, x2, alpha);
				while (f(Xk1, Xk2) >= f(x1, x2)) {
					alpha *= 0.5;
					Xk1 = x1_next(x1, x2, alpha);
					Xk2 = x2_next(x1, x2, alpha);

				}
				Console.WriteLine($"Итерация {i + 1}.X1n = {Xk1}, X2n = {Xk2}, f({Xk1}, {Xk2}) = {f(Xk1, Xk2)}, f(X1n-1, X2n-1) = {f(Xk1, Xk2)}.");
			}
			return new double []{ Xk1, Xk2};
		}
		private static double x1_next(double x1, double x2, double alpha) {
			//while (f(x1 - df_x1(x1, x2) * alpha, x2 - df_x2(x1, x2) * alpha) > f(x1,x2) ) alpha *= 0.5;
			return x1 - df_x1(x1, x2) * alpha;	
		}
		private static double x2_next(double x1, double x2, double alpha) {
			//while (f(x1 - df_x1(x1, x2) * alpha, x2 - df_x2(x1, x2) * alpha) > f(x1, x2)) alpha *= 0.5;
			return x2 - df_x2(x1, x2) * alpha;
		}
		private static double f(double x1, double x2) {
			return Math.Pow(x1, 2) + Math.Pow(Math.E, Math.Pow(x1, 2) + Math.Pow(x2, 2)) + 4 * x1 + 3 * x2;
		}
		private static double df_x1(double x1, double x2) {
			return 2 * x1;
		}
		private static double df_x2(double x1, double x2) {
			return 2 * x2;
		}
	}
}
