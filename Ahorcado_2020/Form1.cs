﻿using System;
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
        /*WRITTEN AND DIRECTED BY ALVARO GARCIA HERRERO
         * Ahorcado, funciona con palabras que salen de forma aleatoria dentro de un array.
         * Imagenes de perder y ganar cambiadas.
         * 
         */
        //almacena la palabra que hay que adivinar
        String palabraOculta = eligePalabra();
        //variable que almacena el numero de fallos
        int numeroFallos = 0;
        String palabraGuiones;
        public Form1()
        {
            InitializeComponent();
            String _palabraGuiones = "";
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                if (palabraOculta[i] != ' ')
                {
                    _palabraGuiones += "_ ";
                }
                else
                {
                    _palabraGuiones += "  ";
                }
                label1.Text = _palabraGuiones;
            }

        }
        private static String eligePalabra()
        {
            String[] listaPalabras = { "HolA", "Ganador", "Doom","Cerveza","el Hoyo" };
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
                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    if (palabraOculta[i] == letra[0])
                    {
                        label1.Text = label1.Text.Remove(2 * i, 1).Insert(2 * i, letra);
                    }
                }
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
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; 
                    break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; 
                    break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; 
                    break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; 
                    break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; 
                    break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5;
                    break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin;
                    break;
                case -100: pictureBox1.Image = Properties.Resources.acertastetodo;
                    break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }
        }
    }
}
        

