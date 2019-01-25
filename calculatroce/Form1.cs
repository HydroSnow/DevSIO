using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatroce
{
    public partial class Form1 : Form
    {
        private List<String> operand;
        private bool ignore_nmb = false;

        public Form1()
        {
            InitializeComponent();
            operand = new List<String>();
        }

        private void d0_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "0";
        }

        private void d1_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "1";
        }

        private void d2_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "2";
        }

        private void d3_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "3";
        }

        private void d4_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "4";
        }

        private void d5_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "5";
        }

        private void d6_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "6";
        }

        private void d7_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "7";
        }

        private void d8_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "8";
        }

        private void d9_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            currnmb.Text += "9";
        }

        private void bdot_Click(object sender, EventArgs e)
        {
            if (ignore_nmb)
            {
                reset();
            }

            if (!currnmb.Text.Contains(","))
            {
                if (currnmb.Text == "")
                {
                    currnmb.Text += "0,";
                }
                else
                {
                    currnmb.Text += ",";
                }
            }
        }

        private void refresh_operand()
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
                else
                {
                    currcalc.Text += str;
                }
            }
        }

        private void calc_operand()
        {
            double act = Convert.ToDouble(operand[0]);
            for (int a = 1; a < operand.Count; a++)
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

            currnmb.Text = "" + act;
        }

        private void reset()
        {
            operand.Clear();
            ignore_nmb = false;
            currcalc.Text = "";
            currnmb.Text = "";
        }

        private void bplus_Click(object sender, EventArgs e)
        {
            int last = operand.Count - 1;
            if (last < 0 && currnmb.Text == "")
            {
                return;
            }
            else if (last >= 0 && (operand[last] == "+" || operand[last] == "-" || operand[last] == "*" || operand[last] == "/"))
            {
                return;
            }
            else
            {
                if (!ignore_nmb)
                {
                    operand.Add(currnmb.Text);
                }
                else
                {
                    ignore_nmb = false;
                }

                operand.Add("+");
                currnmb.Text = "";
                refresh_operand();
            }
        }

        private void bminus_Click(object sender, EventArgs e)
        {
            if (currnmb.Text == "")
            {
                currnmb.Text += "-";
            }
            else if (currnmb.Text == "-")
            {
                return;
            }
            else
            {
                if (!ignore_nmb)
                {
                    operand.Add(currnmb.Text);
                }
                else
                {
                    ignore_nmb = false;
                }

                operand.Add("-");
                currnmb.Text = "";
                refresh_operand();
            }
        }

        private void btimes_Click(object sender, EventArgs e)
        {
            int last = operand.Count - 1;
            if (last < 0 && currnmb.Text == "")
            {
                return;
            }
            else if (last >= 0 && (operand[last] == "+" || operand[last] == "-" || operand[last] == "*" || operand[last] == "/"))
            {
                return;
            }
            else
            {
                if (!ignore_nmb)
                {
                    operand.Add(currnmb.Text);
                }
                else
                {
                    ignore_nmb = false;
                }

                operand.Add("*");
                currnmb.Text = "";
                refresh_operand();
            }
        }

        private void bdivide_Click(object sender, EventArgs e)
        {
            int last = operand.Count - 1;
            if (last < 0 && currnmb.Text == "")
            {
                return;
            }
            else if (last >= 0 && (operand[last] == "+" || operand[last] == "-" || operand[last] == "*" || operand[last] == "/"))
            {
                return;
            }
            else
            {
                if (!ignore_nmb)
                {
                    operand.Add(currnmb.Text);
                }
                else
                {
                    ignore_nmb = false;
                }

                operand.Add("/");
                currnmb.Text = "";
                refresh_operand();
            }
        }

        private void beq_Click(object sender, EventArgs e)
        {
            if (!ignore_nmb)
            {
                operand.Add(currnmb.Text);
            }
            else
            {
                ignore_nmb = false;
            }

            currnmb.Text = "";
            refresh_operand();
            calc_operand();
            ignore_nmb = true;
        }

        private void bret_Click(object sender, EventArgs e)
        {
            if (ignore_nmb || currnmb.Text == "")
            {
                int last = operand.Count - 1;
                if (last >= 0 && (operand[last] == "+" || operand[last] == "-" || operand[last] == "*" || operand[last] == "/"))
                {
                    operand.RemoveAt(operand.Count - 1);
                }
                currnmb.Text = operand[operand.Count - 1];
                operand.RemoveAt(operand.Count - 1);
                refresh_operand();
                ignore_nmb = false;
            }
            else
            {
                currnmb.Text = currnmb.Text.Substring(0, currnmb.Text.Length - 1);
            }
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
