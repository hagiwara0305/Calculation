using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation
{
    public partial class Form1 : Form
    {
        private int anser = 0;
        private string calculationSymbol;
        private bool fastCalculationFlag = true;
        private bool CalculationSymbolFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumberClick(object sender, EventArgs e)
        {
            if (Anserlabel.Text != "0" && CalculationSymbolFlag)
            {
                Anserlabel.Text += ((Button)sender).Text;
            }
            else
            {
                Anserlabel.Text = ((Button)sender).Text;
                CalculationSymbolFlag = true;
            }
        }

        private void CalculationSymbolClick(object sender, EventArgs e)
        {
            if (fastCalculationFlag)
            {
                calculationSymbol = ((Button)sender).Text;
                anser = int.Parse(Anserlabel.Text);
                CalculationHistoryLabel.Text = Anserlabel.Text + " " + calculationSymbol;
                fastCalculationFlag = false;
            }
            else
            {
                anser = CalculationEqual(int.Parse(Anserlabel.Text), anser);
                calculationSymbol = ((Button)sender).Text;
                CalculationHistoryLabel.Text += Anserlabel.Text + " " + calculationSymbol;
            }
            Anserlabel.Text = anser.ToString();
            CalculationSymbolFlag = false;
        }

        private void EqualClick(object sender, EventArgs e)
        {
            CalculationHistoryLabel.Text = "";
            anser = CalculationEqual(anser, int.Parse(Anserlabel.Text));
            Anserlabel.Text = anser.ToString();
            CalculationSymbolFlag = false;
            fastCalculationFlag = true;
        }

        private int CalculationEqual(int anser, int number)
        {
            switch (calculationSymbol)
            {
                case "+":
                    return anser + number;
                case "-":
                    return anser - number;
                case "÷":
                    return anser / number;
                case "×":
                    return anser * number;
            }
            return 0;
        }

        private void BackspaceClick(object sender, EventArgs e)
        {
            if (Anserlabel.Text.Length == 1)
            {
                Anserlabel.Text = "0";
            }
            else
            {
                Anserlabel.Text = Anserlabel.Text.Remove(Anserlabel.Text.Length - 1, 1);
            }
        }

        private void ClearentryClick(object sender, EventArgs e)
        {
            Anserlabel.Text = "0";
        }

        private void ClearClick(object sender, EventArgs e)
        {
            anser = 0;
            Anserlabel.Text = "0";
            CalculationHistoryLabel.Text = "";
            calculationSymbol = null;
            fastCalculationFlag = true;
            CalculationSymbolFlag = false;
        }
    }
}
