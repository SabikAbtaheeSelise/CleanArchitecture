﻿using CleanArchitecture.Application.Authentication.Commands;
using CleanArchitecture.Application.Authentication.Common;
using CleanArchitecture.Application.Authentication.Queries;
using CleanArchitecture.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(
            ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
           

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password );
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            //ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(request.Email, request.Password);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.user.Id,
                            authResult.user.FirstName,
                            authResult.user.LastName,
                            authResult.user.Email, authResult.Token);
        }
    }
}
