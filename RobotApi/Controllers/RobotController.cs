using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RobotApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IApplicationServiceRobot applicationServiceRobot;

        public RobotController(IApplicationServiceRobot applicationServiceRobot)
        {
            this.applicationServiceRobot = applicationServiceRobot;
        }

        [HttpGet]
        public ActionResult<RobotDto> Get()
        {
            RobotDto result = applicationServiceRobot.GetState();
            string jsonResult = JsonConvert.SerializeObject(result);

            return Ok(jsonResult);
        }

        [HttpPut("/Contract/{member}/{contractLevel}")]
        public async Task<ActionResult> Contract(int member, int contractLevel)
        {
            try
            {
                if (member == 0)
                    return NotFound();

                //await applicationServiceRobot.Contract(member, contractLevel);
                var contractSuccessful = await applicationServiceRobot.Contract(member, contractLevel);

                if (!contractSuccessful)
                {
                    return BadRequest("Não foi possível contrair o cotovelo");
                }
                return Ok("Cotovelo contraído com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao contrair o cotovelo: " + ex);
            }
        }

        [HttpPut("/Rotate/{member}/{rotateLevel}")]
        public async Task<ActionResult> Rotate(int member, int rotateLevel)
        {
            try
            {
                if (member == 0)
                    return NotFound();

                var contractSuccessful = await applicationServiceRobot.Rotate(member, rotateLevel);

                if (!contractSuccessful)
                {
                    return BadRequest("Não foi possível rotacionar");
                }
                return Ok("Rotacionado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao rotacionar: " + ex);
            }
        }

        [HttpPut("/Inclinate/{member}/{inclinate}")]
        public async Task<ActionResult> Inclinate(int member, int inclinate)
        {
            try
            {
                if (member == 0)
                    return NotFound();

                var contractSuccessful = await applicationServiceRobot.Inclinate(member, inclinate);

                if (!contractSuccessful)
                {
                    return BadRequest("Não foi possível inclinar");
                }
                return Ok("Inclinado com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao inclinar: " + ex);
            }
        }
    }
}
