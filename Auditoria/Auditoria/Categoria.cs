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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();

            dataGridView1.DataSource = DataBase.Query("select * from categoria");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                nome=textBox1.Text,
                descricao=textBox2.Text;
            if (DataBase.Comand("insert into categoria values(null,'"+nome+"','"+descricao+"')") > 0)
            {
                MessageBox.Show("Categoria criada");
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }

            dataGridView1.DataSource = DataBase.Query("select * from categoria");
        }
    }
}
