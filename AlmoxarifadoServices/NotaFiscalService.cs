using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class NotaFiscalService
    {
        private readonly INotaFiscal _notaFiscalRepository;
        private readonly MapperConfiguration configurationMapper;
        private readonly IMapper mapper;

        public NotaFiscalService(INotaFiscal notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NOTA_FISCAL, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalGetDTO, NOTA_FISCAL>();
            });
             
            mapper = configurationMapper.CreateMapper();

        }

        public List<NotaFiscalGetDTO> ObterTodasNotas()
        {
            var list = _notaFiscalRepository.ObterTodasNotas();
            return mapper.Map<List<NotaFiscalGetDTO>>(list);
        }

        public NOTA_FISCAL ObterNotaFiscalId(int id)
        {
            return _notaFiscalRepository.ObterNotaFiscalId(id);
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal(
                new NOTA_FISCAL
                {
                    ID_FOR = notaFiscal.ID_FOR,
                    ID_SEC = notaFiscal.ID_SEC,
                    NUM_NOTA = notaFiscal.NUM_NOTA,
                    VALOR_NOTA = notaFiscal.VALOR_NOTA,
                    QTD_ITEM = notaFiscal.QTD_ITEM,
                    ICMS = notaFiscal.ICMS,
                    ISS = notaFiscal.ISS,
                    ANO = notaFiscal.ANO,
                    MES = notaFiscal.MES,
                    DATA_NOTA = notaFiscal.DATA_NOTA,
                    ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA,
                    OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA,
                    EMPENHO_NUM = notaFiscal.EMPENHO_NUM
                }
            );

            return mapper.Map<NotaFiscalGetDTO>(notaFiscalSalva);
        }


    //    new NotaFiscalGetDTO
    //        {
    //            ID_NOTA = notaFiscalSalva.ID_NOTA,
    //            ID_FOR = notaFiscalSalva.ID_FOR ?? null,
    //            ID_SEC = notaFiscalSalva.ID_SEC,
    //            NUM_NOTA = notaFiscalSalva.NUM_NOTA,
    //            VALOR_NOTA = notaFiscalSalva.VALOR_NOTA,
    //            QTD_ITEM = notaFiscalSalva.QTD_ITEM,
    //            ICMS = notaFiscalSalva.ICMS,
    //            ISS = notaFiscalSalva.ISS,
    //            ANO = notaFiscalSalva.ANO,
    //            MES = notaFiscalSalva.MES,
    //            DATA_NOTA = notaFiscalSalva.DATA_NOTA,
    //            ID_TIPO_NOTA = notaFiscalSalva.ID_TIPO_NOTA,
    //            OBSERVACAO_NOTA = notaFiscalSalva.OBSERVACAO_NOTA,
    //            EMPENHO_NUM = notaFiscalSalva.EMPENHO_NUM
    //}

        public NotaFiscalGetDTO AtualizarNota(NotaFiscalPostDTO notaFiscalDTO, int idNota)
        {
            var notaNova = _notaFiscalRepository.AtualizarNota(new NOTA_FISCAL
            {
                ID_FOR = notaFiscalDTO.ID_FOR,
                ID_SEC = notaFiscalDTO.ID_SEC,
                NUM_NOTA = notaFiscalDTO.NUM_NOTA,
                VALOR_NOTA = notaFiscalDTO.VALOR_NOTA,
                QTD_ITEM = notaFiscalDTO.QTD_ITEM,
                ICMS = notaFiscalDTO.ICMS,
                ISS = notaFiscalDTO.ISS,
                ANO = notaFiscalDTO.ANO,
                MES = notaFiscalDTO.MES,
                DATA_NOTA = notaFiscalDTO.DATA_NOTA,
                ID_TIPO_NOTA = notaFiscalDTO.ID_TIPO_NOTA,
                OBSERVACAO_NOTA = notaFiscalDTO.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscalDTO.EMPENHO_NUM
            }, idNota);

            return mapper.Map<NotaFiscalGetDTO>(notaNova);
        }


    //    new NotaFiscalGetDTO
    //        {
    //            ID_NOTA = notaNova.ID_NOTA,
    //            ID_FOR = notaNova.ID_FOR ?? null,
    //            ID_SEC = notaNova.ID_SEC,
    //            NUM_NOTA = notaNova.NUM_NOTA,
    //            VALOR_NOTA = notaNova.VALOR_NOTA,
    //            QTD_ITEM = notaNova.QTD_ITEM,
    //            ICMS = notaNova.ICMS,
    //            ISS = notaNova.ISS,
    //            ANO = notaNova.ANO,
    //            MES = notaNova.MES,
    //            DATA_NOTA = notaNova.DATA_NOTA,
    //            ID_TIPO_NOTA = notaNova.ID_TIPO_NOTA,
    //            OBSERVACAO_NOTA = notaNova.OBSERVACAO_NOTA,
    //            EMPENHO_NUM = notaNova.EMPENHO_NUM
    //};
        public void DeletarNota(int idNota)
        {
            _notaFiscalRepository.DeletarNota(idNota);
        }
    }

}
