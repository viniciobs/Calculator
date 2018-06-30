using CalculatorEntities;
using System;
using System.Text.RegularExpressions;

namespace Calculator.Controller
{
	#region Documentation

	/// <summary>
	/// Classe contendo as implementações das operações matemáticas necessárias para funcionamento da calculadora.
	/// </summary>

	#endregion Documentation

	public static class MathSolver
	{
		private static object MessageBox;

		#region Methods

		#region Documentation

		/// <summary>
		/// Calcula a raíz do valor recebido.
		/// Para o cálculo foi usado o método Pow da Classe Math.
		/// Raíz n de x é o mesmo que x elevado ao inverso de n.
		/// Ex.: raíz cúbica de x é o mesmo que x elevado a 1/3.
		/// </summary>
		/// <param name="value">Radicando da operação.</param>
		/// <param name="pow">Índice da raíz, caso não informado será considerado 2 (raíz quadrada).</param>
		/// <returns>O resultado da operação de radiciação.</returns>

		#endregion Documentation

		private static double Squirt(Double value, Double pow = 2D)
		{
			return Math.Pow(value, 1 / pow);
		}

		#region Statics

		public static decimal? Calculate(string Operation)
		{
			var operationType = GetTypeOf(Operation);

			if (operationType == null) return null;

			return 123M;
		}

		#region Documentation

		/// <summary>
		/// Verifica o tipo de operação a ser calculada.
		/// </summary>
		/// <param name="Operation">A operação escrita no <see cref="labelHolder/"></param>
		/// <returns>O tipo de operação a ser executada.</returns>

		#endregion Documentation

		private static OperationMembers? GetTypeOf(string Operation)
		{
			var pattern = @"[^\d\.\s]";
			var match = Regex.Match(Operation, pattern);

			if (match.Success)
			{
				var operationType = match.ToString()[0];

				if (operationType == (char)OperationMembers.Sum) return OperationMembers.Sum;
				if (operationType == (char)OperationMembers.Subtract) return OperationMembers.Subtract;
				if (operationType == (char)OperationMembers.Divide) return OperationMembers.Divide;
				if (operationType == (char)OperationMembers.Multiply) return OperationMembers.Multiply;
				if (operationType == (char)OperationMembers.Squirt) return OperationMembers.Squirt;
			}

			return null;
		}

		#endregion Statics

		#endregion Methods
	}
}