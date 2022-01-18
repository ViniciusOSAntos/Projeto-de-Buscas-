using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// clase da arvore
namespace TrabICBuscaCSharp
{
    class Arvore
    {
        public Nodo raiz = null;
        public bool b = false;
        private int qtde = 0; //qtde de nós
        private string resultado = "";
        //List<char> listaVisitados = new List<char>();

        public int qtde_nos_internos()// retorna a quantidade de nós
        {
            return qtde;
        }
        public bool no_eh_externo(Nodo no)//verifica se é folha
        {
            //Console.WriteLine("\nÉ externo");
            return (no.get_no_direita() == null) && (no.get_no_esquerda() == null);
           
        }
      

        public Nodo cria_No_externo(Nodo Nopai)//cria folha
        {
            Nodo no = new Nodo();
            no.set_no_pai(Nopai);
            return no;
        }
        public void insere(char valor)
        {
            Nodo no_aux;
            if (qtde == 0)
            {
                //arvore vazia, criar nó raiz
                no_aux = new Nodo();
                raiz = no_aux;
            }
            else
            {
                //localiza aonde inserir novo nó
                no_aux = raiz;
                while (no_eh_externo(no_aux) == false)
                {

                    if ((int)valor > ((int)no_aux.get_valor()))
                    {
                        no_aux = no_aux.get_no_direita();
                    }

                    else
                    {
                        no_aux = no_aux.get_no_esquerda();
                    }


                }
            }
            // criar filhos para o nodo externo
            no_aux.set_valor(valor);
            no_aux.set_no_direita(cria_No_externo(no_aux));
            no_aux.set_no_esquerda(cria_No_externo(no_aux));
            qtde++;
        }

        private void Le_Nodo(Nodo no)
        {
            if (no_eh_externo(no))
                return;

            Le_Nodo(no.get_no_esquerda());
            resultado = resultado + " - " + Convert.ToChar(no.get_valor());
            Le_Nodo(no.get_no_direita());
        }
        //devolve um string com os elementos da árvore
        public string listagem()
        {
            resultado = "";
            Le_Nodo(raiz);
            return resultado;
        }
        
    }
}
