using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_de_biblioteca
{
    abstract class Usuario : IComparable
    {
        protected int matricula;
        protected string nome;
        protected int tipo;

        //------TIPO-------
        // 2- Professor
        // 1 - Pos Graduação
        // 0 - Graduação

        public Usuario(int mat, string nm, int tp)
        {
            this.matricula = mat;
            this.nome = nm;
            if (tp >= 0 && tp <= 2)
            {
                this.tipo = tp;
            }
            else
            {
                this.tipo = tp;
            }
        }

        public int getMatricula()
        {
            return matricula;
        }

        public int CompareTo(object obj)
        {
            Usuario outra = (Usuario)obj;

            int res;
            res = getMatricula().CompareTo(outra.getMatricula());

            return res;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public abstract Operacao emprestar(Livro livro, DateTime data);

        public abstract int devolver(Livro livro, DateTime data);

        public abstract bool situacao();
    }
}
