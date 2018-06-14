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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text, senha = maskedTextBox1.Text;
            DataTable data = DataBase.Query("select * from perfil where login='" + login + "' and senha='" + senha + "';");
            if (data.Rows.Count == 1)
            {
                DataTable permicao = DataBase.Query("select criar_perfil,alterar_permicao,criar_categoria,receita_r,receita_w,dispesa_r,dispesa_w,ler_log from permicao where id_perfil=" + data.Rows[0]["id"].ToString() + ";");

                Menu menu = new Menu(permicao, data.Rows[0]["id"].ToString());
                Hide();
                menu.FormClosed += new FormClosedEventHandler(ShowWhenClosed);
                menu.Text = data.Rows[0]["nome"].ToString();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Login ou senha incorretos");
            }
        }

        private void ShowWhenClosed(object sender,EventArgs e)
        {
            maskedTextBox1.Text = "";
            Show();
        }
    }
}
