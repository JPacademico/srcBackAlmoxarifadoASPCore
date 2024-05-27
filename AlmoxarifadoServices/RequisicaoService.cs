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
    public class RequisicaoService
    {
        private readonly IRequisicao _requisicaoRepository;
        private readonly MapperConfiguration _configurationMapper;
        private readonly IMapper mapper;

        public RequisicaoService(IRequisicao requisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<REQUISICAO, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoPostDTO, REQUISICAO>();
            });
            mapper = _configurationMapper.CreateMapper();
        }

        public List<RequisicaoGetDTO> ObterTodasRequisicoes()
        {
            var list = _requisicaoRepository.ObterTodasRequisicao();
            return mapper.Map<List<RequisicaoGetDTO>>(list);
        }

        public REQUISICAO ObterRequisicaoPorId(int id)
        {
            return _requisicaoRepository.ObterRequisicaoPorId(id);
        }

        public RequisicaoGetDTO CriarRequisicao(RequisicaoPostDTO requisicao)
        {
            var requisicaoSalva = _requisicaoRepository.CriarRequisicao(
                new REQUISICAO
                {
                    ID_CLI = requisicao.ID_CLI,
                    TOTAL_REQ = requisicao.TOTAL_REQ,
                    QTD_ITEN = requisicao.QTD_ITEN,
                    DATA_REQ = requisicao.DATA_REQ,
                    ANO = requisicao.ANO,
                    MES = requisicao.MES,
                    ID_SEC = requisicao.ID_SEC,
                    ID_SET = requisicao.ID_SET,
                    OBSERVACAO = requisicao.OBSERVACAO
                }
            );
            return mapper.Map<RequisicaoGetDTO>(requisicaoSalva);
        }
        public RequisicaoGetDTO AtualizarRequisicao(RequisicaoPostDTO requisicao, int idRequisicao)
        {
            var requisicaoNova = _requisicaoRepository.AtualizarRequisicao(
                new REQUISICAO
                {
                    ID_CLI = requisicao.ID_CLI,
                    TOTAL_REQ = requisicao.TOTAL_REQ,
                    QTD_ITEN = requisicao.QTD_ITEN,
                    DATA_REQ = requisicao.DATA_REQ,
                    ANO = requisicao.ANO,
                    MES = requisicao.MES,
                    ID_SEC = requisicao.ID_SEC,
                    ID_SET = requisicao.ID_SET,
                    OBSERVACAO = requisicao.OBSERVACAO
                }, idRequisicao);
            
            return mapper.Map<RequisicaoGetDTO>(requisicaoNova);
        }
        public void DeletarRequisicao(int idRequisicao)
        {
            _requisicaoRepository.DeletarRequisicao(idRequisicao);
        }
    }
}
