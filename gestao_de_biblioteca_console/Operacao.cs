using System;
using System.Reflection;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace gestao_de_biblioteca
{
    class Operacao<L>where L : IComparable
    {
        protected L[] livros;
        protected DateTime data;
        protected DateTime devalocao;
        protected DateTime proxRetirada;

        protected int totalLivros;
        protected int livroAtual;

        public Operacao(int quantos)
        {
            this.livros = new L[quantos];
        }

        public Operacao(string livro, DateTime data)
        {
            this.livros = pesquisar(livro);
            this.data = data;
        }

        public int adicionar(L liv)
        {
            if (quantLivros() < livros.Length)
            {
                totalLivros++;
            }
            return totalLivros;
        }

        public bool setPos(int pos)
        {
            if ((pos >= 0) && (pos < quantLivros()))
            {
                this.livroAtual = pos;
                return true;
            }
            else return false;
        }

        public int quantLivros()
        {
            return totalLivros;
        }

        public L[] getLivros()
        {
            if (this.quantLivros() > 0)
            {
                return livros;
            }
            else return null;
        }

        public L maior()
        {
            L mai = livros[0];
            for(int i = 1; i < quantLivros(); i++)
            {
                if (livros[i].CompareTo(mai) > 0)
                {
                    mai = livros[i];
                }
            }
            return mai;
        }

        public L menor()
        {
            L men = livros[0];
            for(int i = 1; i < quantLivros(); i++)
            {
                if(livros[i].CompareTo(men)<0)
                {
                    men = livros[i];
                }
            }
            return men;
        }

        public L atual()
        {
            if (livroAtual > -1)
            {
                return livros[livroAtual];
            }
            else
            {
                return default(L);
            }
        }

        public L proximo()
        {
            if (livroAtual < (quantLivros() - 1))
            {
                livroAtual++;
                return livros[livroAtual];
            }
            else
            {
                return default(L);
            }
        }

        public L anterior()
        {
            if (livroAtual > 0)
            {
                livroAtual--;
                return livros[livroAtual];
            }
            else
            {
                return default(L);
            }
        }

        /// <summary>
        /// pesquisa o primeiro atraves de objetos
        /// </summary>
        /// <param name="quem"></param>
        /// <returns></returns>
        public L pesquisar(L quem)
        {
            for (int i = 0; i < quantLivros(); i++)
            {
                if (livros[i].Equals(quem))
                {
                    return livros[i];
                }
            }
            return default(L);
        }

        /// <summary>
        /// pesquisa o primeiro atraves da string
        /// </summary>
        /// <param name="pesq"></param>
        /// <returns></returns>
        public L pesquisar(string pesq)
        {
            for(int i = 0; i < quantLivros(); i++)
            {
                if (livros[i].CompareTo(pesq) == 0)
                {
                    return livros[i];
                }
            }
            return default(L);
        }

        /// <summary>
        /// pesquisa o primeiro onde contenha a string
        /// </summary>
        /// <param name="pesq"></param>
        /// <returns></returns>
        public L pesquisarParte(string pesq)
        {
            for(int i = 0; i < quantLivros(); i++)
            {
                if (livros[i].ToString().Contains(pesq))
                {
                    return livros[i];
                }
            }
            return default(L);
        }

        /// <summary>
        /// pesquisa todos os livros que contenha a string
        /// </summary>
        /// <param name="pesq"></param>
        /// <returns></returns>
        public int []pesquisaN(string pesq)
        {
            int[] aux = new int[quantLivros()];
            int cont = 0;

            for(int i = 0; i < quantLivros(); i++)
            {
                if (livros[i].ToString().Contains(pesq))
                {
                    aux[cont++] = i;
                }
            }
            if (cont > 0)
            {
                return aux;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Percorre toda a coleção e salva os dados em um arquivo texto pré-formatado. (serialização)
        /// Um objeto por linha, dados separados por ;
        /// </summary>
        /// <param name="nomeArq">Nome do Arquivo a ser gravado</param>
        public void salvarEmTXT(string nomeArq)
        {
            StreamWriter arq = new StreamWriter(@nomeArq);
            for (int i = 0; i < quantLivros(); i++)
            {
                StringBuilder b = new StringBuilder();
                foreach (PropertyInfo p in livros[i].GetType().GetProperties())  //seleciona cada uma das propriedades existentes do tipo L do dado
                {
                    b.Append(p.GetValue(livros[i], null).ToString());    //usamos o polimorfismo de ToString() para imprimir os dados de um objeto
                    b.AppendLine(";");
                }
                arq.WriteLine(b.ToString());
            }
            arq.Close();
        }

        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();
            for (int i = 0; i < quantLivros(); i++)
            {
                aux.AppendLine(livros[i].ToString());
            }
            return aux.ToString();
        }


    }
}
