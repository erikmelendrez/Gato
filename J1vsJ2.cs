using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TicTacToe_2._0
{
    public partial class J1vsJ2 : Form
    {
        Puntos punto = new Puntos();
        int[,] Gato;
        bool YaHayGanador;

        public J1vsJ2()
        {
            InitializeComponent();
            IniciarJuego();
        }
        public void IniciarJuego()
        {
            // Iniciar Valores en Juego
            punto.Turno = 1;
            Gato = new int[3, 3];
            YaHayGanador = false;
            label3.Hide();

            picGanador.Image = Properties.Resources.f_0;
            FichasGato.Controls.Clear();

            // Arreglos para mostrar Fichas y meter valores en una matriz
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var FichaJuego = new PictureBox();
                    FichaJuego.Image = Properties.Resources.f_0;
                    FichaJuego.Name = string.Format("{0}", i + "_" + j);
                    FichaJuego.Dock = DockStyle.Fill;
                    FichaJuego.Cursor = Cursors.Hand;
                    FichaJuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    FichaJuego.Click += Jugar;
                    FichasGato.Controls.Add(FichaJuego, j, i);
                    Gato[i, j] = 0;


                }
            }

        }

        private void Jugar(object sender, EventArgs e)
        {

            var FichaSeleccionadaUsuario = (PictureBox)sender;
            FichaSeleccionadaUsuario.Enabled = false;
            FichaSeleccionadaUsuario.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("f_" + punto.Turno);
            string[] Posicion = FichaSeleccionadaUsuario.Name.Split("_".ToCharArray());
            int Fila = Convert.ToInt32(Posicion[0]);
            int Columna = Convert.ToInt32(Posicion[1]);
            Gato[Fila, Columna] = punto.Turno;
            VerificarJuego(Fila, Columna);
            punto.Turno = (punto.Turno == 1) ? 2 : 1;

        }
        public void VerificarJuego(int Fila, int Columna)
        {
            // Contador de fichas en filas y columnas del gato
            int GanoFilas = 0;
            int GanoColumnas = 0;
            int DiagonalPrincipal = 0;
            int DiagonalInversa = 0;
            int TamanioGato = 3;

            for (var i = 0; i < TamanioGato; i++)
            {
                for (var j = 0; j < TamanioGato; j++)
                {

                    if (i == Fila)
                    {
                        if (Gato[i, j] == punto.Turno)
                        {
                            GanoFilas++;
                        }
                    }
                    if (j == Columna)
                    {
                        if (Gato[i, j] == punto.Turno)
                        {
                            GanoColumnas++;
                        }
                    }
                    if (i == j) // Diagonal principal
                    {
                        if (Gato[i, j] == punto.Turno)
                        {
                            DiagonalPrincipal++;
                        }
                    }

                    if ((i + j) == (TamanioGato - 1)) // Diagonal Inversa
                    {
                        if (Gato[i, j] == punto.Turno)
                        {
                            DiagonalInversa++;

                        }
                    }



                }
            }

            if ((GanoFilas == TamanioGato) || (GanoColumnas == TamanioGato) || (DiagonalInversa == TamanioGato) || (DiagonalPrincipal == TamanioGato))
            {
                YaHayGanador = true;
            }
            else
            {
                bool Empate = true;
                for (var i = 0; i < TamanioGato; i++)
                {
                    for (var j = 0; j < TamanioGato; j++)
                    {
                        if (Gato[i, j] == 0)
                        {
                            Empate = false;
                        }

                    }
                }
                if (Empate)
                {
                    MessageBox.Show("Esto es un empate ¡Reinicia el juego!");
                    IniciarJuego();
                }

            }
            if (YaHayGanador)
            {
                SoundPlayer sonido = new SoundPlayer();

                MessageBox.Show("Ya hay ganador");
                picGanador.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("f_" + punto.Turno);
                if (punto.Turno == 1)
                {
                    punto.PuntosPlayer1++;
                    lblPlayer1.Text = punto.PuntosPlayer1.ToString();
                    IniciarJuego();
                    label3.Show();

                }
                else
                {
                    punto.PuntosPlayer2++;
                    lblPlayer2.Text = punto.PuntosPlayer2.ToString();
                    IniciarJuego();
                    label3.Show();
                }
                sonido.SoundLocation = (@"C:/Users/Rick Cassi/Desktop/Programas/TicTacToe 2.0/TicTacToe 2.0/bin/Debug/son/Ganar.wav");
                sonido.Play();
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void J1vsJ2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
