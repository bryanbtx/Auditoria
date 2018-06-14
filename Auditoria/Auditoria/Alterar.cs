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
    public partial class Alterar : Form
    {
        string[] nome, id;

        public Alterar()
        {
            InitializeComponent();

            DataTable data = DataBase.Query("select * from perfil");
            nome = new string[data.Rows.Count];
            id = new string[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                nome[i] = data.Rows[i]["nome"].ToString();
                id[i] = data.Rows[i]["id"].ToString();
            }
            comboBox1.Items.AddRange(nome);
        }

        private void button1_Click(object sender, EventArgs e)
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
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Escolha um perfil");
                return;
            }
            if (DataBase.Comand("update permicao set criar_perfil=" + criar_perfil + ",alterar_permicao=" + alterar_permicao + ",criar_categoria=" + criar_categoria + ",receita_r=" + receita_r + ",receita_w=" + receita_w + ",dispesa_r=" + dispesa_r + ",dispesa_w=" + dispesa_w + ",ler_log=" + ler_log + " where id_perfil=" + id[comboBox1.SelectedIndex]) > 0)
            {
                MessageBox.Show("Permicoes alteradas");
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }
        }
    }
}
