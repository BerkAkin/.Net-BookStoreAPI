using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.TokenOperations.Models;
using WebApi.DBOperations;

namespace WebApi.Application.UserOperations.Commands
{
    public class CreateTokenCommand
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;
        public CreateTokenModel Model { get; set; }

        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is not null)
            {
                //token yarat
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı");
            }

        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}