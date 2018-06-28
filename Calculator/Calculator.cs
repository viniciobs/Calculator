using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Calculator.Controller;
using CalculatorEntities;
using System.Linq;
using System.Collections.Generic;

namespace Calculator
{
	#region Documentation

	/// <summary>
	/// Formulário principal contendo as funcionalidades da calculadora.
	/// Nesse código, os botões da calculadora são chamados de membros.
	/// </summary>

	#endregion Documentation

	public partial class FormMain : Form
	{
		#region Properties

		#region Documentation

		/// <summary>
		/// Contém o último membro clicado na calculadora.
		/// </summary>

		#endregion Documentation

		private Button lastClickedMember { get; set; }

		#region Documentation

		/// <summary>
		/// Esse campo serve para auxiliar no preenchimento da caixa de texto.
		/// Se esse campo tiver o valor verdadeiro, significa que a caixa de texto contém a resposta da última operação, então
		/// o ActionType deve ser New e não Concat.
		/// </summary>

		#endregion Documentation

		private bool isOperationFinished { get; set; }

		#region Documentation

		/// <summary>
		/// Array contendo todos os membros de operação.
		/// Seu valor é setado no construtor dessa classe.
		/// Ele será usado para auxiliar o método HasOperationToCalculate() que é chamado com frequência nesse projeto.
		/// </summary>

		#endregion Documentation

		private Char[] operationTypes { get; set; }

		#endregion Properties

		#region Constructor

		public FormMain()
		{
			isOperationFinished = false;
			operationTypes = EnumHelper.GetValues<OperationMembers>();

			InitializeComponent();
		}

		#endregion Constructor

		#region Methods

		#region Event Handlers

		#region Numerical Members Click

		private void buttonZero_Click(object sender, System.EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonOne_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonTwo_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonThree_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonFour_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonFive_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonSix_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonSeven_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonEight_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonNine_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		private void buttonPoint_Click(object sender, EventArgs e)
		{
			NumericMemberClick(sender);
		}

		#endregion Numerical Members Click

		#region Operation Members Click

		private void buttonSum_Click(object sender, EventArgs e)
		{
			var teste = HasOperationToCalculate();

			lastClickedMember = (Button)sender;
			UpdateLabelHolder();
			ResetTextBoxMain();
			isOperationFinished = false;
		}

		private void buttonSquirt_Click(object sender, EventArgs e)
		{
			lastClickedMember = (Button)sender;
			UpdateTextBoxMain();
		}

		private void buttonPercent_Click(object sender, EventArgs e)
		{
			lastClickedMember = (Button)sender;
			UpdateTextBoxMain();
			isOperationFinished = false;
			UpdateTextBoxMain(ActionType.ShowResult);
			isOperationFinished = true;
		}

		#endregion Operation Members Click

		private void buttonClear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void textBoxMain_TextChanged(object sender, EventArgs e)
		{
			if (IsTextBoxMainEmpty())
			{
				ResetTextBoxMain();
			}
		}

		#endregion Event Handlers

		#region Documentation

		/// <summary>
		/// O padrão para cada membro numérico clicado.
		/// Atualiza a propriedade lastClickedMember com o último membro clicado, atualiza a caixa de texto com o valor do último membro clicado,
		/// e define a propriedade isOperationFinished como falso, já que essa propriedade tem seu valor deifinido como verdadeiro apenas quando é executado o cálculo.
		/// </summary>
		/// <param name="sender">O membro que foi clicado.</param>

		#endregion Documentation

		private void NumericMemberClick(object sender)
		{
			if (isOperationFinished)
			{
				ResetTextBoxMain();
			}

			lastClickedMember = (Button)sender;
			UpdateTextBoxMain();
			isOperationFinished = false;
		}

		#region Documentation

		/// <summary>
		/// Valida os cenários e escolhe qual vai ser a ação de limpeza.
		///
		/// 1. Se a última operação foi concluída ou caixa de texto principal está vazia, deverá resetar a caixa principal.
		/// 2. Se o último membro clicado for um membro de operação, o mesmo será removido do labelHolder.
		/// 3. Se o último membro clicado for numérico, o mesmo será removido do caixa de texto principal.
		/// </summary>

		#endregion Documentation

		private void Clear()
		{
			if (lastClickedMember == null) return;

			if (IsTextBoxMainEmpty() || isOperationFinished)
			{
				ResetTextBoxMain();
			}

			var lastMemberClickedType = Enum.IsDefined(typeof(OperationMembers), Convert.ToInt32(lastClickedMember.Text[0]))
				? MemberType.Operation
				: MemberType.Numeric;

			switch (lastMemberClickedType)
			{
				#region Comments

				/// Se o último membro clicado foi um membro de operação, o mesmo é apagado da labelHolder.

				#endregion Comments

				case MemberType.Operation:
					labelHolder.Text = labelHolder.Text.Substring(0, labelHolder.Text.Length - 1);
					break;

				#region Comments

				/// Se o último membro clicado foi um membro numérico, o mesmo é apagado da caixa de texto principal.

				#endregion Comments

				case MemberType.Numeric:
					textBoxMain.Text = textBoxMain.Text.Substring(0, textBoxMain.Text.Length - 1);
					break;
			}
		}

		private void UpdateLabelHolder()
		{
			labelHolder.Text = string.Format("{0} {1} {2}",
					labelHolder.Text,
					textBoxMain.Text,
					lastClickedMember.Text
				);
		}

		private void UpdateTextBoxMain(ActionType? actionType = null)
		{
			if (actionType == null)
			{
				actionType = DefineActionType();
			}

			switch (actionType)
			{
				case ActionType.New:
					textBoxMain.Text = lastClickedMember.Text;
					break;

				case ActionType.Reset:
					ResetTextBoxMain();
					break;

				case ActionType.Concat:
					textBoxMain.Text += lastClickedMember.Text;
					break;

				case ActionType.ShowResult:
					textBoxMain.Text = MathSolver.Calculate(labelHolder.Text);
					break;
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
			if (textBoxMain.Text.Length == 0) return true;

			try
			{
				return Convert.ToDouble(textBoxMain.Text) == 0D ? true : false;
			}
			catch
			{
				return false;
			}
		}

		#region Documentation

		/// <summary>
		/// A finalidade desse método é, quando não for explícitamente informado qual é a ação, descobrir e informar qual é a ação que será realizada.
		/// Se a caixa de texto estiver vazia, isso significa que é um novo valor a ser inserido, caso contrário, significa que é um valor a ser concatenado ao valor atual da caixa de texto.
		/// </summary>
		/// <returns>Enum ActionType referente a ação que está sendo executada.</returns>

		#endregion Documentation

		private ActionType DefineActionType()
		{
			if (IsTextBoxMainEmpty())
			{
				return ActionType.New;
			}
			else
			{
				return ActionType.Concat;
			}
		}

		#region Documentation

		/// <summary>
		/// Reseta a caixa de texto. Exibe o valor zero.
		/// </summary>

		#endregion Documentation

		private void ResetTextBoxMain()
		{
			textBoxMain.Text = "0";
		}

		#region Documentation

		/// <summary>
		/// Reseta a labelHolder apagando seu conteúdo.
		/// </summary>

		#endregion Documentation

		private void ResetLabelHolder()
		{
			labelHolder.Text = String.Empty;
		}

		private bool HasOperationToCalculate()
		{
			var regexDigits = "[\\d\\.]*";
			var regexOperations = "[" + string.Join("|", operationTypes) + "]";

			var regexBuilder = new StringBuilder();

			regexBuilder.Append(regexDigits);
			regexBuilder.Append(regexOperations);
			regexBuilder.Append(regexDigits);

			Regex regex = new Regex(regexBuilder.ToString());
			Match match = regex.Match(labelHolder.Text);

			return match.Success ? true : false;
		}

		#endregion Methods
	}
}