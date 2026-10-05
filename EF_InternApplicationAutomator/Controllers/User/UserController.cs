
    using EF_InternApplicationAutomator.Business;
    using EF_InternApplicationAutomator.Business.User;
    using EF_InternApplicationAutomator.DataAccess;
    using Microsoft.AspNetCore.Mvc;
    using Shared;
    using Shared.User;
    using System;

    namespace EF_InternApplicationAutomator.API.Controllers.User
    {
        [Route("api/User")]
        [ApiController]
        public class UserController: ControllerBase
        {
            UserBL _User;
            public UserController(UserBL u)
            {
                _User = u;
            }

            [HttpGet("All")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<IEnumerable<UserResponseDTO>> GetAllUser()
            {

                List<UserResponseDTO> StudentList = _User.GetAllUser();
                if (StudentList.Count == 0)
                {
                    return NotFound("No Data Available in the Table");
                }

                return Ok(StudentList);
            }



        }
    }
