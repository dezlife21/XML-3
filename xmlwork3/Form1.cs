using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace xmlwork3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Âèáåðiòü ðÿäîê äëÿ âèäàëåííÿ.", "Ïîìèëêà.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Çàïîâíiòü óñi ïîëÿ. Ïîìèëêà");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("Âèáåðiòü ðÿäîê.", "Ïîìëèêà.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("Programmer");
                dt.Columns.Add("English");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Name"] = r.Cells[0].Value;
                    row["Age"] = r.Cells[1].Value;
                    row["Programmer"] = r.Cells[2].Value;
                    row["English"] = r.Cells[3].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                    ds.WriteXml("C:\\wpl\\XML.xml");
                    MessageBox.Show("XML ôàéë óñïiøíî çáåðåæåí.", "good.");
                }
            }
            catch
            {
                MessageBox.Show("Íåìîæëèîâ çáåðåãòè ôàéë.", "Ïîìèëêà.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Òàáëèöÿ ïóñòà.", "Ïîìèëêà.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 0)
            {
                MessageBox.Show("Î÷èñòiòü ïîëå.", "Ïîìèëêà.");
            }
            else
            {
                if (File.Exists("C:\\wpl\\XML.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("C:\\wpl\\XML.xml");

                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Age"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Programmer"];
                        dataGridView1.Rows[n].Cells[3].Value = item["English"];
                    }
                }
                else
                {
                    MessageBox.Show("XML ôàéë íå çíàéäåí.", "Ïîìèëêà.");
                }
            }
        }
    }
}
