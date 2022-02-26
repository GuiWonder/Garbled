using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garbled
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void textBoxIn_TextChanged(object sender, EventArgs e)=> textBoxOut.Text = GetText(comboBox1.Text);

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => textBoxOut.Text = GetText(comboBox1.Text);

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => textBoxOut.Text = GetText(comboBox1.Text);

        private void buttonAll_Click(object sender, EventArgs e)
        {
            textBoxOut.Clear();
            foreach (string item in comboBox1.Items)
            {
                textBoxOut.AppendText(item + "：\r\n");
                textBoxOut.AppendText( GetText(item) +"\r\n\r\n\r\n");
            }
        }

        private string GetText(string mode)
        {
            string[] coco = mode.Split(' ');
            string co1 = coco[0].Split('码')[1];
            string co2 = coco[1].Substring(2);

            if (radioButton2.Checked)
            {
                string tt = co1;
                co1 = co2;
                co2 = tt;
            }

            byte[] ss = Encoding.GetEncoding(co2).GetBytes(textBoxIn.Text);
            return Encoding.GetEncoding(co1).GetString(ss);
        }
    }
}
