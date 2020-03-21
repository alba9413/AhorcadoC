using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhorcadoC
{
    public partial class Form1 : Form
    {
        //almacena la palabra que hay que adivinar
        String palabraOculta = palabraElegida();
        //variable que almacena el numero de fallos
        int numeroFallos = 0;
        Boolean final = false;

        //constructor
        public Form1()
        {
            InitializeComponent();
            String guiones = "";
            for (int i = 0; i< palabraOculta.Length; i++)
            {
                guiones = guiones + "_ ";
            }
            label1.Text = guiones;
        }

        public static String palabraElegida()
        {
            String[] listaPalabras = {"CETYS","FURBY", "COSA","VIRUS"};
            Random aleatorio = new Random();
            int posicion = aleatorio.Next(listaPalabras.Length);
            return listaPalabras[posicion].ToUpper();
        }

        //Todos los botones al hacer click vienen a este método
        private void clickLetra(object sender, EventArgs e)
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
                label1.Text = label1.Text.Remove( 2*posicion, 1).Insert( 2*posicion, letra);

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
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                case -100: pictureBox1.Image = Properties.Resources.acertasteTodo; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }


        }
    }
}
