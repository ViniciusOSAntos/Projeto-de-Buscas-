using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//representa um nodo da árvore
namespace TrabICBuscaCSharp
{
	public class Nodo
	{
		private Nodo no_pai = null;
		private Nodo no_direita = null;
		private Nodo no_esquerda = null;
		private char valor = '0';

		public int get_valor() { return (char)valor; }
		public void set_valor(char v) { valor = v; }
		public void set_no_pai(Nodo no) { no_pai = no; }
		public void set_no_pai(char valor) { no_pai.valor = valor; }
		public void set_no_direita(Nodo no) { no_direita = no; }
		public void set_no_direita(char valor) { no_direita.valor = valor; }
		public void set_no_esquerda(Nodo no) { no_esquerda = no; }
		public void set_no_esquerda(char valor) { no_esquerda.valor = valor; }
		public Nodo get_no_pai() { return no_pai; }
		public Nodo get_no_direita() { return no_direita; }
		public Nodo get_no_esquerda() { return no_esquerda; }

	}
}
