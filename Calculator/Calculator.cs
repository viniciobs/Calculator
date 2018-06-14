using System;
using System.Windows.Forms;

namespace Calculator
{
    #region Documentation

    /// <summary>
    /// Formuláio principal contendo as funcionalidades da calculadora.
    /// Nesse código, os botões da calculadora são chamados de membros.
    /// </summary>

    #endregion Documentation

    public partial class FormMain : Form
    {
        #region Properties

        #region Documentation

        /// <summary>
        /// Contém o valor do último membro clicado na calculadora.
        /// </summary>

        #endregion Documentation

        private Button lastClickedMember { get; set; }

        #endregion Properties

        #region Constructor

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        #region Numerical Members Click

        private void buttonZero_Click(object sender, System.EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
            UpdateTextBoxMain();
        }

        #endregion Numerical Members Click

        #region Operation Members Click

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            lastClickedMember = (Button)sender;
        }

        #endregion Operation Members Click

        #region Documentation

        /// <summary>
        /// Atualiza a caixa de texto principal.
        /// Esse método deve ser chamado quando membros do tipo numérico forem clicados.
        /// Caso a caixa de texto esteja vazia (valor zero), o valor do membro clicado será o texto exibido na caixa,
        /// caso contrário (valor diferente de zero), o valor do membro clicado será concatenado ao valor da caixa.
        /// </summary>

        #endregion Documentation

        private void UpdateTextBoxMain()
        {
            if (IsTextBoxMainEmpty())
            {
                textBoxMain.Text = lastClickedMember.Text;
            }
            else
            {
                textBoxMain.Text += lastClickedMember.Text;
            }
        }

        #region Documentation

        /// <summary>
        /// Valida se a caixa de texto principal está vazia (valor zero).
        /// </summary>
        /// <returns>Verdadeiro se estiver vazia e falso, caso contrário.</returns>

        #endregion Documentation

        private bool IsTextBoxMainEmpty()
        {
            try
            {
                return Convert.ToDouble(textBoxMain.Text) == 0D ? true : false;
            }
            catch
            {
                return false;
            }
        }

        #endregion Methods
    }
}