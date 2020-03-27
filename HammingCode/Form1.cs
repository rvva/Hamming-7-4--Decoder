using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HammingCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            comboBoxG_X.SelectedIndex = 0;
            startMessage();
            

            /* TEST
            string code = "1000110";
            string binnaryPolynomial = "1011";

            HammingDecode decode = new HammingDecode(code, binnaryPolynomial);
            string outputDecode = decode.decode(code, HammingDecode.H_1011);
            
            string[] columns = decode.parseColumnsToString(HammingDecode.H_1011);

            string syndrome = decode.calculateSyndrome(decode.getYr(code), outputDecode);


            if (decode.isCorrect(syndrome))
            {
                MessageBox.Show("OK");
            }
            else
            {
                int indexError = decode.getIndexOfError(syndrome, columns);
                string en = decode.generateEn(indexError);
                string messageFixed = decode.fixError(code, en);

                MessageBox.Show(decode.getYr(code) + Environment.NewLine +
                                outputDecode + Environment.NewLine +
                                syndrome + Environment.NewLine +
                                en + Environment.NewLine +
                                messageFixed + Environment.NewLine);
                
            }
            */
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            string code = maskedTextBoxYn.Text;
            string binnaryPolynomial = optionToBinnaryPolynomial(comboBoxG_X.SelectedIndex);
            HammingDecode decode = new HammingDecode(code, binnaryPolynomial);

            richTextBoxLog.Text = "";
            richTextBoxLog.AppendText("H(" + decode.R + ", " + decode.N + ") = \r\n");

            int[,] matrix = optionToHammingMatrix(comboBoxG_X.SelectedIndex);
            richTextBoxLog.AppendText(decode.matrixToString(matrix) + Environment.NewLine);

            List<String> codeMatrix = new List<string>();
            string yk = decode.getYk(code);


            //create codeMatrix
            for (int i = 0; i < yk.Length; i++)
            {
                codeMatrix.Add(yk.ElementAt(i).ToString());
            }

            //create codeMatrix
            for (int i = 0; i < decode.R; i++)
            {
                codeMatrix.Add("Yr_" + (i+1));
            }

            //show codeMatrix
            richTextBoxLog.AppendText("\t*  [  " + codeMatrix.ElementAt(0) + "  ]\r\n");
            for (int i = 1; i < codeMatrix.Count; i++) { 

                richTextBoxLog.AppendText("\t    [  " + codeMatrix.ElementAt(i) + "  ]\r\n");
                
            }

            string zeros = new string('0', decode.R);

            richTextBoxLog.AppendText("\r\n");
            richTextBoxLog.AppendText("\t=  [  " + zeros.ElementAt(0) + "  ]\r\n");

            //show output zeros
            for (int i = 1; i < zeros.Length; i++)
            {
                richTextBoxLog.AppendText("\t    [  " + zeros.ElementAt(i) + "  ]\r\n");
            }
            
            richTextBoxLog.AppendText("\r\n");
            string y_r1 = decode.decode(code, matrix);
            string[] y_rCalculations = decode.decodeToString(code, matrix);

            //show y_r1
            for (int i = 0; i < y_r1.Length; i++)
            {
                richTextBoxLog.AppendText("Yr_" + (i+1) + " = " + y_rCalculations[i] + " = " + y_r1.ElementAt(i) + "\r\n");
            }

            string syndrome = decode.calculateSyndrome(decode.getYr(code), y_r1);
            richTextBoxLog.AppendText("\r\n");
            richTextBoxLog.AppendText("Syndrom = " + decode.getYr(code) + " ⊕ " + y_r1 + " = " + syndrome);
            richTextBoxLog.AppendText(new string ('\n',2));

            //isCorrect?
            if (decode.isCorrect(syndrome))
                richTextBoxLog.AppendText("Wynik : Wiadomość bez błędów!");
            else
            {
                int errorIndex = decode.getIndexOfError(syndrome, decode.parseColumnsToString(matrix));

                if (errorIndex == -1)
                {
                    richTextBoxLog.AppendText("Wynik: Błąd nie może zostać naprawiony!");
                    return;
                }

                string en = decode.generateEn(errorIndex);

                richTextBoxLog.AppendText("Wystąpił błąd na " + (errorIndex + 1) + " bicie.\r\n");
                richTextBoxLog.AppendText("En = " + en + Environment.NewLine);
                string correctMessage = decode.fixError(code, en);
                richTextBoxLog.AppendText("\r\nYn = " + en + " ⊕ " + code + " = " + correctMessage + "\r\n");
                richTextBoxLog.AppendText("Wynik: Wiadomość po korekcie = " + correctMessage);
            }
        }


        private string optionToBinnaryPolynomial(int index)
        {
            switch (index)
            {
               case 0:
                   return "1011";
                case 1:
                    return "1101";
                default:
                    return "";
            }
        }

        private int[,] optionToHammingMatrix(int index)
        {
            switch (index)
            {
                case 0:
                    return HammingDecode.H_1011;
                case 1:
                    return HammingDecode.H_1101;
                default:
                    return new int[0,0];
            }
        }

        private void maskedTextBoxYn_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBoxYn.Text.Length != 7) 
                buttonDecode.Enabled = false;
            else
                buttonDecode.Enabled = true;
        }

        private void startMessage()
        {
            richTextBoxLog.Text = "1. Wprowadź wiadomość w pole Yn (7 znaków).\r\n" +
                   "2. Wybierz G(X).\r\n" +
                   "3. Kliknij \"Dekoduj\".";
        }
    }
}
