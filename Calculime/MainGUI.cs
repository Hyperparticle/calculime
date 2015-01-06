using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculime
{
    public partial class MainGUI : Form
    {
        private long input0 = 0;
        private long input1 = 0;

        private bool left = true;

        public MainGUI()
        {
            InitializeComponent();

            update();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10;
            }
            else
            {
                input1 = input1 * 10;
            }

            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 1;
            }
            else
            {
                input1 = input1 * 10 + 1;
            }

            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 2;
            }
            else
            {
                input1 = input1 * 10 + 2;
            }

            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 3;
            }
            else
            {
                input1 = input1 * 10 + 3;
            }

            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 4;
            }
            else
            {
                input1 = input1 * 10 + 4;
            }

            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 5;
            }
            else
            {
                input1 = input1 * 10 + 5;
            }

            update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 6;
            }
            else
            {
                input1 = input1 * 10 + 6;
            }

            update();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 7;
            }
            else
            {
                input1 = input1 * 10 + 7;
            }

            update();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 8;
            }
            else
            {
                input1 = input1 * 10 + 8;
            }

            update();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = input0 * 10 + 9;
            }
            else
            {
                input1 = input1 * 10 + 9;
            }

            update();
        }

        private void update()
        {
            if (left)
            {
                textBoxOutput.Text = input0.ToString();
            }
            else
            {
                textBoxOutput.Text = input1.ToString();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = 0;
                input1 = 0;
            }
            else
            {
                if (input1 == 0)
                {
                    input0 = 0;
                    left = false;
                }
                else
                {
                    input1 = 0;
                }
            }

            update();
        }

        private void buttonNeg_Click(object sender, EventArgs e)
        {
            if (left)
            {
                input0 = -input0;
            }
            else
            {
                input1 = -input1;
            }

            update();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {

        }

    }
}
