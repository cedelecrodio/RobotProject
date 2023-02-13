using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationValidations
    {
        bool StateIsValid(int state, int currentState);

        MemberEnum WhichMember(int member);

        bool IsContractLevel(int state, Type ContractLevelEnum);
        bool IsHeadRotate(int state, Type RotateHeadEnum);
        bool IsFistRotate(int state, Type RotateFistEnum);
        bool IsInclinate(int state, Type InclinateEnum);

    }
}
