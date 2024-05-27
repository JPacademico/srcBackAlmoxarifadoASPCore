using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNota
    {
        List<ITENS_NOTA> ObterTodosItensNota();
        ITENS_NOTA ObterItensNotaPorId(int id);

        ITENS_NOTA CriarItenNota(ITENS_NOTA itenNota);
        ITENS_NOTA AtualizarItenNota(ITENS_NOTA itenNota, int idItenNota);
        void DeletarItenNota(int idItenNota);
    }
}
