using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorDeMoeda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReal.Clear();
            txtResultado.Clear();
            string moedaSelecionada = comboBox1.SelectedItem?.ToString();

            if (moedaSelecionada != null)
            {
                if (moedaSelecionada.Contains("USD"))
                {
                    labelResultado.Text = "Valor Convertido (USD)";
                }

                else if (moedaSelecionada.Contains("EUR"))
                {
                    labelResultado.Text = "Valor Convertido (EUR)";
                }

                else if (moedaSelecionada.Contains("GBP"))
                {
                    labelResultado.Text = "Valor Convertido (GBP)";
                }

                else if (moedaSelecionada.Contains("JPY"))
                {
                    labelResultado.Text = "Valor Convertido (JPY)";
                }

                else
                {
                    labelResultado.Text = "Valor Convertido (CNY)";
                }

            }

        }

        private double calculoUSD(double real)
        {
            return real * 0.20;
        }
        private double calcularEUR(double real)
        {
            return real * 0.18;
        }
        private double calcularGBP(double real)
        {
            return real * 0.15;
        }
        private double calcularJPY(double real)
        {
            return real * 31.21;
        }
        private double calcularCNY(double real)
        {
            return real * 1.32;
        }

        private async void btnResultado_Click(object sender, EventArgs e)
        {
            string moedaSelecionada = comboBox1.SelectedItem?.ToString();
            bool realValido = double.TryParse(txtReal.Text, out double real);
            if (realValido && real >= 0)
            {
                if (moedaSelecionada != null)
                {
                    if (moedaSelecionada.Contains("USD"))
                    {
                        txtResultado.Text = calculoUSD(real).ToString("C2");
                    }

                    else if (moedaSelecionada.Contains("EUR"))
                    {
                        txtResultado.Text = calcularEUR(real).ToString("C2");
                    }

                    else if (moedaSelecionada.Contains("GBP"))
                    {
                        txtResultado.Text = calcularGBP(real).ToString("C2");
                    }

                    else if (moedaSelecionada.Contains("JPY"))
                    {
                        txtResultado.Text = calcularJPY(real).ToString("C2");
                    }

                    else
                    {
                        txtResultado.Text = calcularCNY(real).ToString("C2");
                    }
                }
                else
                {
                    labelErroComboBox.Visible = true;
                    System.Media.SystemSounds.Hand.Play();
                    txtReal.Clear();
                    txtResultado.Clear();
                    comboBox1.SelectedIndex = -1;
                    await Task.Delay(4000);
                    labelErroComboBox.Visible = false;
                }
            }
            else
            {
                labelErrotxtReal.Visible = true;
                System.Media.SystemSounds.Hand.Play();
                txtReal.Clear();
                txtResultado.Clear();
                comboBox1.SelectedIndex = -1;
                await Task.Delay(4000);
                labelErrotxtReal.Visible = false;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtReal.Clear();
            txtResultado.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
