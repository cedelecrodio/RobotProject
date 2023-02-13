using Data.Config;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RobotRepository : BaseMovementsRepository<Robot>, IRobotRepository
    {
        private readonly ContextBase contextBase;

        public RobotRepository(ContextBase contextBase) : base(contextBase) 
        {
            this.contextBase = contextBase;
        }

        //public async Task<Robot> GetState()
        //{
        //    Robot robot = await contextBase.Set<Robot>().FindAsync();
        //    return robot;
        //}

        public Robot GetState()
        {
            Robot robot = contextBase.Robot.First();
            return robot;
        }
    }
}
