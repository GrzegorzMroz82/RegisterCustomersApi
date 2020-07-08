using System;
using System.Collections.Generic;
using System.Text;

namespace GameTek.Boundary
{
    public interface IUseCaseActivator
    {
        void Activate(IUseCaseRequest request);
    }
}
