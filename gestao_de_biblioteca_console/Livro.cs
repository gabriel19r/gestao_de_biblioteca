using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_de_biblioteca
{
    class Livro : IEmprestavel
    {
        protected int id;
        protected string titulo;


        public Livro(int id, string tit)
        {
            this.id = id;
            this.titulo = tit;
        }

        public int getId()
        {
            return id;
        }

        public string getTitulo()
        {
            return titulo;
        }

        public Operacao emprestar(Usuario usuario, DateTime data)
        {

        }
    }
}
