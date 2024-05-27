using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRequisicao
    {
        List<REQUISICAO> ObterTodasRequisicao();
        REQUISICAO ObterRequisicaoPorId(int id);

        REQUISICAO CriarRequisicao(REQUISICAO requisicao);
        REQUISICAO AtualizarRequisicao(REQUISICAO requisicao, int idRequisicao);
        void DeletarRequisicao(int idRequisicao);
    }
}
