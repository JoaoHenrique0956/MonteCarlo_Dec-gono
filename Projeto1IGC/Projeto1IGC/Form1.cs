/*******************************************************************
* 
* Colegio Técnico Antônio Teixeira Fernandes (Univap)
* Curso Técnico em Informática - Data de Entrega: 06 / 04 / 2026
* Autores do Projeto: Luigi Nucci Plata Amaral
*                     João Henrique Mendes de Oliveira
* Turma: 3J
* Atividade Proposta em aula
* 
* 
* 
* ******************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoICG1

{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        bool gerar = false;
        Color cor = new Color();

        public float Modulo(float a, float b)
        {
            return (a % b + b) % b;
        }

        public Color criaCor(int R, int G, int B)
        {
            Color cor = new Color();
            cor = Color.FromArgb(R, G, B);
            return cor;
        }

        public void pintaP(Color cor, int x, int y, PaintEventArgs e)
        {
            Pen caneta = new Pen(cor);
            e.Graphics.DrawLine(caneta, x, y, x + 1, y);
        }
        
        

        public void decagono(PaintEventArgs e, Color cor)
        {
            int n = 10; 
            int R = 150; 
            int tentativas = 80000;
            int largura = 800;
            int altura = 800;
            int centroX = largura / 2;
            int centroY = altura / 2;
            Random rnd = new Random();

            for (int i = 0; i < tentativas; i++)
            {
                
                int px = rnd.Next(centroX - R, centroX + R);
                int py = rnd.Next(centroY - R, centroY + R);

                int deltaX = px - centroX;
                int deltaY = py - centroY;

                float d = (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                float angulo = (float)Math.Atan2(deltaY, deltaX);

                float seccao = (float)(2.0 * Math.PI) / n;
                float alpha = (float)(Modulo(angulo, seccao) - (seccao / 2.0));

                float d_max = (float)((R * Math.Cos(Math.PI / n)) / Math.Cos(alpha));
                if (d < d_max)
                {
                    pintaP(cor, px, py, e);
                }
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] cores = {"Azul", "Vermelho", "Verde", "Amarelo", "Ciano", "Magenta", "Preto", "Branco" };
            comboBox1.Items.AddRange(cores);
            
        }

        
        

        private void button1_Click(object sender, EventArgs e)
        {
            string cortxt = comboBox1.Text;
            switch (cortxt)
            {
                case "Azul":
                    cor = criaCor(0,0,255);
                    break;
                case "Vermelho":
					cor = criaCor(255, 0, 0);
                    break;
                case "Verde":
					cor = criaCor(0, 255, 0);
                    break;
                case "Amarelo":
					cor = criaCor(255, 255, 0);
                    break;
                case "Ciano":
					cor = criaCor(255, 255, 0);
					break;
                case "Magenta":
					cor = criaCor(255, 0, 255);
					break;
                case "Preto":
                    cor = criaCor(0 ,0 , 0);
                    break;
                case "Branco":
					cor = criaCor(255, 255, 255);
					break;
                default:
					cor = criaCor(0 ,0 , 0);
					break;
            }
            gerar = true;
            Invalidate();

        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gerar)
            {
                decagono(e, cor);
            }
        }
    }

}
