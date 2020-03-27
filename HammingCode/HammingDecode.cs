using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace HammingCode
{
    class HammingDecode
    {
        public int N { get; set; }
        public int R { get; set; }
        public int K { get; set; }

        public static int[,] H_1011 = // x^3+x+1
        {
            { 1, 1, 1, 0, 1, 0, 0},
            { 0, 1, 1, 1, 0, 1, 0},
            { 1, 1, 0, 1, 0, 0, 1}
        };

        public static int[,] H_1101 = // x^3+x^2+1
        {
            { 1, 0, 1, 1, 1, 0, 0},
            { 1, 1, 1, 0, 0, 1, 0},
            { 0, 1, 1, 1, 0, 0, 1}
        };

        public HammingDecode(string code, string binnaryPolynomial)
        {
            N = code.Length;
            R = binnaryPolynomial.Length -1;
            K = N - R;
        }

        public string getYr(string code)
        {
            return code.Substring(K, R);
        }

        public string getYk(string code)
        {
            return code.Substring(0, K);
        }

        public HammingDecode(int code, int binnaryPolynomial)
        {
            N = code.ToString().Length;
            R = binnaryPolynomial.ToString().Length -1;
            K = N - R;
        }

        public string decode(string code, int [,] hammingMatrix)
        {
            StringBuilder output = new StringBuilder();
            int [] y_r = new int[R];
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    y_r[i] += hammingMatrix[i, j] *
                              (int) Char.GetNumericValue(code.ElementAt(j));
                }

                y_r[i] %= 2;
                output.Append(y_r[i]);
            }

            return output.ToString();
        }

        public string [] decodeToString(string code, int[,] hammingMatrix)
        {
            string[] y_r = new string[R];
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    y_r[i] += hammingMatrix[i, j]+ " * " + code.ElementAt(j) + " ⊕ ";
                }

                y_r[i].Substring(0, y_r[i].Length - 3);
            }

            return y_r;
        }

        public string calculateSyndrome(string y_r, string y_r1)
        {
            StringBuilder output = new StringBuilder();
            int[] syndrome = new int[R];
            for (int i = 0; i < R; i++)
            {
                syndrome[i] = (int) Char.GetNumericValue(y_r.ElementAt(i)) +
                              (int) Char.GetNumericValue(y_r1.ElementAt(i));

                syndrome[i] %= 2;
                output.Append(syndrome[i]);
            }

            return output.ToString();
        }

        public bool isCorrect(string syndrome)
        {
            return (int.Parse(syndrome) == 0) ? true : false;
        }

        public string[] parseColumnsToString(int [,] hammingMatrix)
        {
            StringBuilder builder = new StringBuilder();
            string [] columns = new string[K];//    N OR K
            for (int i = 0; i < K; i++)     //  N OR K
            {
                for (int j = 0; j < R; j++)
                {
                    builder.Append(hammingMatrix[j,i]);
                }

                columns[i] = builder.ToString();
                builder.Clear();
            }

            return columns;
        }

        public int getIndexOfError(string syndrome, string[] columns)
        {
            for (int i = 0; i < K; i++) //  N OR K
            {
                if (syndrome.Equals(columns[i]))
                    return i;
            }
            return -1;
        }

        public string generateEn(int errorIndex)
        {
            string en = new string('0', N);
            char[] chars = en.ToCharArray();
            chars[errorIndex] = '1';

            return new string(chars);
        }

        public string fixError(string code, string En)
        {
            StringBuilder builder = new StringBuilder();
            int temp;
            for (int i = 0; i < N ; i++)
            {
                temp = (int) Char.GetNumericValue(code.ElementAt(i)) +
                       (int) Char.GetNumericValue(En.ElementAt(i));
                builder.Append(temp % 2);
            }

            return builder.ToString();
        }

        public string matrixToString(int [,] matrix)
        {
            StringBuilder builder= new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                builder.Append("\t[");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    builder.Append("  " + matrix[i, j]);
                }

                builder.Append("  ]\r\n");
            }
            return builder.ToString();
        }
    }
}
