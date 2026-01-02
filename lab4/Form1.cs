using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public FEFOCollection<Item> FEFO = new FEFOCollection<Item>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    break;
                case 1:
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    break;
                case 2:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = true;
                    break;
                default:
                    MessageBox.Show("Невозможная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            dateTimePicker1.Value = DateTime.Now.AddDays(1);
            dateTimePicker1.MinDate = DateTime.Now.AddDays(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string element_name = textBox1.Text;
                Item item = new Item(textBox1.Text, dateTimePicker1.Value);
                if (FEFO.Add(item) == false)
                {
                    MessageBox.Show("Срок годности уже истёк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item item = FEFO.PopBad();
            if (item == null)
            {
                MessageBox.Show("Список пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox2.Text = item.Name;
                dateTimePicker2.Value = item.DateTime_;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Item item = FEFO.PopFresh();
            if (item == null)
            {
                MessageBox.Show("Список пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox3.Text = item.Name;
                dateTimePicker3.Value = item.DateTime_;
            }
        }
    }
}
