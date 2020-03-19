using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado_2020
{
    public partial class Form1 : Form
    {
        //almacena la palabra que hay que adivinar
        String palabraOculta;
        //variable que almacena el numero de fallos
        int numeroFallos = 0;
        String palabraGuiones;
        public Form1()
        {
            InitializeComponent();
            palabraOculta = eligePalabra();
        }
        public String eligePalabra()
        {
            String[] listaPalabras = { "Caca", "Cerveza", "Toma","DOOM","Fight Club" };
            Random aleatorio = new Random();
            int pos = aleatorio.Next(listaPalabras.Length);
            return listaPalabras[pos].ToUpper();
        }

        private void letraPulsada(object sender, EventArgs e)
        {
            //casteo el objeto a botón. Sólo va a poder ser botón porque
            //sólo se genera en los botones
            Button miBoton = (Button)sender;
            String letra = miBoton.Text;
            letra = letra.ToUpper();
            //chequear si la letra está en la palabraOculta
            if (palabraOculta.Contains(letra))
            {
                int posicion = palabraOculta.IndexOf(letra);
                label1.Text = label1.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);
            }
            else
            {
                numeroFallos++;
            }
            if (!label1.Text.Contains('_'))
            {
                numeroFallos = -100;
            }
            switch (numeroFallos)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources.ahorcado_0;
                    break;
                case 1:
                    pictureBox1.Image = Properties.Resources.ahorcado_1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.ahorcado_2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.ahorcado_3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.ahorcado_4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.ahorcado_5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.ahorcado_fin;
                    break;
                case -100: pictureBox1.Image = Properties.Resources.acertastetodo;
                    break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin;
                    break;
            }
        }
    }
}
