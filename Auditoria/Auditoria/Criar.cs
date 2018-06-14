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
    public partial class Criar : Form
    {
        public Criar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                login = textBox1.Text,
                senha = maskedTextBox1.Text,
                nome = textBox2.Text;
            if (DataBase.Comand("insert perfil values(null,'" + login + "','" + senha + "','" + nome + "')") > 0)
            {
                int
                    criar_perfil = Convert.ToInt32(checkBox1.Checked),
                    alterar_permicao = Convert.ToInt32(checkBox2.Checked),
                    criar_categoria = Convert.ToInt32(checkBox3.Checked),
                    receita_r = Convert.ToInt32(checkBox4.Checked),
                    receita_w = Convert.ToInt32(checkBox5.Checked),
                    dispesa_r = Convert.ToInt32(checkBox6.Checked),
                    dispesa_w = Convert.ToInt32(checkBox7.Checked),
                    ler_log = Convert.ToInt32(checkBox8.Checked);
                int id = Int32.Parse(DataBase.Query("select max(id) from perfil").Rows[0][0].ToString());
                DataBase.Comand("insert permicao values(null," + criar_perfil + "," + alterar_permicao + "," + criar_categoria + "," + receita_r + "," + receita_w + "," + dispesa_r + "," + dispesa_w + "," + ler_log + "," + id + ")");
                MessageBox.Show("Perfil criado");
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }
        }
    }
}
