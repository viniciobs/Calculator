using System;

namespace Calculator.Controller
{
    #region Documentation

    /// <summary>
    /// Classe contendo as implementações das operações matemáticas necessárias para funcionamento da calculadora.
    /// </summary>

    #endregion Documentation

    public class MathSolver
    {
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

        private double Squirt(Double value, Double pow = 2D)
        {
            return Math.Pow(value, 1 / pow);
        }

        #region Statics

        public static string Calculate(string Operation)
        {
            return "Your ass!";
        }

        #endregion Statics

        #endregion Methods
    }
}