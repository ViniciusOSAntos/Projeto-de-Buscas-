using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabICBuscaCSharp
{
    public partial class Form1 : Form
    {
        private Arvore minhaArvore = new Arvore();
        private Buscas busca = new Buscas();
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                minhaArvore.insere(Convert.ToChar(textBox1.Text));
            }
            catch
            {
                MessageBox.Show("Valor inválido! Digite apenas uma letra!");
            }
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add(minhaArvore.listagem());
            }
            catch
            {
                MessageBox.Show("Árvore vazia!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Quantidade: " + minhaArvore.qtde_nos_internos());
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("\nBusca em Profundidade: ");
                busca.printDFS(minhaArvore.raiz);
                char resp;
                resp = busca.printDFS(minhaArvore.raiz, Convert.ToChar(textBox2.Text));
                if(resp == ' ')
                {
                    listBox1.Items.Add("Valor NÃO encontrado! " + Convert.ToChar(textBox2.Text));
                }
                else
                    listBox1.Items.Add("Valor encontrado: " + resp);
                Console.WriteLine(resp);
             
            }
            catch
            {
                MessageBox.Show("Valor inválido ou árvore vazia!");
            }
            textBox2.Focus();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("\nBusca em Largura ");
                char resp;
                busca.printBFS(minhaArvore.raiz);
                resp = busca.printBFS(minhaArvore.raiz, Convert.ToChar(textBox2.Text));
                if (resp == ' ')
                {
                    listBox1.Items.Add("Valor NÃO encontrado! " + Convert.ToChar(textBox2.Text));
                }
                else
                    listBox1.Items.Add("Valor encontrado: " + resp);
                Console.WriteLine(resp);

            }
            catch
            {
                MessageBox.Show("Valor inválido ou árvore vazia!");
            }
            textBox2.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            busca.inOrder(minhaArvore.raiz);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("\nBusca em Backtracking:");
                char resp;
                resp = busca.PrintBacktracking(minhaArvore.raiz, Convert.ToChar(textBox2.Text));
                if (resp == ' ')
                {
                    listBox1.Items.Add("Valor NÃO encontrado! " + Convert.ToChar(textBox2.Text));
                }
                else
                    listBox1.Items.Add("Valor encontrado: " + resp);
                Console.WriteLine(resp);

           }
            catch
            {
                MessageBox.Show("Valor inválido ou árvore vazia!");
            }
            textBox2.Focus();
        }
    }
}
