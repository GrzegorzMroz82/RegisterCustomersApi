using GameTek.Boundary;
using GameTek.Model;
using System;

namespace GameTek.Application
{
    public class RegisterUseCase : IUseCaseActivator
    {
        IRegistrationRepository repository;
        IRegisterResponder responder;

        public RegisterUseCase(IRegistrationRepository repository, IRegisterResponder responder)
        {
            this.repository = repository;
            this.responder = responder;
        }

        
        public void Activate(IUseCaseRequest request)
        {
            var rdto = request as RegistrationDto;

            RegistrationEntity user = repository.FindUser(rdto.BrandId, rdto.FirstName, rdto.LastName, rdto.Address);
            responder.SetResult(RegisterResult.AlreadyExist);
            return;

        }
    }
}
