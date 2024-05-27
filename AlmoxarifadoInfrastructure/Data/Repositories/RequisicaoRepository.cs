using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicaoRepository : IRequisicao
    {
        private readonly ContextSQL _context;

        public RequisicaoRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<REQUISICAO> ObterTodasRequisicao()
        {
            return _context.REQUISICAO
                    .Select(g => new REQUISICAO
                    {
                        ID_REQ = g.ID_REQ,
                        ID_CLI = g.ID_CLI,
                        TOTAL_REQ = g.TOTAL_REQ,
                        QTD_ITEN = g.QTD_ITEN,
                        DATA_REQ = g.DATA_REQ,
                        ANO = g.ANO,
                        MES = g.MES,
                        ID_SEC = g.ID_SEC,
                        ID_SET = g.ID_SET,
                        OBSERVACAO = g.OBSERVACAO
                    })
                    .ToList();
        }

        public REQUISICAO ObterRequisicaoPorId(int id)
        {
            return _context.REQUISICAO
                   .Select(g => new REQUISICAO
                   {
                       ID_REQ = g.ID_REQ,
                       ID_CLI = g.ID_CLI,
                       TOTAL_REQ = g.TOTAL_REQ,
                       QTD_ITEN = g.QTD_ITEN,
                       DATA_REQ = g.DATA_REQ,
                       ANO = g.ANO,
                       MES = g.MES,
                       ID_SEC = g.ID_SEC,
                       ID_SET = g.ID_SET,
                       OBSERVACAO = g.OBSERVACAO
                   })
                   .ToList().First(x => x?.ID_REQ == id);
        }

        public REQUISICAO CriarRequisicao(REQUISICAO requisicao)
        {
            _context.REQUISICAO.Add(requisicao);
            _context.SaveChanges();

            return requisicao;
        }
        public REQUISICAO AtualizarRequisicao(REQUISICAO requisicao, int idRequisicao)
        {
            var requisicaoVelha = _context.REQUISICAO.Find(idRequisicao);
            if (requisicaoVelha == null)
            {
                throw new Exception();
            }

            requisicaoVelha.ID_CLI = requisicao.ID_CLI;
            requisicaoVelha.TOTAL_REQ = requisicao.TOTAL_REQ;
            requisicaoVelha.QTD_ITEN = requisicao.QTD_ITEN;
            requisicaoVelha.DATA_REQ = requisicao.DATA_REQ;
            requisicaoVelha.ANO = requisicao.ANO;
            requisicaoVelha.MES = requisicao.MES;
            requisicaoVelha.ID_SEC = requisicao.ID_SEC;
            requisicaoVelha.ID_SET = requisicao.ID_SET;
            requisicaoVelha.OBSERVACAO = requisicao.OBSERVACAO;

            _context.SaveChanges();
            return requisicao;
        }
        public void DeletarRequisicao(int idRequisicao)
        {
            var requisicaoDeletar = ObterRequisicaoPorId(idRequisicao);
            if (requisicaoDeletar != null)
            {
                _context.REQUISICAO.Remove(requisicaoDeletar);
                _context.SaveChanges();
            }
        }
    }
}
