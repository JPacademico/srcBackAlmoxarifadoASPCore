using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface INotaFiscal
    {
        List<NOTA_FISCAL> ObterTodasNotas();
        NOTA_FISCAL ObterNotaFiscalId(int id);
        NOTA_FISCAL CriarNotaFiscal(NOTA_FISCAL notaFiscal);
        NOTA_FISCAL AtualizarNota(NOTA_FISCAL notaFical, int idNota);
        void DeletarNota(int idNota);
    }
}
