using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensReqRepository : IItensReq
    {
        private readonly ContextSQL _context;

        public ItensReqRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<ITENS_REQ> ObterTodosItensReq()
        {
            return _context.ITENS_REQ
                    .Select(g => new ITENS_REQ
                    {
                        NUM_ITEM = g.NUM_ITEM,
                        ID_PRO = g.ID_PRO,
                        ID_REQ = g.ID_REQ,
                        ID_SEC = g.ID_SEC,
                        QTD_PRO = g.QTD_PRO,
                        PRE_UNIT = g.PRE_UNIT,
                        TOTAL_ITEM = g.TOTAL_ITEM,
                        TOTAL_REAL = g.TOTAL_REAL
                    })
                    .ToList();
        }

        public ITENS_REQ ObterItenReqPorId(int id)
        {
            return _context.ITENS_REQ
                   .Select(g => new ITENS_REQ
                   {
                       NUM_ITEM = g.NUM_ITEM,
                       ID_PRO = g.ID_PRO,
                       ID_REQ = g.ID_REQ,
                       ID_SEC = g.ID_SEC,
                       QTD_PRO = g.QTD_PRO,
                       PRE_UNIT = g.PRE_UNIT,
                       TOTAL_ITEM = g.TOTAL_ITEM,
                       TOTAL_REAL = g.TOTAL_REAL
                   })
                   .ToList().First(x => x?.NUM_ITEM == id);
        }

        public ITENS_REQ CriarItenReq(ITENS_REQ itenReq)
        {
            _context.ITENS_REQ.Add(itenReq);
            _context.SaveChanges();

            return itenReq;
        }
        public void DeletarItenReq(int idItenReq)
        {
            var itemReqParaDeletar = ObterItenReqPorId(idItenReq);
            if (itemReqParaDeletar != null)
            {
                _context.ITENS_REQ.Remove(itemReqParaDeletar);
                _context.SaveChanges();
            }
        }

        public ITENS_REQ AtualizarItenReq(ITENS_REQ itenReq, int idItenReq)
        {
            var itenVelho = _context.ITENS_REQ.Find(idItenReq);
            if (itenVelho == null)
            {
                throw new Exception();
            }

            itenVelho.ID_PRO = itenReq.ID_PRO;
            itenVelho.ID_SEC = itenReq.ID_SEC;
            itenVelho.QTD_PRO = itenReq.QTD_PRO;
            itenVelho.PRE_UNIT = itenReq.PRE_UNIT;
            itenVelho.TOTAL_ITEM = itenReq.TOTAL_ITEM;
            itenVelho.TOTAL_REAL = itenReq.TOTAL_REAL;

            _context.SaveChanges();
            return itenReq;
        }
    }
}
