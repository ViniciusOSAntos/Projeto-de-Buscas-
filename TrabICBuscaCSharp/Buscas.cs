using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabICBuscaCSharp
{
    class Buscas : Arvore
    {
        public Arvore Arvore = new Arvore();
        public void printDFS()
        {
            printDFS(this.raiz);
        }
        public void printDFS(Nodo no) //  busca em profundidade
        {
            if (no != null)
            {
                Console.WriteLine((char)no.get_valor());
                printDFS(no.get_no_esquerda());
                printDFS(no.get_no_direita());
            }
        }
        public char printDFS(Nodo raiz, char valor) // DFS baseado no pseudocódigo
        {
            char resposta = ' ';
            Stack<Nodo> pilhaAbertos = new Stack<Nodo>();
            List<Nodo> listaFechados = new List<Nodo>();
            bool sucesso = false;

            Nodo atual = raiz;
            
            if (raiz.get_valor() == valor)//exceção pra quando  raiz ==  resp
            {
                return (char)raiz.get_valor();
            }
            if(raiz == null)
            {
                return ' ';
            }

            pilhaAbertos.Push(raiz);
            while(sucesso == false && pilhaAbertos.Count != 0)
            {
                Nodo auxE = new Nodo();
                Nodo auxD = new Nodo();
                atual = pilhaAbertos.Pop();
                listaFechados.Add(atual);
                
                if (atual.get_no_esquerda() != null)
                {
                    auxE = atual.get_no_esquerda();
                    //Console.WriteLine("TOAQESQUERDA");
                    if (auxE.get_valor() == valor)
                    {
                        sucesso = true;
                        resposta = (char)auxE.get_valor();
                        return resposta;
                    }
                }
                if (atual.get_no_direita() != null)
                {
                    auxD = atual.get_no_direita();
                    //Console.WriteLine("TOAQDIREITA");
                    if (auxD.get_valor() == valor)
                    {
                        sucesso = true;
                        resposta = (char)auxD.get_valor();
                        return resposta;
                    }
                    
                }
                if(atual.get_no_direita() != null && atual.get_no_esquerda() != null)
                {
                    pilhaAbertos.Push(auxE);
                    pilhaAbertos.Push(auxD);
                }
                    
            }
            return resposta;
        }
        public void printBFS(Nodo raiz) // busca em largura opção 1
        {
            Console.WriteLine("\nBusca em Largura: ");
            Queue<Nodo> queue = new Queue<Nodo>();

            queue.Enqueue(raiz);
            while (queue.Count != 0) //enquanto a fila não é vazia
            {
                Nodo atual = queue.Dequeue();

                Console.WriteLine((char)atual.get_valor());

                if (atual.get_no_esquerda() != null)
                {
                    queue.Enqueue(atual.get_no_esquerda());
                }
                if (atual.get_no_direita() != null)
                {
                    queue.Enqueue(atual.get_no_direita());
                }
            }

        }
        public char printBFS(Nodo raiz, char valor) // busca em largura opção 2
        {
            Console.WriteLine("\nBusca em Largura: ");
            Queue<Nodo> queueAbertos = new Queue<Nodo>();
            List<Nodo> listaFechados = new List<Nodo>();
            bool sucesso = false;
            char resposta = ' ';

            queueAbertos.Enqueue(raiz);
            if(raiz.get_valor() == valor) //exceção pra quando  raiz ==  resp
            {
                return (char)raiz.get_valor();
            }
            if (raiz == null)
            {
                return ' ';
            }

            while (queueAbertos.Count != 0 && sucesso ==  false) 
            {
                Nodo atual = queueAbertos.Dequeue();
                Nodo auxE = new Nodo();
                Nodo auxD = new Nodo();

                listaFechados.Add(atual);
                if(atual.get_no_esquerda() != null)
                {
                    auxE = atual.get_no_esquerda();
                }
                if (atual.get_no_direita() != null)
                {
                    auxD = atual.get_no_direita();
                }

                if (auxE.get_valor() ==  valor)
                {
                    sucesso = true;
                    resposta = (char)auxE.get_valor();
                    return resposta;
                }
                else if(auxD.get_valor() == valor && auxE != null)
                {
                    sucesso = true;
                    resposta = (char)auxD.get_valor();
                    return resposta;
                }
                else
                {
                    queueAbertos.Enqueue(auxE);
                    queueAbertos.Enqueue(auxD);
                }
            }
            return resposta;

        }
        /*
        public char PrintBacktracking(Nodo raiz, char valor) 
        {
            Console.WriteLine("\nBusca Backtracking: ");
            Stack<Nodo> pilhaAbertos = new Stack<Nodo>();
            List<Nodo> listaFechados = new List<Nodo>();
            bool sucesso = false;
            char resposta = ' ';

            pilhaAbertos.Push(raiz);
            Nodo atual = raiz;

            if (raiz.get_valor() == valor)//exceção pra quando  raiz ==  resp
            {
                return (char)raiz.get_valor();
            }
            if (raiz == null)
            {
                return ' ';
            }

            Console.WriteLine("TOAQ");
            while (sucesso == false && pilhaAbertos.Count != 0)
            {
                atual = pilhaAbertos.Pop();
                pilhaAbertos.Push(atual);
                int cont = 0;
                Console.WriteLine(atual.get_valor());
                Nodo aux = new Nodo();
                Nodo auxE = new Nodo();
                Nodo auxD = new Nodo();


                if (atual.get_no_esquerda() != null)
                {
                    auxE = atual.get_no_esquerda();
                    if (auxE.get_valor() == valor)
                    {
                        sucesso = true;
                        resposta = (char)auxE.get_valor();
                        return resposta;
                    }

                    else //if (atual.get_no_esquerda() != null || atual.get_no_esquerda().get_valor() != valor)
                    {
                        pilhaAbertos.Push(auxE);
                        Console.WriteLine("Empilhei!");
                    }
                }

                else if (atual.get_no_direita() != null)
                {
                    auxD = atual.get_no_direita();
                    if (auxD.get_valor() == valor)
                    {
                        sucesso = true;
                        resposta = (char)auxD.get_valor();
                        return resposta;
                    }

                    else //if(atual.get_no_direita() != null || atual.get_no_direita().get_valor() != valor)
                    {
                        pilhaAbertos.Push(auxD);
                        Console.WriteLine("Empilhei!");
                    }
                }
                else if (auxE.get_valor() != valor && auxD.get_valor() != valor && pilhaAbertos.Count != 0)
                {
                    aux = pilhaAbertos.Pop();
                    listaFechados.Add(aux);
                }

                cont++;
                Console.WriteLine("Count:" + cont + " " + resposta);
            }
            return resposta;
        }*/
        public char PrintBacktracking(Nodo raiz, char valor)
        {
            char resposta = ' ';
            Stack<Nodo> pilhaAbertos = new Stack<Nodo>();
            pilhaAbertos.Push(raiz);
            List<Nodo> listaDeFechados = new List<Nodo>();
            bool sucesso = false;
            int count = 0;

            if (raiz == null)
            {
                return ' ';
            }

            if (raiz.get_valor() == valor)//exceção pra quando  raiz ==  resp
            {
                return (char)raiz.get_valor();
            }
         

            while (sucesso == false &&  pilhaAbertos.Count != 0) // enquanto sucesso == falso  E pilhaAbertos NÃO é vazia
            {
                Nodo no = pilhaAbertos.Pop(); // no canditado recebe topo da pilha
                pilhaAbertos.Push(no); // Faz com que nó receba o topo da pilha e mantem o topo da pilha igual

                if(no.get_no_esquerda() != null) // se for possível gerar um filho
                {
                    Nodo auxE = no.get_no_esquerda(); //gere-o
                    if (auxE.get_valor() == valor) // se é solução
                    {
                        sucesso = true;
                        resposta = (char)auxE.get_valor();
                        return resposta;
                    }
                    else
                    {
                        pilhaAbertos.Push(auxE);
                        Console.WriteLine("Empilhei!Esquerda");
                    }
                }
                if (no.get_no_direita() != null) //se for possível gera um filho
                 {
                    Nodo auxD = no.get_no_direita();
                    if (auxD.get_valor() == valor) // se é solução
                    {
                        sucesso = true;
                        resposta = (char)auxD.get_valor();
                    }
                    else
                    {
                        pilhaAbertos.Push(auxD);
                        Console.WriteLine("Empilhei!Direita");
                    }
                }
                if(no.get_no_esquerda() == null)//equivale ao senão
                {
                    Nodo aux;
                    aux = pilhaAbertos.Pop();
                    listaDeFechados.Add(aux);
                }
                if (no.get_no_direita() == null)
                {
                    Nodo aux;
                    aux = pilhaAbertos.Pop();
                    listaDeFechados.Add(aux);
                }
                count++;
                if (count == 1000)
                {
                    return ' ';
                }
                Console.WriteLine("Count:" + count + " Valor:" + valor + " Nó atual: " + (char)no.get_valor());
            }
            return resposta;


        }
        public void inOrder()
        {
            Console.WriteLine("Em ordem: ");
            inOrder(this.raiz);
        }
      
        public void inOrder(Nodo no)
        {
            
            if(no != null)
            {
                inOrder(no.get_no_esquerda());
                Console.WriteLine((char)no.get_valor());
                inOrder(no.get_no_direita());
            }
            

        }
    }
            
}
