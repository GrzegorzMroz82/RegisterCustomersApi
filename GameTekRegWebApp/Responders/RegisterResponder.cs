using GameTek.Boundary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTekRegWebApp.Responders
{
    public class RegisterResponder : IRegisterResponder
    {
        RegisterResult result;
        public void SetResult(RegisterResult result)
        {
            this.result = result;
        }

        public StatusCodeResult GetHttpResult()
        {
            switch (result)
            {
                case RegisterResult.Success:
                    return new OkResult();
                case RegisterResult.AlreadyExist:
                    return new ConflictResult();
                case RegisterResult.MissingRequired:
                    return new BadRequestResult();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
