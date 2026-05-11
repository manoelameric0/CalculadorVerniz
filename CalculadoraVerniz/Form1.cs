using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CalculadoraVerniz.Core.Models;
using CalculadoraVerniz.Core.Services;

namespace CalculadoraVerniz
{
    public partial class Form1 : Form
    {
        private TextBox txtLargura;
        private TextBox txtAltura;
        private Button btnAdicionar;
        private Button btnCalcular;
        private ListBox lstMedidas;
        private Button btnRemover;
        private Label lblAreaTotal;

        private Label lblResultado;

        private List<Medida> medidas = new List<Medida>();
        private readonly CalculoVernizService service = new CalculoVernizService(new Calculo());

        public Form1()
        {
            InicializarComponentes();
        }

        private async Task InicializarComponentes()
        {
            this.Text = "Calculadora de Verniz";
            this.Size = new Size(500, 500);

            // Largura
            txtLargura = new TextBox();
            txtLargura.Location = new Point(20, 20);
            txtLargura.Width = 100;
            txtLargura.PlaceholderText = "Largura";

            // Altura
            txtAltura = new TextBox();
            txtAltura.Location = new Point(140, 20);
            txtAltura.Width = 100;
            txtAltura.PlaceholderText = "Altura";

            // Botão Adicionar
            btnAdicionar = new Button();
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Location = new Point(260, 18);
            btnAdicionar.Click += BtnAdicionar_Click;

            // Lista
            lstMedidas = new ListBox();
            lstMedidas.Location = new Point(20, 60);
            lstMedidas.Size = new Size(440, 200);

            lstMedidas.SelectedIndexChanged += (s, e) =>
            {
                btnRemover.Enabled = lstMedidas.SelectedIndex >= 0;
            };

            // btRemoverSelecionado
            btnRemover = new Button();
            btnRemover.Text = "Remover (X)";
            btnRemover.Location = new Point(120, 310);
            btnRemover.Enabled = false;
            btnRemover.Click += BtnRemover_Click;

            this.Controls.Add(btnRemover);

            // Área total (tempo real)
            lblAreaTotal = new Label();
            lblAreaTotal.Location = new Point(20, 270);
            lblAreaTotal.Size = new Size(400, 30);
            lblAreaTotal.Text = "Área Total: 0 m²";

            // Botão Calcular
            btnCalcular = new Button();
            btnCalcular.Text = "Calcular";
            btnCalcular.Location = new Point(20, 310);
            btnCalcular.Click += BtnCalcular_Click;

            // Resultado final
            lblResultado = new Label();
            lblResultado.Location = new Point(20, 350);
            lblResultado.Size = new Size(440, 100);

            // Adiciona tudo na tela
            this.Controls.Add(txtLargura);
            this.Controls.Add(txtAltura);
            this.Controls.Add(btnAdicionar);
            this.Controls.Add(lstMedidas);
            this.Controls.Add(lblAreaTotal);
            this.Controls.Add(btnCalcular);
            this.Controls.Add(lblResultado);
        }

        private async void BtnRemover_Click(object sender, EventArgs e)
        {
            int index = lstMedidas.SelectedIndex;

            if (index >= 0)
            {
                await service.Remover(index);
                AtualizarLista();
            }
        }
        private async void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string larguraInput = txtLargura.Text;
                if (!decimal.TryParse(larguraInput, out decimal largura))
                {
                    MessageBox.Show("Largura inválida. Por favor, insira um número válido.");
                    return;
                }

                string alturaInput = txtAltura.Text;
                if (!decimal.TryParse(alturaInput, out decimal altura))
                {
                    MessageBox.Show("Altura inválida. Por favor, insira um número válido.");
                    return;
                }

                //var medida = new Medida(largura, altura);
                await service.AdicionarMedida(largura, altura);

                AtualizarLista();

                txtLargura.Clear();
                txtAltura.Clear();

                lblResultado.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AtualizarLista()
        {
            lstMedidas.Items.Clear();

            decimal areaTotal = 0;

            foreach (var m in await service.Medidas())
            {
                lstMedidas.Items.Add($"L: {m.Largura}cm | A: {m.Altura}cm | Área: {m.Area} m²");
                areaTotal += m.Area;
            }

            lblAreaTotal.Text = $"Área Total: {areaTotal} m²";
        }

        private async void BtnCalcular_Click(object sender, EventArgs e)
        {
            if (!await service.TemMedidas())
            {
                MessageBox.Show("Adicione pelo menos uma medida.");
                return;
            }

            var resultado = await service.CalcularTotais();

            // Limpa visual da lista (como você pediu)
            lstMedidas.Items.Clear();
            lblAreaTotal.Text = "";

            lblResultado.Text =
                $"Área Total: {resultado.AreaTotal:f2} m²\n" +
                $"ML Total: {resultado.MlTotal:f2} ml\n" +
                $"Verniz: {resultado.Verniz:f2} ml\n" +
                $"Catalizador: {resultado.Catalizador:f2} ml";
        }
    }
}