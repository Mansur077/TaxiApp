using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MargulanTaxiApp
{
    partial class ShowResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // constructor takes cars and orders
        public ShowResults(List<Car> cars, List<Order> orders)
        {
            // initialize interfae
            InitializeComponent();
            this.cars = cars;
            this.orders = orders;

            // initialize tree view
            TreeNode carsNode = new TreeNode("Taxis");
            TreeNode falseNode = new TreeNode("Not distributed orders");

            // loop for each order
            foreach (var i in orders)
            {
                // just flag if order is not distributed
                bool order_dist = false;
                // loop for each car
                foreach (var j in cars)
                {
                    // time calculation
                    int orderStart = (i.getStartTime().Hour * 60) + i.getStartTime().Minute; 
                    int orderEnd = (i.getEndTime().Hour * 60) + i.getEndTime().Minute; 
                    int startTime = (j.getStartTime().Hour * 60) + j.getStartTime().Minute; 
                    int endTime = (j.getEndTime().Hour * 60) + j.getEndTime().Minute; 

                    // order is distributed
                    if (orderStart >= startTime && orderEnd <= endTime)
                    {
                        // new car time, carEndTime become orderEndTime
                        //Car car = new Car(j.getCarName(), i.getEndTime(), j.getEndTime());
                        cars.First(t => t.getCarName() == j.getCarName()).setStartTime(i.getEndTime());
                        // tree view
                        TreeNode carName = new TreeNode(j.getCarName() + j.getStartTime().ToString("HH:mm") + "-" 
                            + j.getEndTime().ToString("HH:mm"));
                        TreeNode orderName = new TreeNode(i.getClientName() + " " + i.getNumber() + " " + i.getStreet() + 
                            " " + i.getHouse() +" " + i.getStartTime().ToString("HH:mm") + 
                            "-" + i.getEndTime().ToString("HH:mm"));

                        // tree view validation
                        var result = carsNode.Nodes.OfType<TreeNode>().FirstOrDefault(node => node.Text.Equals(carName.Text));

                        // tree view methods
                        if (result != null)
                        {
                            result.Nodes.Add(orderName);
                            result.Expand();
                        }
                        else
                        {
                            carName.Nodes.Add(orderName);
                            carsNode.Nodes.Add(carName);
                            carName.Expand();
                            carsNode.Expand();
                        }
                        // break loop
                        order_dist = true;
                        break;

                    }
                }
                // if order is non distributed
                if(!order_dist)
                {
                    // tree view methods
                    TreeNode orderName = new TreeNode(i.getClientName() + " " + i.getNumber() + " " + i.getStreet() +
                        " " + i.getHouse() + " " + i.getStartTime().ToString("HH:mm") +
                        "-" + i.getEndTime().ToString("HH:mm"));
                    falseNode.Nodes.Add(orderName);
                    falseNode.Expand();
                }
            }



            // tree view show
            carsNode.Expand();
            falseNode.Expand();

            this.treeView1.Nodes.Add(carsNode);
            this.treeView1.Nodes.Add(falseNode);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowResults));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(495, 426);
            this.treeView1.TabIndex = 0;
            // 
            // ShowResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 450);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(541, 497);
            this.MinimumSize = new System.Drawing.Size(541, 497);
            this.Name = "ShowResults";
            this.Text = "ShowResults";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowResults_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private List<Car> cars = new List<Car>();
        private List<Order> orders = new List<Order>();
    }
}