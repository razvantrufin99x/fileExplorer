using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string currentpath = "";
        public string currentdir = "";
       
        public List<string> stackpathdirs = new List<string>();

        public void createpath()
        {
            //create a path from list stackpathdirs and print in title of form
            Text = "";
            for (int i = 0; i < stackpathdirs.Count; i++)
            {
                
                Text += stackpathdirs[i].ToString();
                currentdir += stackpathdirs[i].ToString();
            }
             
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //find all logical drivers

           string [] logicaldrives =  Environment.GetLogicalDrives();
            //add all logical drivers in combobox1 for selection
           for (int i = 0; i < logicaldrives.Length; i++)
           {
               comboBox1.Items.Add(logicaldrives[i].ToString());
           }
            
            //select the text selected from combobox1 and add this is currentpath and in title of form
            comboBox1.SelectedItem= comboBox1.Items[0];
            comboBox1.SelectAll();

            currentpath = comboBox1.SelectedText;
            Text = currentpath;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search all dirs form current logical drive
            //and addthem all of the in listview1
            DirectoryInfo di = new DirectoryInfo(currentpath);
            DirectoryInfo[] directories = di.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
           {
               listView1.Items.Add(directories[i].ToString());
           }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select all text from combobox1
            //add text of combobox1 in current path and the nto title of form
            comboBox1.SelectAll();
            currentpath = comboBox1.SelectedText;
            Text = currentpath;
          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            

           
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            //find selected item
            ListViewItem item0 = listView2.SelectedItems[0];

             //updatepath
            //find path of selected intem
            ListViewItem item02 = listView2.SelectedItems[0];

            currentdir += "\\" +  item02.Text;

            Text = currentpath  + currentdir;


            //remove all from listaview2
            for (int i = listView2.Items.Count - 1; i >= 0; i--)
            {
                try
                {
                    ListViewItem item1 = listView2.Items[i];
                    listView2.Items.Remove(item1);
                }
                catch { }
            }

            //remove all from listaview1
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                try
                {
                    ListViewItem item2 = listView1.Items[i];
                    listView1.Items.Remove(item2);
                }
                catch { }
            }

            //add item0 in listview1
            listView1.Items.Add(item0);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //remove all items from listview2
            for (int i = listView2.Items.Count - 1; i >= 0; i--)
            {
                try
                {
                    ListViewItem item0 = listView2.Items[i];
                    listView2.Items.Remove(item0);
                }
                catch { }
            }

            try
            {
                //find path of selected intem
                ListViewItem item = listView1.SelectedItems[0];

                currentdir += "\\" + item.Text;

                Text = currentpath  + currentdir;



                // add all subdirectories of current directory on listview2
                DirectoryInfo di = new DirectoryInfo(currentpath + currentdir);
                DirectoryInfo[] directories = di.GetDirectories();
                for (int i = 0; i < directories.Length; i++)
                {
                    listView2.Items.Add(directories[i].ToString());
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add all subdirectories of current directory on listview2
            DirectoryInfo di = new DirectoryInfo(Text);
            DirectoryInfo[] directories = di.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                listView2.Items.Add(directories[i].ToString());
            }
        }
    }
}
