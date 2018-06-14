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
    public partial class Balanco : Form
    {
        public Balanco()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Dados incorretos");
                return;
            }
            string date1 = "'" + textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text + "'",
                   date2 = "'" + textBox4.Text + "-" + textBox5.Text + "-" + textBox6.Text + "'";
            string
                receita = DataBase.Query("select sum(valor) from receita where `data` BETWEEN " + date1 + " and " + date2).Rows[0][0].ToString(),
                fixa = DataBase.Query("select sum(valor) from dispesa_fixa").Rows[0][0].ToString(),
                variavel = DataBase.Query("select sum(valor) from dispesa_variavel where `data` BETWEEN " + date1 + " and " + date2).Rows[0][0].ToString(),
                msg = "Info:";
            double balanco = 0;
            if (receita != "")
            {
                msg += "\nReceita: " + receita;
                balanco += Double.Parse(receita);
            }
            if (fixa != "")
            {
                msg += "\nDispesa fixa: " + fixa;
                balanco -= Double.Parse(fixa);
            }
            if (variavel != "")
            {
                msg += "\nDispesa variavel: " + variavel;
                balanco -= Double.Parse(variavel);
            }
            msg += "\nBalanco: " + balanco;
            label3.Text = msg;
        }
    }
}
