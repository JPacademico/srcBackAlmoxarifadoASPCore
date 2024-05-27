using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscal
    {
        private readonly ContextSQL _context;

        public NotaFiscalRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<NOTA_FISCAL> ObterTodasNotas()
        {
            return _context.NOTA_FISCAL
                    .Select(g => new NOTA_FISCAL
                    {
                        ID_NOTA = g.ID_NOTA,
                        ID_FOR = g.ID_FOR,
                        ID_SEC = g.ID_SEC,
                        NUM_NOTA = g.NUM_NOTA,
                        VALOR_NOTA = g.VALOR_NOTA,
                        QTD_ITEM = g.QTD_ITEM,
                        ICMS = g.ICMS,
                        ISS = g.ISS,
                        ANO = g.ANO,
                        MES = g.MES,
                        DATA_NOTA = g.DATA_NOTA,
                        ID_TIPO_NOTA = g.ID_TIPO_NOTA,
                        OBSERVACAO_NOTA = g.OBSERVACAO_NOTA,
                        EMPENHO_NUM = g.EMPENHO_NUM
                    })
                    .ToList();
        }

        public NOTA_FISCAL ObterNotaFiscalId(int id)
        {
            return _context.NOTA_FISCAL
                   .Select(g => new NOTA_FISCAL
                   {
                       ID_NOTA = g.ID_NOTA,
                       ID_FOR = g.ID_FOR,
                       ID_SEC = g.ID_SEC,
                       NUM_NOTA = g.NUM_NOTA,
                       VALOR_NOTA = g.VALOR_NOTA,
                       QTD_ITEM = g.QTD_ITEM,
                       ICMS = g.ICMS,
                       ISS = g.ISS,
                       ANO = g.ANO,
                       MES = g.MES,
                       DATA_NOTA = g.DATA_NOTA,
                       ID_TIPO_NOTA = g.ID_TIPO_NOTA,
                       OBSERVACAO_NOTA = g.OBSERVACAO_NOTA,
                       EMPENHO_NUM = g.EMPENHO_NUM
                   })
                   .ToList().First(x => x?.ID_NOTA == id);
        }

        public NOTA_FISCAL CriarNotaFiscal(NOTA_FISCAL notaFiscal)
        {
            _context.NOTA_FISCAL.Add(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }

        public NOTA_FISCAL AtualizarNota(NOTA_FISCAL notaFiscal, int idNota)
        {
            var notaVelha = _context.NOTA_FISCAL.Find(idNota);
            if (notaVelha == null)
            {
                throw new Exception();
            }
           
            notaVelha.ID_FOR = notaFiscal.ID_FOR;
            notaVelha.ID_SEC = notaFiscal.ID_SEC;
            notaVelha.NUM_NOTA = notaFiscal.NUM_NOTA;
            notaVelha.VALOR_NOTA = notaFiscal.VALOR_NOTA;
            notaVelha.QTD_ITEM = notaFiscal.QTD_ITEM;
            notaVelha.ICMS = notaFiscal.ICMS;
            notaVelha.ISS = notaFiscal.ISS;
            notaVelha.ANO = notaFiscal.ANO;
            notaVelha.MES = notaFiscal.MES;
            notaVelha.DATA_NOTA = notaFiscal.DATA_NOTA;
            notaVelha.ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA;
            notaVelha.OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA;
            notaVelha.EMPENHO_NUM = notaFiscal.EMPENHO_NUM;

            _context.SaveChanges();
            return notaFiscal;
        }

        public void DeletarNota(int idNota)
        {
            var notaParaDeletar = ObterNotaFiscalId(idNota);
            if (notaParaDeletar != null)
            {
                _context.NOTA_FISCAL.Remove(notaParaDeletar);
                _context.SaveChanges();
            }
        }
    }
}
