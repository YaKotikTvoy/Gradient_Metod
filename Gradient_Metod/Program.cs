using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gradient_Metod
{
	internal class Program
	{
		//f(X0) = Math.Pow(X1, 2) + Math.Pow(Math.E, Math.Pow(X1, 2) + Math.Pow(X2, 2)) + 4 * X1 + 3 * X2  X1^(2) + 2.718281828^(X1^(2) + X2^(2)) + 4 * X1 + 3 * X2                          X0 = [1,1]
		private static void Main(string[] args){
			Metod_Gradient(new double[] { 1,1}, 1E-6, 0.1);
			Console.ReadKey();
		}
		private static void Metod_Gradient(double []X0, double epsilome, double alpha) {
			double [] Xkn = new double[] { X0[0], X0[1] };
			Xkn[0] = X0[0] - df_dX1(X0[0], X0[1]) * alpha;
			Xkn[1] = X0[1] - df_dX2(X0[0], X0[1]) * alpha;


			for (int i = 0; Math.Abs(Xkn[0] - X0[0]) > epsilome && Math.Abs(Xkn[1] - X0[1]) > epsilome; i++) {
				/*if (Func(X0[0], X0[1]) > Func(X0[0] - df_dX1(X0[0], X0[1]) * alpha, X0[1] - df_dX2(X0[0], X0[1]) * alpha)){
					Xkn[0] = X0[0] - df_dX1(X0[0], X0[1]) * alpha;
					Xkn[1] = X0[1] - df_dX2(X0[0], X0[1]) * alpha;
				} else {
					double del = 1;
					double r_1 = 0;
					double r_2 = 0;
					double r1 = X0[0] - df_dX1(X0[0], X0[1]) * alpha / del;
					double r2 = X0[1] - df_dX2(X0[0], X0[1]) * alpha / del;
					while (Func(r1, r2) > Func(X0[0], X0[1])) {
						r_1 = Func(r1, r2);
						r_2 = Func(X0[0], X0[1]);
						del++;
						r1 = X0[0] - df_dX1(X0[0], X0[1]) * alpha / del;
						r2 = X0[1] - df_dX2(X0[0], X0[1]) * alpha / del;
					}
					Xkn[0] = r2;
					Xkn[1] = r1;
				}*/
				Xkn = Xk_Next(X0, alpha);
				X0 = new double[] { Xkn[0], Xkn[1] };
				Console.WriteLine($"Итерация {i + 1} : X1 = {Xkn[0]}, X2 = {Xkn[1]}.");
			}
			Console.WriteLine($"f({X0[0]}, {X0[1]}) = {Func(X0[0], X0[1])}");
		}
		private static double Func(double X1, double X2) {
			return Math.Pow(X1, 2) + Math.Pow(Math.E, Math.Pow(X1, 2) + Math.Pow(X2, 2)) + 4 * X1 + 3 * X2;
		}
		private double[] Gradient(double [] X0) {
			return new double[2] { -df_dX1( X0[0], X0[1]), -df_dX2(X0[1], X0[1]) };
		}
		private static double df_dX1(double X1, double X2) {
			return 2 * X1 + 2 * X1 * Math.Pow(Math.E, Math.Pow(X1, 2) + Math.Pow(X2, 2)) + 4;
		}
		private static double df_dX2(double X1, double X2) {
			return 2 * X2 * Math.Pow(Math.E, Math.Pow(X1, 2) + Math.Pow(X2, 2)) + 2 * X2 + 3;
		}
		private static double[] Xk_Next(double []X0, double alpha) {
			double[] Xkn = { 0, 0 };
			if (Func(X0[0], X0[1]) > Func(X0[0] - (df_dX1(X0[0], X0[1]) * alpha), X0[1] - df_dX2(X0[0], X0[1]) * alpha)){
				Xkn[0] = X0[0] - df_dX1(X0[0], X0[1]) * alpha;
				Xkn[1] = X0[1] - df_dX2(X0[0], X0[1]) * alpha;
			} else {
				double del = 1;
				double r_1 = 0;
				double r_2 = 0;
				double r1 = X0[0] - df_dX1(X0[0], X0[1]) * alpha / del;
				double r2 = X0[1] - df_dX2(X0[0], X0[1]) * alpha / del;
				while (Func(r1, r2) > Func(X0[0], X0[1])){
					r_1 = Func(r1, r2);
					r_2 = Func(X0[0], X0[1]);
					del++;
					r1 = X0[0] - df_dX1(X0[0], X0[1]) * alpha / del;
					r2 = X0[1] - df_dX2(X0[0], X0[1]) * alpha / del;
				}
				Xkn[0] = r1;
				Xkn[1] = r2;
			}
			return Xkn;
		}
	}
}