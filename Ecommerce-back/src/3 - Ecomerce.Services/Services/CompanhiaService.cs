using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.Core.Exceptions;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Interface;
using Ecomerce.Services.DTO;
using Ecomerce.Services.Interfaces;

namespace Ecomerce.Services.Services
{
    public class CompanhiaService : ICompanhiaService
    {
        private readonly IMapper _mapper;
        private readonly ICompanhiaRepository _companhiaRepository;

        public CompanhiaService(IMapper mapper, ICompanhiaRepository companhiaRepository)
        {
            _mapper = mapper;
            _companhiaRepository = companhiaRepository;
        }

        public async Task<CompanhiaDTO> Create(CompanhiaDTO companhiaDTO)
        {
            var existeCompanhia = await _companhiaRepository.Get(companhiaDTO.Id);

            if(existeCompanhia != null)
            {
                throw new DomainException("Já existe essa companhia em nossa base de dados");
            }

            var companhia = _mapper.Map<Companhia>(companhiaDTO);
            companhia.Validate();

            var criarCompanhia = await _companhiaRepository.Create(companhia);
            return _mapper.Map<CompanhiaDTO>(criarCompanhia);
        }

        public async Task<CompanhiaDTO> Get(int id)
        {
            var companhia = await _companhiaRepository.Get(id);

            return _mapper.Map<CompanhiaDTO>(companhia);
        }

        public async Task Remove(int id)
        {
            await _companhiaRepository.Remove(id);
        }

        public async Task<CompanhiaDTO> Update(CompanhiaDTO companhiaDTO)
        {
            var existeCompanhia = await _companhiaRepository.Get(companhiaDTO.Id);

            if(existeCompanhia == null)
            {
                throw new DomainException("Não existe nenhuma companhia na nossa base de dados");
            }

            var companhia =  _mapper.Map<Companhia>(companhiaDTO);
            companhia.Validate();

            var atualizarCompanhia = await _companhiaRepository.Updade(companhia);
            return _mapper.Map<CompanhiaDTO>(atualizarCompanhia);
        }

        public async Task<List<CompanhiaDTO>> Get()
        {
            var todasCompanhias = await _companhiaRepository.Get();

            return _mapper.Map<List<CompanhiaDTO>>(todasCompanhias);
        }
    }
}