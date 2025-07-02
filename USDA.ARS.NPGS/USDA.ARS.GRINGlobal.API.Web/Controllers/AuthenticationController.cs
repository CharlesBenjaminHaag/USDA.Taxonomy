using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using USDA.ARS.GRINGlobal.Domain.Models;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        //private readonly IAuthenticationRepository _codeValueRepository;
        private readonly IConfiguration _configuration;

        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        public AuthenticationController(IConfiguration configuration, ILogger<AuthenticationController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            //_codeValueRepository = referenceRepository ??
            //       throw new ArgumentNullException(nameof(referenceRepository));
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(
         AuthenticationRequestBody authenticationRequestBody)
        {
            // Step 1: validate the username/password
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.user_name.ToString()));
            claimsForToken.Add(new Claim("given_name", user.first_name));
            claimsForToken.Add(new Claim("family_name", user.last_name));
            claimsForToken.Add(new Claim("email", user.email_address));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private AuthenticatedUserDTO ValidateUserCredentials(string? userName, string? password)
        {
            // TO DO
            // Authorize via GG 
            // Return user info

            return new AuthenticatedUserDTO
            {
                id = 1,
                user_name = userName ?? "",
                first_name = "Benjamin",
                last_name = "Haag",
                email_address = "benjamin.haag@usda.gov"
            };
        }
    }
}
