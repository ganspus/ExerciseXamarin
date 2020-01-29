using System;
using System.Collections.Generic;
using ExerciseXamarin.Helper;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise8Page : ContentPage
    {
        int currentState = 1;
        string myOperator;
        double fisrtNumber, secondNumber;

        public Exercise8Page()
        {
            InitializeComponent();

            AC_Clicked(this, null);
        }

        void OnSelectNumber(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;

            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";

                if (currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                // this.resultText.Text = number.ToString("NO");
                if (currentState == 1)
                {
                    fisrtNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void AC_Clicked(System.Object sender, System.EventArgs e)
        {
            fisrtNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnSelectOperator(System.Object sender, System.EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            myOperator = pressed;
        }

        void Persen_Clicked(System.Object sender, System.EventArgs e)
        {
            if ((currentState == -1 ) || (currentState == 1))
            {
                var result = fisrtNumber / 100;
                this.resultText.Text = result.ToString();
                fisrtNumber = result;
                currentState = -1;
            }
        }

        void OnCalculate(System.Object sender, System.EventArgs e)
        {
            if (currentState == 2)
            {
                var result = OperatorHelper.Calculate(fisrtNumber, secondNumber, myOperator);

                this.resultText.Text = result.ToString();
                fisrtNumber = result;
                currentState = -1;
            }
        }

        void Akar_Clicked(System.Object sender, System.EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = Math.Sqrt(fisrtNumber);
                this.resultText.Text = result.ToString();
                fisrtNumber = result;
                currentState = -1;
            }
        }

        private void Kuadrat_Clicked(System.Object sender, System.EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = fisrtNumber * fisrtNumber;
                this.resultText.Text = result.ToString();
                fisrtNumber = result;
                currentState = -1;
            }
        }
    }
}
