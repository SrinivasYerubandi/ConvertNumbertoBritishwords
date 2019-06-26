using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNumbertoWords
{
    class Program
    {
        #region MainMethod
        static void Main(string[] args)
        {
            try
            {
                string chkNum = "";
                string output;

                Console.WriteLine("Please enter a number for converting into words");
                string Num = Console.ReadLine();
                double input = Convert.ToDouble(Num);

                chkNum = CheckNumber(Convert.ToString(input)); //check for input validity

                if (String.IsNullOrEmpty(chkNum) || chkNum == "")
                {
                    output = ConvertNumbertoWords(Num);
                }
                else
                {
                    output = chkNum;
                }

                Console.WriteLine(output);
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }

        }
        #endregion        

        #region InputValidation

        /// <summary>
        /// Check whether the given number is valid or not
        /// </summary>
        /// <param name="dblNum"></param>
        /// <returns></returns>
        public static string CheckNumber(string strNum)
        {
            string word = "";
            double dblNum = Convert.ToDouble(strNum);

            if (strNum.Contains("."))
            {
                word = "Input number entered is a decimal number. Please enter an integer for conversion.";
            }
            else if (dblNum < 0)
            {
                word = "Number Can't be negative. Please enter positive Number ";
            }
            else if (dblNum >= 1000000000)
            {
                word = "Input number entered is not valid. Please enter a number less than or equal to 999999999";
            }

            return word;
        }
        #endregion

        #region ConvertNumbertoWords
        
        /// <summary>
        /// Method to convert the given number into words
        /// </summary>
        /// <param name="strNum"></param>
        /// <returns></returns>
        public static string ConvertNumbertoWords(string strNum)
        {
            string word = "";
            double dblNum = Convert.ToDouble(strNum);
            bool isDone = false;

            Dictionary<int, string> onespos = new Dictionary<int, string>();
            Dictionary<int, string> tenspos = new Dictionary<int, string>();

            onespos.Add(0, "Zero");
            onespos.Add(1, "One");
            onespos.Add(2, "Two");
            onespos.Add(3, "Three");
            onespos.Add(4, "Four");
            onespos.Add(5, "Five");
            onespos.Add(6, "Six");
            onespos.Add(7, "Seven");
            onespos.Add(8, "Eight");
            onespos.Add(9, "Nine");

            tenspos.Add(10, "Ten");
            tenspos.Add(11, "Eleven");
            tenspos.Add(12, "Twelve");
            tenspos.Add(13, "Thirteen");
            tenspos.Add(14, "Fourteen");
            tenspos.Add(15, "Fifteen");
            tenspos.Add(16, "Sixteen");
            tenspos.Add(17, "Seventeen");
            tenspos.Add(18, "Eighteen");
            tenspos.Add(19, "Nineteen");
            tenspos.Add(20, "Twenty");
            tenspos.Add(30, "Thirty");
            tenspos.Add(40, "Forty");
            tenspos.Add(50, "Fifty");
            tenspos.Add(60, "Sixty");
            tenspos.Add(70, "Seventy");
            tenspos.Add(80, "Eighty");
            tenspos.Add(90, "Ninety");
            if (dblNum == 0)
            {
                return "zero";
            }

            else if (dblNum > 0)
            {
                int numDigits = Convert.ToString(Convert.ToDecimal(strNum)).Length;
                int pos = 0;
                String place = "";
                switch (numDigits)
                {
                    case 1://ones' range

                        word = onespos[Convert.ToInt32(dblNum)];
                        isDone = true;
                        break;
                    case 2://tens' range

                        if (tenspos.ContainsKey(Convert.ToInt32(dblNum)))
                        {
                            word = tenspos[Convert.ToInt32(dblNum)];
                        }
                        else
                        {

                            word = tenspos[Convert.ToInt32(Convert.ToString(dblNum).Substring(0, 1) + "0")] + " " +
                                   onespos[Convert.ToInt32(Convert.ToString(dblNum).Substring(1))];
                        }
                        isDone = true;
                        break;
                    case 3:
                        pos = (numDigits % 3) + 1;
                        place = " Hundred ";
                        break;
                    case 4://thousands' 
                    case 5:
                    case 6:
                        pos = (numDigits % 4) + 1;
                        place = " Thousand ";
                        break;
                    case 7://millions' 
                    case 8:
                    case 9:
                        pos = (numDigits % 7) + 1;
                        place = " Million ";
                        break;
                    default:
                        isDone = true;
                        break;
                }
                if (!isDone)
                {
                    string wrd1 = "";
                    if (ConvertNumbertoWords(strNum.Substring(pos)) != "" && place == " Hundred ")
                    {
                        wrd1 = "and " + ConvertNumbertoWords(strNum.Substring(pos));
                    }
                    else
                    {
                        wrd1 = ConvertNumbertoWords(strNum.Substring(pos));
                    }

                    word = ConvertNumbertoWords(strNum.Substring(0, pos)) + place + wrd1;
                }

            }
            return word;
        }
        #endregion

    }

}
