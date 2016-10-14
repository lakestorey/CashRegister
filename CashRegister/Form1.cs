///Created by Lake Storey on Oct. 7th, 2016
///To create a fully functional cash register software program 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CashRegister
{
    public partial class QuickieKs : Form
    {
        // creates all graphics forms in a global space
        Graphics formGraphics;
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Font arialFont9 = new Font("Arial", 9, FontStyle.Bold);

        //declares all variables in a global space
        int chickenFingersAmount;
        int friesAmount;
        int softDrinkAmount;
        const double chickenFingersPrice = 2.85;
        const double friesPrice = 2.75;
        const double softDrinkPrice = 3.00;
        double subTotalPrice;
        double taxPrice;
        double totalPrice;
        double tenderedInputAmount;
        double changeAmount;
        double chickenFingersTotal;
        double friesTotal;
        double softDrinkTotal;

        //declares all sound effects
        SoundPlayer chaChing = new SoundPlayer(Properties.Resources.Cash_Register_Cha_Ching_SoundBible_com_184076484);
        public QuickieKs()
        {
            InitializeComponent();
            formGraphics = this.CreateGraphics();
            resetButton.Visible = false;
        }
        private void calculateTotalsButton_Click(object sender, EventArgs e)
        {
            //Assigns amounts of things
            try
            {
                chickenFingersAmount = Convert.ToInt32(chickenFingersInput.Text);
            }
            catch
            {
                errorLabel.Text = "Incorrect amount, please try again.";
                errorLabel.ForeColor = Color.Black;
            }
            try
            {
                friesAmount = Convert.ToInt32(friesInput.Text);
            }
            catch
            {
                errorLabel.Text = "Incorrect amount, please try again.";
                errorLabel.ForeColor = Color.Black;
            }
            try
            {
                softDrinkAmount = Convert.ToInt32(softDrinkInput.Text);
            }
            catch
            {
                errorLabel.Text = "Incorrect amount, please try again.";
                errorLabel.ForeColor = Color.Black;
            }
            //Calculates and prints sub total, tax and total
            subTotalPrice = (chickenFingersAmount * chickenFingersPrice)+(friesAmount * friesPrice)+(softDrinkAmount * softDrinkPrice);
            taxPrice = subTotalPrice * 0.13;
            totalPrice = taxPrice + subTotalPrice;
            subTotalAmountLabel.Text = subTotalPrice.ToString("C");
            taxAmountLabel.Text = taxPrice.ToString("C");
            subTotalAmountLabel.ForeColor = Color.Black;
            subTotalAmountLabel.Refresh();
            chaChing.Play();
            Thread.Sleep(1000);
            totalAmountLabel.Text = totalPrice.ToString("C");
            taxAmountLabel.ForeColor = Color.Black;
            taxAmountLabel.Refresh();
            chaChing.Play();
            Thread.Sleep(1000);
            totalAmountLabel.ForeColor = Color.Black;
            chaChing.Play();
        }
        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            //calculates and outputs change amount
            try
            {
                tenderedInputAmount = Convert.ToDouble(tenderedInput.Text);
            }
            catch
            {
                errorLabel.Text = "Incorrect amount, please try again.";
                errorLabel.ForeColor = Color.Black;
            }
            if (tenderedInputAmount > totalPrice)
            {
                changeAmount = tenderedInputAmount - totalPrice;
                changeAmountLabel.Text = changeAmount.ToString("C");
                changeAmountLabel.ForeColor = Color.Black;
                chaChing.Play();
            }
            else
            {
                errorLabel.Text = "Insufficient funds, please try again.";
                errorLabel.ForeColor = Color.Black;
            }
        }
        private void printReceiptButton_Click(object sender, EventArgs e)
        {
            resetButton.Visible = true;
            resetButton.Refresh();

            //calculates amounts for receipt
            chickenFingersTotal = chickenFingersPrice * chickenFingersAmount;
            friesTotal = friesPrice * friesAmount;
            softDrinkTotal = softDrinkPrice * softDrinkAmount;

            //creates receipt
            errorLabel.Visible = false;
            formGraphics.FillRectangle(whiteBrush, 175, 5, 230, 285);
            formGraphics.DrawString("Quikie k's", arialFont9, blackBrush, 178, 8);
            chaChing.Play();
            Thread.Sleep(1000);
            formGraphics.DrawString(DateTime.Now.ToString(), arialFont9, blackBrush, 178, 20);
            chaChing.Play();
            Thread.Sleep(1000);
            if (chickenFingersAmount > 0)
            {
                formGraphics.DrawString("Chicken Fingers: ", arialFont9, blackBrush, 178, 32);
                formGraphics.DrawString("x"+chickenFingersAmount, arialFont9, blackBrush, 290, 32);
                formGraphics.DrawString(chickenFingersTotal.ToString("C"), arialFont9, blackBrush, 320, 32);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (friesAmount > 0)
            {
                formGraphics.DrawString("Fries: ", arialFont9, blackBrush, 178, 44);
                formGraphics.DrawString("x"+friesAmount, arialFont9, blackBrush, 290, 44);
                formGraphics.DrawString(friesTotal.ToString("C"), arialFont9, blackBrush, 320, 44);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (softDrinkAmount > 0)
            {
                formGraphics.DrawString("Soft Drinks: ", arialFont9, blackBrush, 178, 56);
                formGraphics.DrawString("x"+softDrinkAmount, arialFont9, blackBrush, 290, 56);
                formGraphics.DrawString(softDrinkTotal.ToString("C"), arialFont9, blackBrush, 320, 56);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (subTotalPrice > 0)
            {
                formGraphics.DrawString("Subtotal", arialFont9, blackBrush, 178, 80);
                formGraphics.DrawString(subTotalPrice.ToString("C"), arialFont9, blackBrush, 320, 80);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (taxPrice > 0)
            {
                formGraphics.DrawString("Tax", arialFont9, blackBrush, 178, 92);
                formGraphics.DrawString(taxPrice.ToString("C"), arialFont9, blackBrush, 320, 92);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (totalPrice > 0)
            {
                formGraphics.DrawString("Total", arialFont9, blackBrush, 178, 104);
                formGraphics.DrawString(totalPrice.ToString("C"), arialFont9, blackBrush, 320, 104);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (tenderedInputAmount > 0)
            {
                formGraphics.DrawString("Tendered", arialFont9, blackBrush, 178, 128);
                formGraphics.DrawString(tenderedInputAmount.ToString("C"), arialFont9, blackBrush, 320, 128);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            if (changeAmount > 0)
            {
                formGraphics.DrawString("Change:", arialFont9, blackBrush, 178, 140);
                formGraphics.DrawString(changeAmount.ToString("C"), arialFont9, blackBrush, 320, 140);
                chaChing.Play();
                Thread.Sleep(1000);
            }
            formGraphics.DrawString("Have A Nice Day!", arialFont9, blackBrush, 178, 275);
            chaChing.Play();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //resets all output labels to background color
            changeAmountLabel.ForeColor = Color.Gainsboro;
            totalAmountLabel.ForeColor = Color.Gainsboro;
            taxAmountLabel.ForeColor = Color.Gainsboro;
            subTotalAmountLabel.ForeColor = Color.Gainsboro;

            //resets all variables
            chickenFingersAmount = 0;
            friesAmount = 0;
            softDrinkAmount = 0;
            subTotalPrice = 0;
            taxPrice = 0;
            totalPrice = 0;
            tenderedInputAmount = 0;
            changeAmount = 0;
            chickenFingersTotal = 0;
            friesTotal = 0;
            softDrinkTotal = 0;
            formGraphics.Clear(Color.Gainsboro);
        }
    }
}
