using Application.Dtos;
using Application.Enums;
using Application.Interfaces;
using Application.Interfaces.Mappers;
using Application.Mappers;
using AutoMapper;
using AutoMapper.Execution;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application
{
    public class ApplicationServiceRobot : IApplicationServiceRobot
    {
        private readonly IRobotService robotService;
        private IMapperRobot mapperRobot;
        private IApplicationValidations validations;

        public ApplicationServiceRobot(IRobotService robotService, IMapperRobot mapperRobot, IApplicationValidations validations)
        {
            this.robotService = robotService;
            this.mapperRobot = mapperRobot;
            this.validations = validations;

            ResetState();
        }

        public async Task<bool> ResetState()
        {
            var robot = robotService.GetState();

            robot.HeadRotation = (int)RotateHeadEnum.AtRest;
            robot.HeadInclination = (int)InclinateEnum.AtRest;
            robot.LeftElbow = (int)ContractLevelEnum.AtRest;
            robot.LeftFist = (int)RotateFistEnum.AtRest;
            robot.RightElbow = (int)ContractLevelEnum.AtRest;
            robot.RightFist = (int)RotateFistEnum.AtRest;

            await robotService.ResetState(robot);
            return true;
        }

        public RobotDto GetState()
        {
            var robot = robotService.GetState();
            var robotDto = mapperRobot.MapperEntityToDto(robot);
            return robotDto;
        }

        public async Task<bool> Contract(int member, int contractLevel)
        {

            var isContractLevel = validations.IsContractLevel(contractLevel, typeof(ContractLevelEnum));
            var robotState = robotService.GetState();
            var whichMember = validations.WhichMember(member);
            //var isValidProgress = validations.StateIsValid(contractLevel, robotState.LeftElbow);
            var stateRightElbow = validations.StateIsValid(contractLevel, robotState.RightElbow);
            var stateLeftElbow = validations.StateIsValid(contractLevel, robotState.LeftElbow);


            if (whichMember == MemberEnum.LeftElbow && isContractLevel)
            {
                if (stateLeftElbow)
                    robotState.LeftElbow = contractLevel;
                else
                    return false;
            } 
            else if (whichMember == MemberEnum.RightElbow && isContractLevel)
            {
                if (stateRightElbow)
                    robotState.RightElbow = contractLevel;
                else
                    return false;
            } else
            {
                return false;
            }
            await robotService.Contract(robotState);
            return true;
        }

        public async Task<bool> Rotate(int member, int rotateLevel)
        {
            var whichMember = validations.WhichMember(member);
            var robotState = robotService.GetState();
            var isFistRotate = validations.IsFistRotate(rotateLevel, typeof(RotateFistEnum));
            var isHeadRotate = validations.IsHeadRotate(rotateLevel, typeof(RotateHeadEnum));
            

            switch (whichMember)
            {
                case MemberEnum.Head:
                    var stateHead = validations.StateIsValid(rotateLevel, robotState.HeadRotation);
                    bool headInclination = robotState.HeadInclination != (int)InclinateEnum.ToDown;

                    if (stateHead && isHeadRotate && headInclination)
                        robotState.HeadRotation = rotateLevel;
                    else
                        return false;
                    break;
                case MemberEnum.LeftFist:
                    var stateLeftFist = validations.StateIsValid(rotateLevel, robotState.LeftFist);
                    bool movementLeftFist = robotState.LeftElbow == (int)ContractLevelEnum.StrongContracted;

                    if (stateLeftFist && isFistRotate && movementLeftFist)
                        robotState.LeftFist = rotateLevel;
                    else
                        return false;
                    break;
                case MemberEnum.RightFist:
                    var stateRightFist = validations.StateIsValid(rotateLevel, robotState.RightFist);
                    bool movementRightFist = robotState.LeftElbow == (int)ContractLevelEnum.StrongContracted;

                    if (stateRightFist && isFistRotate && movementRightFist)
                        robotState.LeftFist = rotateLevel;
                    else
                        return false;
                    break;
                default:
                    return false;
            }

            var teste = await robotService.Rotate(robotState);
            return true;
        }

        public async Task<bool> Inclinate(int member, int inclinate)
        {
            var IsInclinate = validations.IsInclinate(inclinate, typeof(ContractLevelEnum));
            var robotState = robotService.GetState();
            var whichMember = validations.WhichMember(member);
            //var isValidProgress = validations.StateIsValid(contractLevel, robotState.LeftElbow);


            if (whichMember == MemberEnum.Head && IsInclinate)
            {
                var stateHeadInclination = validations.StateIsValid(inclinate, robotState.HeadInclination);

                if (stateHeadInclination)
                    robotState.HeadInclination = inclinate;
                else
                    return false;
            }
            else
            {
                return false;
            }
            await robotService.Contract(robotState);
            return true;
        }

    }
}
