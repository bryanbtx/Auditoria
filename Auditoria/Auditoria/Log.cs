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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tabela="", transac="";
            switch (comboBox1.Text)
            {
                case "perfil":
                    tabela = "p";
                    break;
                case "permicao":
                    tabela = "m";
                    break;
                case "categoria":
                    tabela = "c";
                    break;
                case "receita":
                    tabela = "r";
                    break;
                case "dispesa_fixa":
                    tabela = "f";
                    break;
                case "dispesa_variavel":
                    tabela = "v";
                    break;
            }
            switch (comboBox2.Text)
            {
                case "insert":
                    transac = "i";
                    break;
                case "update":
                    transac = "u";
                    break;
                case "delete":
                    transac = "d";
                    break;
            }
            if (comboBox1.SelectedIndex >-1 && comboBox2.SelectedIndex > -1)
            {
                dataGridView1.DataSource = DataBase.Query("select * from log where tabela='"+tabela+"' and transac='"+transac+"'").DefaultView;
            }
            else if (comboBox1.SelectedIndex > -1)
            {
                dataGridView1.DataSource = DataBase.Query("select * from log where tabela='" + tabela + "'").DefaultView;
            }
            else if (comboBox2.SelectedIndex > -1)
            {
                dataGridView1.DataSource = DataBase.Query("select * from log where transac='" + transac + "'").DefaultView;
            }
            else
            {
                dataGridView1.DataSource = DataBase.Query("select * from log").DefaultView;
            }
        }
    }
}
