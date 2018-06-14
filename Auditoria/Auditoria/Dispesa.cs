using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auditoria
{
    public partial class Dispesa : Form
    {
        string[] categoria, id;

        public Dispesa()
        {
            InitializeComponent();
        }

        public Dispesa(bool editar)
        {
            InitializeComponent();

            if (!editar)
            {
                panel1.Visible = false;
                Height = 443;
            }

            DataTable data = DataBase.Query("select * from categoria");
            categoria = new string[data.Rows.Count];
            id = new string[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                categoria[i] = data.Rows[i]["nome"].ToString();
                id[i] = data.Rows[i]["id"].ToString();
            }
            comboBox1.Items.AddRange(categoria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                valor = textBox1.Text,
                descricao = textBox3.Text,
                id_categoria = comboBox1.SelectedIndex == -1 ? "null" : id[comboBox1.SelectedIndex];
            if (DataBase.Comand("insert into dispesa_fixa values(null," + valor + ",'" + descricao + "'," + id_categoria + ")") > 0)
            {
                MessageBox.Show("Dispesa inserida");
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string
                valor = textBox1.Text,
                data = textBox2.Text,
                descricao = textBox3.Text,
                id_categoria = comboBox1.SelectedIndex == -1 ? "null" : id[comboBox1.SelectedIndex];
            if (DataBase.Comand("insert into dispesa_variavel values(null," + valor + ",'" + data + "','" + descricao + "'," + id_categoria + ")") > 0)
            {
                MessageBox.Show("Dispesa inserida");
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.Query("select * from dispesa_fixa");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBase.Query("select * from dispesa_variavel");
        }
    }
}
