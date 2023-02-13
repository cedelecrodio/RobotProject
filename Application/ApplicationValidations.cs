using Application.Enums;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApplicationValidations : IApplicationValidations
    {
        public bool StateIsValid(int state, int currentState)
        {
            if (state == currentState + 1 || state == currentState - 1)
            {
                return true;
            }
            return false;
        }

        public bool IsContractLevel(int state, Type ContractLevelEnum)
        {
            return Enum.IsDefined(ContractLevelEnum, state);
        }

        public bool IsHeadRotate(int state, Type RotateHeadEnum)
        {
            return Enum.IsDefined(RotateHeadEnum, state);
        }

        public bool IsFistRotate(int state, Type RotateFistEnum)
        {
            return Enum.IsDefined(RotateFistEnum, state);
        }

        public bool IsInclinate(int state, Type InclinateEnum)
        {
            return Enum.IsDefined(InclinateEnum, state);
        }

        public MemberEnum WhichMember(int member)
        {
            switch (member)
            {
                case 1:
                    return MemberEnum.LeftElbow;
                case 2:
                    return MemberEnum.LeftFist;
                case 3:
                    return MemberEnum.RightElbow;
                case 4:
                    return MemberEnum.RightFist;
                case 5:
                    return MemberEnum.Head;
                default:
                    return MemberEnum.Undefined;
            }
        }
    }
}
