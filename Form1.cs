using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeYourOwnRetailApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            items.Items.Clear();
            items.Items.Add("Chicken Item 1");
            items.Items.Add("Chicken Item 2");
            items.Items.Add("Chicken Item 3");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {           
            
            items.Items.Clear();
            items.Items.Add("Red Meat 1");
            items.Items.Add("Red Meat 2");
            items.Items.Add("Red Meat 3");
        }

        private void items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (items.SelectedItem.ToString() == "Chicken Item 1")
            {
                price.Text = "3";
            }
            else if (items.SelectedItem.ToString() == "Chicken Item 2")
            {
                price.Text = "5";
            }
            else if (items.SelectedItem.ToString() == "Chicken Item 3")
            {
                price.Text = "7";
            }
            else if (items.SelectedItem.ToString() == "Red Meat 1")
            {
                price.Text = "4";
            }
            else if (items.SelectedItem.ToString() == "Red Meat 2")
            {
                price.Text = "6";
            }
            else if (items.SelectedItem.ToString() == "Red Meat 3")
            {
                price.Text = "8";
            }
            else
            {
                price.Text = "0";
            }

            total.Text = "";   
            qty.Text = "";  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(qty.Text.Length > 0)
            total.Text = (Convert.ToInt16(price.Text) * Convert.ToInt16(qty.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[4];
            arr[0] = items.SelectedItem.ToString();
            arr[1] = price.Text;
            arr[2] = qty.Text;
            arr[3] = total.Text;

            ListViewItem lvi = new ListViewItem(arr);
            listView1.Items.Add(lvi);

            sub.Text = (Convert.ToInt16(sub.Text) + Convert.ToInt16(total.Text)).ToString();
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
          if (dis.Text.Length > 0)
          {
                net.Text = (Convert.ToInt16(sub.Text) - Convert.ToInt16(dis.Text)).ToString();
          }
        }

        private void paid_TextChanged(object sender, EventArgs e)
        {
            if (paid.Text.Length > 0)
            {
                balance.Text = (Convert.ToInt16(net.Text) - Convert.ToInt16(paid.Text)).ToString();
            }
        }

        private void rem_Click(object sender, EventArgs e)
        {
           if (listView1.SelectedItems.Count > 0)
           {
             for (int i=0; i < listView1.Items.Count; i++)
             {
                    if (listView1.Items[i].Selected)
                    {
                        sub.Text = (Convert.ToInt16(sub.Text) - Convert.ToInt16(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();
                    }
             } 
           }
        }
    }
}
