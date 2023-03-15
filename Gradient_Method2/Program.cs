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

		}
		private static double x1_next(double x1) { 
			
		}
		private static double x2_next(double x2, double alpha) { 
			double alpha
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
