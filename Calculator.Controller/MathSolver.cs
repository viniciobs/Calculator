using CalculatorEntities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Calculator.Controller
{
	#region Documentation

	/// <summary>
	/// Classe contendo as implementações das operações matemáticas necessárias para funcionamento da calculadora.
	/// </summary>

	#endregion Documentation

	public static class MathSolver
	{
		#region Fileds

		private static List<decimal> values = new List<decimal>();

		#endregion Fileds

		#region Methods

		private static decimal Sum(List<decimal> values)
		{
			return values.Sum();
		}

		private static decimal Subtract(List<decimal> values)
		{
			return values[0] - values[1];
		}

		private static decimal Multiply(List<decimal> values)
		{
			return values[0] * values[1];
		}

		private static decimal Divide(List<decimal> values)
		{
			return values[0] / values[1];
		}

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

		private static decimal Squirt(List<decimal> values)
		{
			var pow = values.Count == 2 ? values[1] : 2;
			var result = Math.Pow((double)values[0], 1 / (double)pow);
			return (decimal)result;
		}

		public static decimal? Calculate(string Operation)
		{
			var operationType = GetTypeOf(Operation);
			decimal? result = null;
			SetValues(Operation);

			switch (operationType)
			{
				case OperationMembers.Sum:
					result = Sum(values);
					break;

				case OperationMembers.Subtract:
					result = Subtract(values);
					break;

				case OperationMembers.Multiply:
					result = Multiply(values);
					break;

				case OperationMembers.Divide:
					result = Divide(values);
					break;

				case OperationMembers.Squirt:
					result = (decimal)Squirt(values);
					break;
			}

			return result;
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

		private static void SetValues(string Operation)
		{
			if (values.Any()) values.Clear();

			var pattern = @"([\d\.]*)";
			var matches = Regex.Matches(Operation, pattern);

			foreach (Match match in matches)
			{
				if (match.ToString().Length > 0)
				{
					values.Add(Convert.ToDecimal(match.Value));
				}
			}
		}

		#endregion Methods
	}
}