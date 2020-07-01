using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_de_biblioteca
{
    interface IEmprestavel
    {
        Operacao emprestar(Usuario usuario, DateTime data);
    }
}
