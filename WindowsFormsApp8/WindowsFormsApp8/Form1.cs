using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        RegistryKey reg;

        public Form1()
        {
            InitializeComponent();
            reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            string[] names = reg.GetValueNames();
            foreach (string name in names)
            {
                listBox1.Items.Add(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            reg.SetValue(textBox1.Text, textBox2.Text);
            listBox1.Items.Add(textBox1.Text);
            reg.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            reg.DeleteValue(listBox1.SelectedItem.ToString());
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            reg.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryTree form = new RegistryTree();
            form.Show();
        }
    }
}