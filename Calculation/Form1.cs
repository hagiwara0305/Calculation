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
        private Button[] calculationObject;

        public Form1()
        {
            InitializeComponent();
            calculationObject = new Button[] { button4, button5, button9, button13 , button1, button3 };
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
                SetCalculationEnable(true);
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
                if(anser == 0 && calculationSymbol == "÷")
                {
                    Anserlabel.Text = "∞";
                    setCliear();
                    return;
                }
                anser = CalculationEqual(int.Parse(Anserlabel.Text), anser);
                calculationSymbol = ((Button)sender).Text;
                CalculationHistoryLabel.Text += Anserlabel.Text + " " + calculationSymbol;
            }
            Anserlabel.Text = anser.ToString();
            CalculationSymbolFlag = false;
            SetCalculationEnable(false);
        }

        private void EqualClick(object sender, EventArgs e)
        {
            CalculationHistoryLabel.Text = "";
            if (int.Parse(Anserlabel.Text) == 0 && calculationSymbol == "÷")
            {
                Anserlabel.Text = "∞";
                setCliear();
                return;
            }
            anser = CalculationEqual(anser, int.Parse(Anserlabel.Text));
            Anserlabel.Text = anser.ToString();
            CalculationSymbolFlag = false;
            fastCalculationFlag = true;
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
            setCliear();
            Anserlabel.Text = "0";
        }

        private void setCliear()
        {
            anser = 0;
            CalculationHistoryLabel.Text = "";
            calculationSymbol = null;
            fastCalculationFlag = true;
            CalculationSymbolFlag = false;
            SetCalculationEnable(false);
        }

        private int CalculationEqual(int anser, int number)
        {
            switch (calculationSymbol)
            {
                case "+":
                    return number + anser;
                case "-":
                    return number - anser;
                case "÷":
                    return anser / number;
                case "×":
                    return number * anser;
            }
            return 0;
        }

        private void SetCalculationEnable(bool enabel)
        {
            foreach(Button item in calculationObject)
            {
                item.Enabled = enabel;
            }   
        }
    }
}
