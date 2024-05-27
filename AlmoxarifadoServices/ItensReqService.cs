using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class ItensReqService
    {
        private readonly IItensReq _itensReqRepository;
        private readonly MapperConfiguration configurationMapper;
        private readonly IMapper mapper;

        public ItensReqService(IItensReq itensReqRepository)
        {
            _itensReqRepository = itensReqRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ITENS_REQ, ItensReqGetDTO>();
                cfg.CreateMap<ItensReqGetDTO, ITENS_REQ>();
            });

            mapper = configurationMapper.CreateMapper();
        }

        public List<ItensReqGetDTO> ObterTodosItensReq()
        {
            var itensReq = _itensReqRepository.ObterTodosItensReq();
            return mapper.Map<List<ItensReqGetDTO>>(itensReq);
        }

        public ITENS_REQ ObterItenReqPorId(int id)
        {
            return _itensReqRepository.ObterItenReqPorId(id);
        }

        public ItensReqGetDTO CriarItenReq(ItensReqPostDTO itensReq)
        {
            var itenReqSalvo = _itensReqRepository.CriarItenReq(
               new ITENS_REQ
               {
                   ID_PRO = itensReq.ID_PRO,
                   ID_REQ = itensReq.ID_REQ,
                   ID_SEC = itensReq.ID_SEC,
                   QTD_PRO = itensReq.QTD_PRO,
                   PRE_UNIT = itensReq.PRE_UNIT,
                   TOTAL_ITEM = itensReq.TOTAL_ITEM,
                   TOTAL_REAL = itensReq.TOTAL_REAL
               }
            );
            return mapper.Map<ItensReqGetDTO>(itenReqSalvo);
        }

        public ItensReqGetDTO AtualizarItenReq(ItensReqPostDTO itemReqDTO, int idItenReq)
        {
            var itemNovo = _itensReqRepository.AtualizarItenReq(new ITENS_REQ
            {
                ID_PRO = itemReqDTO.ID_PRO,
                ID_REQ = itemReqDTO.ID_REQ,
                ID_SEC = itemReqDTO.ID_SEC,
                QTD_PRO = itemReqDTO.QTD_PRO,
                PRE_UNIT = itemReqDTO.PRE_UNIT,
                TOTAL_ITEM = itemReqDTO.TOTAL_ITEM,
                TOTAL_REAL = itemReqDTO.TOTAL_REAL
            }, idItenReq);
            return mapper.Map<ItensReqGetDTO>(itemNovo);
        }

        public void DeletarItenReq(int idItenReq)
        {
            _itensReqRepository.DeletarItenReq(idItenReq);
        }
    }
}
