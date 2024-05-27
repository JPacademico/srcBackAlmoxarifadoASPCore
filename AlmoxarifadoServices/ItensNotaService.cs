using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class ItensNotaService
    {
        private readonly IItensNota _itensNotaRepository;
        private readonly IMapper _mapper;

        public ItensNotaService(IItensNota itensNotaRepository)
        {
            _itensNotaRepository = itensNotaRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<ITENS_NOTA>, List<ItensNotaGetDTO>>();
                cfg.CreateMap<ITENS_NOTA, ItensNotaGetDTO>();
            }).CreateMapper();
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            var itensNota = _itensNotaRepository.ObterTodosItensNota();
            return _mapper.Map<List<ItensNotaGetDTO>>(itensNota);
        }

        public ItensNotaGetDTO ObterItensNotaPorId(int id)
        {
            var itensNota = _itensNotaRepository.ObterItensNotaPorId(id);
            return _mapper.Map<ItensNotaGetDTO>(itensNota);
        }

        public ItensNotaGetDTO CriarItenNota(ItensNotaPostDTO itenNota)
        {
            var newItem = _mapper.Map<ITENS_NOTA>(itenNota);
            var createdItem = _itensNotaRepository.CriarItenNota(newItem);
            return _mapper.Map<ItensNotaGetDTO>(createdItem);
        }
    }
}
