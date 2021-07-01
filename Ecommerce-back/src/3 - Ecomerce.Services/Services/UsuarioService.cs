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
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> Create(UsuarioDTO usuarioDTO)
        {
            var existeUsuario = await _usuarioRepository.GetByEmail(usuarioDTO.Email);

            if(existeUsuario != null)
            {
                throw new DomainException("Já existe um usuário cadastrado com o e-mail informado");
            }

            var usario = _mapper.Map<Usuario>(usuarioDTO);
            usario.Validate();

            var criandoUsuario = await _usuarioRepository.Create(usario);
            return _mapper.Map<UsuarioDTO>(criandoUsuario);
        }

        public async Task<UsuarioDTO> Update(UsuarioDTO usuarioDTO)
        {
            var existeUsuario = await _usuarioRepository.Get(usuarioDTO.Id);

            if(existeUsuario == null)
            {
                throw new DomainException("Não existe nenhum usuário com o id informado.");
            }

            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            usuario.Validate();

            var atualizarUsuario = await _usuarioRepository.Updade(usuario);
            return _mapper.Map<UsuarioDTO>(atualizarUsuario);
        }

        public async Task Remove(int id)
        {
            await _usuarioRepository.Remove(id);
        }

        public async Task<UsuarioDTO> Get(int id)
        {
            var usuario = await _usuarioRepository.Get(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<List<UsuarioDTO>> Get()
        {
            var todosUsuario = await _usuarioRepository.Get();
            
            return _mapper.Map<List<UsuarioDTO>>(todosUsuario);
        }

        public async Task<List<UsuarioDTO>> GetByEmail(string email)
        {
            var usuario = await _usuarioRepository.GetByEmail(email);
            
            return _mapper.Map<List<UsuarioDTO>>(usuario);
        }

        public async Task<List<UsuarioDTO>> SearchByEmail(string email)
        {
            var todosUsuario = await _usuarioRepository.SearchByEmail(email);

            return _mapper.Map<List<UsuarioDTO>>(email);
        }

        public async Task<List<UsuarioDTO>> SearchByNome(string nome)
        {
            var todosUsuario = await _usuarioRepository.SearchByNome(nome);
            return _mapper.Map<List<UsuarioDTO>>(nome);
        }
    }
}