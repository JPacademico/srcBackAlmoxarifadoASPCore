using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNota
    {
        private readonly ContextSQL _context;

        public ItensNotaRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<ITENS_NOTA> ObterTodosItensNota()
        {
            return _context.ITENS_NOTA
                .Select(g => new ITENS_NOTA
                {
                    ITEM_NUM = g.ITEM_NUM,
                    ID_PRO = g.ID_PRO,
                    ID_NOTA = g.ID_NOTA,
                    ID_SEC = g.ID_SEC,
                    QTD_PRO = g.QTD_PRO,
                    PRE_UNIT = g.PRE_UNIT,
                    TOTAL_ITEM = g.TOTAL_ITEM,
                    EST_LIN = g.EST_LIN
                })
                .ToList();
        }

        public ITENS_NOTA ObterItensNotaPorId(int id)
        {
            return _context.ITENS_NOTA
                   .Select(g => new ITENS_NOTA
                   {
                       ITEM_NUM = g.ITEM_NUM,
                       ID_PRO = g.ID_PRO,
                       ID_NOTA = g.ID_NOTA,
                       ID_SEC = g.ID_SEC,
                       QTD_PRO = g.QTD_PRO,
                       PRE_UNIT = g.PRE_UNIT,
                       TOTAL_ITEM = g.TOTAL_ITEM,
                       EST_LIN = g.EST_LIN
                   })
                   .ToList().First(x => x?.ITEM_NUM == id);
        }

        public ITENS_NOTA CriarItenNota(ITENS_NOTA itenNota)
        {
            _context.ITENS_NOTA.Add(itenNota);
            _context.SaveChanges();

            return itenNota;
        }
    }
}
