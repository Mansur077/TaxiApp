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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Add car from file
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // Open files
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            string[] fileTextSplited = fileText.Split('\n');

            // Data validation
            try
            {
                // Loop for each row
                foreach (var item in fileTextSplited)
                {
                    // Parse the file
                    string[] vs = item.Split(' ');

                    // Add car to cars
                    Car car = new Car(vs[0], DateTime.Parse(vs[1]), DateTime.Parse(vs[2]));
                    cars.Add(car);

                }
            }
            // Error message
            catch
            {
                MessageBox.Show("This data already exist");
                return;
            }

            // view new car
            this.listView1.Clear();

            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Name", 120);
                listView1.Columns.Add("Start time", 80);
                listView1.Columns.Add("End time", 80);
            }
            List<ListViewItem> ListItems = new List<ListViewItem>();
            foreach (var i in cars)
            {
                ListViewItem item = new ListViewItem(i.getCarName());
                item.SubItems.Add(i.getStartTime().ToString("HH:mm"));
                item.SubItems.Add(i.getEndTime().ToString("HH:mm"));
                ListItems.Add(item);

            }
            this.listView1.Items.AddRange(ListItems.ToArray());

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add order form method
            AddOrder addOrderForm = new AddOrder();
            addOrderForm.ShowDialog();
            
            // Data validation
            if (addOrderForm.DialogResult == DialogResult.OK)
            {
                // Add new order to orders
                Order order = addOrderForm.returnOrder();
                orders.Add(order);

                // Add items to ListView
                ListViewItem item = new ListViewItem(order.getClientName());
                item.SubItems.Add(order.getNumber().ToString());
                item.SubItems.Add(order.getStreet());
                item.SubItems.Add(order.getNumber().ToString());

                item.SubItems.Add(order.getStartTime().ToString("HH:mm"));
                item.SubItems.Add(order.getEndTime().ToString("HH:mm"));

                // View new order
                if (listView2.Columns.Count == 0)
                {
                    listView2.Columns.Add("Client name", 90);
                    listView2.Columns.Add("Number", 100);
                    listView2.Columns.Add("Street", 100);
                    listView2.Columns.Add("House", 50);
                    listView2.Columns.Add("Taxi time", 60);
                    listView2.Columns.Add("Duration", 60);
                }

                this.listView2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add car form method
            AddCar addCarForm = new AddCar();
            addCarForm.ShowDialog();

            // If fields are valid
            if (addCarForm.DialogResult == DialogResult.OK)
            {
                // Add new car to cars
                Car car = addCarForm.returnCar();
                cars.Add(car);

                // View new car in ListView
                ListViewItem item = new ListViewItem(car.getCarName());
                item.SubItems.Add(car.getStartTime().ToString("HH:mm"));
                item.SubItems.Add(car.getEndTime().ToString("HH:mm"));

                // View new car
                if (listView1.Columns.Count == 0)
                {
                    listView1.Columns.Add("Name", 120);
                    listView1.Columns.Add("Start time", 80);
                    listView1.Columns.Add("End time", 80);
                }

                this.listView1.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Result form method
            if (this.orders.Count == 0 || this.cars.Count == 0)
            {
                MessageBox.Show("Enter orders or cars");
            }
            else
            {
                ShowResults showResultsForm = new ShowResults(cars, orders);
                showResultsForm.ShowDialog();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Add orders from file method
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // Read file
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            string[] fileTextSplited = fileText.Split('\n');


            // Data validation check
            try
            {
                // Loop every row
                foreach (var stringOfFile in fileTextSplited)
                {
                    // Parse data
                    string[] vs = stringOfFile.Split(' ');
                    int minutes = Convert.ToInt32(vs[5]);
                    DateTime newDate = DateTime.Parse(vs[4]).AddMinutes(minutes);

                    // Add order to Orders
                    Order order = new Order(vs[0], vs[1], vs[2], vs[3], DateTime.Parse(vs[4]), newDate);

                    orders.Add(order);
                }

            }
            catch
            {
                // Error message
                MessageBox.Show("This data already exist");
                return;
            }

            // view new car
            this.listView2.Clear();

            // View new order
            if (listView2.Columns.Count == 0)
            {
                listView2.Columns.Add("Client name", 90);
                listView2.Columns.Add("Number", 100);
                listView2.Columns.Add("Street", 100);
                listView2.Columns.Add("House", 50);
                listView2.Columns.Add("Taxi time", 60);
                listView2.Columns.Add("Duration", 60);
            }

            List<ListViewItem> ListItems = new List<ListViewItem>();
            foreach (var i in orders)
            {
                // Add items to ListView
                ListViewItem item = new ListViewItem(i.getClientName());
                item.SubItems.Add(i.getNumber().ToString());
                item.SubItems.Add(i.getStreet());
                item.SubItems.Add(i.getHouse().ToString());

                item.SubItems.Add(i.getStartTime().ToString("HH:mm"));
                item.SubItems.Add(i.getEndTime().ToString("HH:mm"));
                ListItems.Add(item);

            }
            this.listView2.Items.AddRange(ListItems.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Find a car, search box
            if (this.textBox1.Text.Length > 0)
            {
                // Search method
                var thisTag = cars.FirstOrDefault(t => t.getCarName() == this.textBox1.Text);
                
                // If it found
                if (thisTag.getCarName() != null)
                {
                    MessageBox.Show(thisTag.getCarName() + " " + thisTag.getStartTime().ToString("HH:mm") +
                        " " + thisTag.getEndTime().ToString("HH:mm"));
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            else
            {
                MessageBox.Show("Enter text");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
