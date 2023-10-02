using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MargulanTaxiApp
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check is fields are full
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0 
                && textBox4.TextLength > 0 && textBox5.TextLength > 0 
                && textBox6.TextLength > 0)
            {


                // Time validation
                try
                {
                    DateTime startTime = DateTime.Parse(textBox5.Text);

                    int minutes = Convert.ToInt32(textBox6.Text);
                    DateTime endTime = DateTime.Parse(textBox5.Text).AddMinutes(minutes);

                    order = new Order(textBox1.Text, textBox2.Text, textBox3.Text,
                                        textBox4.Text, startTime, endTime);

                    this.DialogResult = DialogResult.OK;

                }
                // Error message
                catch
                {
                    MessageBox.Show("Enter time correctly");
                    return;
                }

                
            }
            // Error message
            else
                MessageBox.Show("Enter values");
        }



        public Order returnOrder()
        {
            return this.order;
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
