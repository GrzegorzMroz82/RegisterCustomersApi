using System;
using System.Collections.Generic;
using System.Text;

namespace GameTek.Boundary
{
    public enum RegisterResult { Success, AlreadyExist, MissingRequired,Created }

    public interface IRegisterResponder
    {
        void SetResult(RegisterResult result);
    }
}
