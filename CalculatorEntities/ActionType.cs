namespace CalculatorEntities
{
    public enum ActionType
    {
        /// <summary>
        /// Nova Operação.
        /// </summary>
        New = 0,

        /// <summary>
        /// Resetar a caixa de texto.
        /// </summary>
        Reset = 1,

        /// <summary>
        /// Concatenar o valor do último membro clicado à caixa de texto.
        /// </summary>
        Concat = 2,

        /// <summary>
        /// A caixa de texto conterá o resultado de uma operação.
        /// </summary>
        ShowResult = 3
    }
}