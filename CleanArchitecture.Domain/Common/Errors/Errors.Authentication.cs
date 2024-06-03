using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common.Errors;
public static partial class Errors
{
    public static class Authentication
    {

        public static Error InvalidCredentails => Error.Validation(
            code: "User.InvalidCredentails",
            description: "Invalid Credentails");
    }
}
