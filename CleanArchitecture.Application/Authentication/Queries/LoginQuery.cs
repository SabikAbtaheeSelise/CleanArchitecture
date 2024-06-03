using CleanArchitecture.Application.Authentication.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authentication.Queries;
public record LoginQuery(
    string Email,
    string Password) :IRequest<ErrorOr<AuthenticationResult>>;
