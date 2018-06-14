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
    public partial class Menu : Form
    {
        private bool
            criar_perfil,
            alterar_perfil,
            criar_categoria,
            receita_r,
            receita_w,
            dispesa_r,
            dispesa_w,
            ler_log;
        private int width = Constant.BUTTON_WIDTH, height = Constant.BUTTON_HEIGHT, offset = Constant.BUTTON_OFFSET, n = 0;
        private string id;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(DataTable permicao,string perfilId)
        {
            InitializeComponent();

            id = perfilId;

            criar_perfil = Boolean.Parse(permicao.Rows[0]["criar_perfil"].ToString());
            alterar_perfil = Boolean.Parse(permicao.Rows[0]["alterar_permicao"].ToString());
            criar_categoria = Boolean.Parse(permicao.Rows[0]["criar_categoria"].ToString());
            receita_r = Boolean.Parse(permicao.Rows[0]["receita_r"].ToString());
            receita_w = Boolean.Parse(permicao.Rows[0]["receita_w"].ToString());
            dispesa_r = Boolean.Parse(permicao.Rows[0]["dispesa_r"].ToString());
            dispesa_w = Boolean.Parse(permicao.Rows[0]["dispesa_w"].ToString());
            ler_log = Boolean.Parse(permicao.Rows[0]["ler_log"].ToString());

            if (criar_perfil)
            {
                ButtonCreate("Criar perfil");
            }
            if (alterar_perfil)
            {
                ButtonCreate("Alterar permicao");
            }
            if (criar_categoria)
            {
                ButtonCreate("Criar categoria");
            }
            if (receita_r)
            {
                ButtonCreate("Receita");
            }
            if (dispesa_r)
            {
                ButtonCreate("Dispesa");
            }
            if (ler_log)
            {
                ButtonCreate("Log");
            }
            ButtonCreate("Balanco");
            ButtonCreate("Editar perfil atual");
        }

        private void ButtonCreate(string title)
        {
            Button button = new Button();
            button.TabIndex = n;
            button.Width = width;
            button.Height = height;
            button.Location = new Point(offset, offset + n * height);
            button.Text = title;
            button.Click += new EventHandler(ButtonClick);
            Controls.Add(button);
            n++;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Criar perfil":
                    Criar criar = new Criar();
                    criar.Show();
                    break;
                case "Alterar permicao":
                    Alterar alterar = new Alterar();
                    alterar.Show();
                    break;
                case "Criar categoria":
                    Categoria categoria = new Categoria();
                    categoria.Show();
                    break;
                case "Receita":
                    Receita receita = new Receita(receita_w);
                    receita.Show();
                    break;
                case "Dispesa":
                    Dispesa dispesa = new Dispesa(dispesa_w);
                    dispesa.Show();
                    break;
                case "Log":
                    Log log = new Log();
                    log.Show();
                    break;
                case "Balanco":
                    Balanco balanco = new Balanco();
                    balanco.Show();
                    break;
                case "Editar perfil atual":
                    Editar editar = new Editar(id,this);
                    editar.Show();
                    break;
            }
        }
    }
}
