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
    public partial class Receita : Form
    {
        string[] categoria, id;

        public Receita()
        {
            InitializeComponent();
        }

        public Receita(bool editar)
        {
            InitializeComponent();

            dataGridView1.DataSource = DataBase.Query("select * from receita").DefaultView;
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
                data = textBox2.Text,
                descricao = textBox3.Text,
                id_categoria = comboBox1.SelectedIndex == -1 ? "null" : id[comboBox1.SelectedIndex];
            if(DataBase.Comand("insert into receita values(null,"+valor+",'"+data+"','"+descricao+"',"+id_categoria+")") > 0)
            {
                MessageBox.Show("Receita inserida");
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }

            dataGridView1.DataSource = DataBase.Query("select * from receita").DefaultView;
        }
    }
}
