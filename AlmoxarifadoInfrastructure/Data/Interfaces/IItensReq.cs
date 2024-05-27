using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensReq
    {
        List<ITENS_REQ> ObterTodosItensReq();
        ITENS_REQ ObterItenReqPorId(int id);

        ITENS_REQ CriarItenReq(ITENS_REQ itenReq);
        ITENS_REQ AtualizarItenReq(ITENS_REQ itensReq, int idItenReq);
        void DeletarItenReq(int idItenReq);
    }
}
