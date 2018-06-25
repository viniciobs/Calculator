using System;
using System.Collections.Generic;

namespace Calculator.Controller
{
	public class EnumHelper
	{
		#region Documentation

		/// <summary>
		/// Retorna uma lista contendo todos os itens do tEnum convertidos para o tipo T.
		/// </summary>
		/// <typeparam name="T">Tipo da lista que será retornada.</typeparam>
		/// <param name="tEnum">O enum que contém os itens que serão retornados.</param>
		/// <returns>Lista contendo os itens do enum.</returns>

		#endregion Documentation

		public static List<T> EnumAsArray<T>(Enum tEnum)
		{
			List<T> response = new List<T>();

			foreach (var item in Enum.GetValues(tEnum))
			{
				//response.Add(item.ToString());
			}

			return response;
		}
	}
}