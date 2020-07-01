using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_de_biblioteca
{
    class Graduacao : Usuario
    {
        public Graduacao(int mat, string nm, int tp) : base(mat, nm, tp)
        {

        }

        public override Operacao emprestar(Livro livro, DateTime data)
        {

        }

        public override int devolver(Livro livro, DateTime data)
        {

        }

        public override bool situacao()
        {

        }
    }
}
