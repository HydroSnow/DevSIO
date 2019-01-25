using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace calculatroce
{
    public partial class Form1 : Form
    {
        private List<String> operand;

        public Form1()
        {
            InitializeComponent();
            operand = new List<String>();
            operand.Add("");
        }

        private void d0_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "0";
            update();
        }

        private void d1_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "1";
            update();
        }

        private void d2_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "2";
            update();
        }

        private void d3_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "3";
            update();
        }

        private void d4_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "4";
            update();
        }

        private void d5_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "5";
            update();
        }

        private void d6_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "6";
            update();
        }

        private void d7_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "7";
            update();
        }

        private void d8_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "8";
            update();
        }

        private void d9_Click(object sender, EventArgs e)
        {
            operand[operand.Count - 1] += "9";
            update();
        }

        private void bdot_Click(object sender, EventArgs e)
        {
            int n = operand.Count - 1;
            if (operand[n] == "")
            {
                operand[n] = "0,";
            }
            else if (!operand[n].Contains(","))
            {
                operand[n] += ",";
            }

            update();
        }

        private void update()
        {
            currcalc.Text = "";
            foreach (String str in operand)
            {
                if (str == "+" || str == "-")
                {
                    currcalc.Text += " " + str + " ";
                }
                else if (str == "*" || str == "/")
                {                 
                    bool needparenthesis = false;
                    int parenthesisdepth = 0;
                    foreach (char c in currcalc.Text)
                    {
                        if (c == '(')
                        {
                            parenthesisdepth++;
                        }
                        else if (c == ')')
                        {
                            parenthesisdepth--;
                        }
                        else if (c == '+' || c == '-')
                        {
                            if (parenthesisdepth == 0)
                            {
                                needparenthesis = true;
                                break;
                            }
                        }
                    }
                    
                    if (needparenthesis)
                    {
                        currcalc.Text = "(" + currcalc.Text + ") " + str + " ";
                    }
                    else
                    {
                        currcalc.Text += " " + str + " ";
                    }
                }
                else if (str.Length > 0 && str[0] == '-')
                {
                    currcalc.Text += "(" + str + ")";
                }
                else
                {
                    currcalc.Text += str;
                }
            }

            if (operand.Count > 0 && operand[0] != "")
            {
                double act = Convert.ToDouble(operand[0]);
                for (int a = 1; (a + 1) < operand.Count; a += 2)
                {
                    if (operand[a + 1] != "" && operand[a + 1] != "-")
                    {
                        switch (operand[a])
                        {
                            case "+":
                                act += Convert.ToDouble(operand[a + 1]);
                                break;
                            case "-":
                                act -= Convert.ToDouble(operand[a + 1]);
                                break;
                            case "*":
                                act *= Convert.ToDouble(operand[a + 1]);
                                break;
                            case "/":
                                act /= Convert.ToDouble(operand[a + 1]);
                                break;
                        }
                    }
                }
                currnmb.Text = "" + act;
            }
            else
            {
                currnmb.Text = "";
            }
        }

        private void reset()
        {
            operand.Clear();
            operand.Add("");
            update();
        }

        private void bplus_Click(object sender, EventArgs e)
        {
            int n = operand.Count - 1;
            if (operand[n] == "" || operand[n] == "+" || operand[n] == "-" || operand[n] == "*" || operand[n] == "/")
            {
                return;
            }
            else
            {
                operand.Add("+");
                operand.Add("");
                update();
            }
        }

        private void bminus_Click(object sender, EventArgs e)
        {
            int n = operand.Count - 1;
            if (operand[n] == "")
            {
                operand[n] = "-";
                update();
            }
            else if (operand[n] == "-")
            {
                return;
            }
            else
            {
                operand.Add("-");
                operand.Add("");
                update();
            }
        }

        private void btimes_Click(object sender, EventArgs e)
        {
            int n = operand.Count - 1;
            if (operand[n] == "" || operand[n] == "+" || operand[n] == "-" || operand[n] == "*" || operand[n] == "/")
            {
                return;
            }
            else
            {
                operand.Add("*");
                update();
                operand.Add("");
            }
        }

        private void bdivide_Click(object sender, EventArgs e)
        {
            int n = operand.Count - 1;
            if (operand[n] == "" || operand[n] == "+" || operand[n] == "-" || operand[n] == "*" || operand[n] == "/")
            {
                return;
            }
            else
            {
                operand.Add("/");
                operand.Add("");
                update();
            }
        }

        private void bret_Click(object sender, EventArgs e)
        {
            int n = operand.Count - 1;
            if (operand[n] == "")
            {
                if (n > 0 && (operand[n - 1] == "+" || operand[n - 1] == "-" || operand[n - 1] == "*" || operand[n - 1] == "/"))
                {
                    operand.RemoveAt(n);
                    n--;
                }
                operand.RemoveAt(n);
                update();
            }
            else
            {
                operand[n] = operand[n].Substring(0, operand[n].Length - 1);
                update();
            }
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            int n;
            while ((n = operand.Count - 1) >= 0 && new List<String>(new String[]{ "", "+", "-", "*", "/" }).Contains(operand[n]))
            {
                operand.RemoveAt(n);
            }
            update();
            oldcalc.Text += currcalc.Text + " = " + currnmb.Text + "\r\n";
            reset();
        }
    }
}
