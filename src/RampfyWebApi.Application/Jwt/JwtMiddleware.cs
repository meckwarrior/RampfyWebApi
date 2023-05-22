using AutoMapper;
using Microsoft.AspNetCore.Http;
using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Application.ViewModels;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Application.Jwt
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUsuarioAppService usuarioAppService, IJwtUtils jwtUtils, IMapper mapper)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = mapper.Map<Usuario,UsuarioViewModel>(await usuarioAppService.GetByIdAsync(userId.Value));
            }

            await _next(context);
        }
    }
}