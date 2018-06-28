using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Controller
{
	public static class EnumHelper
	{
		#region Documentation

		/// <summary>
		/// Pega os itens do Enum T e retorna seus itens.
		/// </summary>
		/// <typeparam name="T">Enum que contém os itens que serão retornados.</typeparam>
		/// <returns>Todos os itens do Enum.</returns>

		#endregion Documentation

		public static char[] GetValues<T>()
		{
			return Enum.GetValues(typeof(T))
				.Cast<int>()
				.Select(x => (char)x)
				.ToArray()
			;
		}
	}
}