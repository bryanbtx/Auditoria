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
    public partial class Editar : Form
    {
        private string id;
        private Menu menu;

        public Editar()
        {
            InitializeComponent();
        }

        public Editar(string id,Menu menu)
        {
            InitializeComponent();

            this.id = id;
            this.menu = menu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text, senha = maskedTextBox1.Text, nome = textBox2.Text;

            if (DataBase.Comand("update perfil set login='" + login + "',senha='" + senha + "',nome='" + nome + "' where id=" + id + ";") > 0)
            {
                MessageBox.Show("Registro alterado");
                menu.Text = nome;
                Close();
            }
            else
            {
                MessageBox.Show("Nada foi alterado");
                Close();
            }
        }
    }
}
