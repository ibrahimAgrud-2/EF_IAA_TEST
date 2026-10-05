
using EF_InternApplicationAutomator.Business;
using EF_InternApplicationAutomator.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using static EF_InternApplicationAutomator.Business.PersonBL;

namespace EF_InternApplicationAutomator.API.Controllers
{


    [Route("api/Person")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        //PL ile BL Arasında iletişimi obje üzerine sağlayabilmek için objeyi const ile dolduruyoruz.
        PersonBL _person;
        public PersonController(PersonBL p)
        {
            _person = p;
        }

        

        //here we use http put method for update
        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> UpdateStudent(int id,PersonCreateSDTO personCreateDTO)
        {



            //TODO: Inset isPersonExist Function. If person does not exist return NotFound



            if (_person.UpdatePerson(id, personCreateDTO))
            {
                return Ok("ok");
            }
            else
            {
                //TODO: set a return status code for fail to update instance
                return NotFound("Cloud Not Updated");
            }

        }
    }
}
