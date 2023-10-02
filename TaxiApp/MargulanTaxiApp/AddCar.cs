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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            // fields text check
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0)
            {
                // time validation check
                try
                {
                    DateTime startTime = DateTime.Parse(textBox2.Text);
                    DateTime endTime = DateTime.Parse(textBox3.Text);

                    Car car = new Car(textBox1.Text, startTime, endTime);
                    this.car = car;
                    

                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    // error message
                    MessageBox.Show("Enter time correctly");
                    return;
                }


                

            }
            // error message
            else
                MessageBox.Show("Enter values");
        }

        public Car returnCar()
        {
            return (this.car);
        }


        private void Yes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void AddCar_Load(object sender, EventArgs e)
        {

        }
    }
}
