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
		//f(X0) = Math.Pow(X1, 2) + Math.Pow(Math.E, Math.Pow(X1, 2) + Math.Pow(X2, 2)) + 4 * X1 + 3 * X2                             X0 = [1,1]
		private static void Main(string[] args){
			Metod_Gradient(new double[] { 10,10}, 1E-6, 0.1);
			Console.ReadKey();
		}
		private static void Metod_Gradient(double []X0, double epsilome, double alpha) {
			double [] Xkn = new double[] { X0[0], X0[1] };
			Xkn[0] = X0[0] - df_dX1(X0[0], X0[1]) * alpha;
			Xkn[1] = X0[1] - df_dX2(X0[0], X0[1]) * alpha;


			for (int i = 0; Math.Abs(Xkn[0] - X0[0]) > epsilome && Math.Abs(Xkn[1] - X0[1]) > epsilome; i++) {
				if (Func(X0[0], X0[1]) > Func(X0[0] - df_dX1(X0[0], X0[1]) * alpha, X0[1] - df_dX2(X0[0], X0[1]) * alpha)){
					Xkn[0] = X0[0] - df_dX1(X0[0], X0[1]) * alpha;
					Xkn[1] = X0[1] - df_dX2(X0[0], X0[1]) * alpha;
				} else {
					double del = 1;
					while (Func(X0[0] - df_dX1(X0[0], X0[1]) * alpha / del, X0[1] - df_dX1(X0[0], X0[1]) * alpha / del) > Func(X0[0], X0[0])) del++;
					Xkn[0] = X0[0] - df_dX1(X0[0], X0[1]) * alpha / del;
					Xkn[1] = X0[1] - df_dX2(X0[0], X0[1]) * alpha / del;
				}
				Console.WriteLine($"Итерация {i + 1} : X1 = {Xkn[0]}, X2 = {Xkn[1]}.");
				X0[0] = Xkn[0];
				X0[1] = Xkn[1];
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
	}
}
