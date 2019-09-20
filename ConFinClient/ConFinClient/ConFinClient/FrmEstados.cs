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
    public partial class FrmEstados : Form
    {
        public FrmEstados()
        {
            InitializeComponent();
            this.AtualizaTela();
        }

        private async void AtualizaTela()
        {
            List<Estado> lista = await EstadoServices.GetEstados();
            dataGridView1.DataSource = lista;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonNovo_Click(object sender, EventArgs e)
        {
            FrmNovoEstado form = new FrmNovoEstado();
            form.ShowDialog();
            AtualizaTela();
        }
    }
}
