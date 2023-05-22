using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using RampfyWebApi.Application.HttpModels;
using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Application.ViewModels;
using RampfyWebApi.Domain.Entities;
using RampfyWebApi.Domain.Interfaces.Services;

namespace RampfyWebApi.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        public UsuarioAppService(IUsuarioService usuarioService, IJwtUtils jwtUtils, IMapper mapper) : base(usuarioService)
        {
            _usuarioService = usuarioService;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
    }

        public async Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest request)
        {
            UsuarioViewModel usuarioViewModel = null;

            string token = "";

            usuarioViewModel = _mapper.Map<Usuario, UsuarioViewModel>(
                await _usuarioService.AuthenticationAsync(new Usuario(request.Email, request.Senha)));

            if(usuarioViewModel != null) 
            {
                // authentication successful so generate jwt token
                token =  _jwtUtils.GenerateJwtToken(usuarioViewModel);
            }

            return new AuthenticationResponse(usuarioViewModel, token);
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetTodosAsync()
        {
            return _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(await GetAllAsync());
        }

        public async Task AdicionarAsync(UsuarioViewModel usuarioViewModel) 
        {
            await AddAsync(_mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
        }
    }
}
