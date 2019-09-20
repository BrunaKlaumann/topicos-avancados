using ConFinClient.Controle;
using ConFinClient.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConFinClient
{
    public partial class FrmNovoEstado : Form
    {
        public FrmNovoEstado()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ButtonSalvar_Click(object sender, EventArgs e)
        {
            string sigla = textBoxSigla.Text;
            string nome = textBoxNome.Text;
            Estado estado = new Estado();
            estado.est_sigla = sigla;
            estado.nome = nome;
            //metodo para cadastro
            string info =  await EstadoServices.PostEstado(estado);
            if(info == "OK")
            {
                MessageBox.Show("Estado incluido com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Não de3u");
            }
        }
    }
}
