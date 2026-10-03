
using EF_InternApplicationAutomator.Business;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PersonResponseDto>> GetAllPeople()
        {

            List<PersonResponseDto> StudentList = _person.GetAllPeople();
            if (StudentList.Count == 0)
            {
                return NotFound("No Data Available in the Table");
            }

            return Ok(StudentList);
        }


        [HttpGet("{ID}", Name = "Find")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PersonResponseDto> Find(int ID)
        {
            if (ID < 1)
            {
                return BadRequest($"Not Accepted ID {ID}");
            }
            PersonResponseDto p = _person.Find(ID);
            if (p == null)
            {
                return NotFound($"No Person With ID {ID}");
            }
            return Ok(p);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonResponseDto> AddNewPerson(PersonCreateDTO newStudentDTO)
        {

            //we validate the data here
            if (newStudentDTO == null )
            {
                return BadRequest("Invalid student data.");
            }
            int ID = _person.AddPerson(newStudentDTO);
          
            return CreatedAtRoute("Find", new { id = ID }, newStudentDTO);

        }

        //here we use http put method for update
        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonResponseDto> UpdateStudent(int id, PersonCreateDTO updatedPerson)
        {
            if (id < 1 || updatedPerson == null )
            {
                return BadRequest("Invalid Person data.");
            }



            PersonResponseDto personResponseDto = _person.Find(id);

            if(personResponseDto == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

       
            if(_person.UpdatePerson(id, updatedPerson))
            {
                return Ok(personResponseDto);
            }
            else
            {
                //TODO: set a return status code for fail to update instance
                return NotFound("Cloud Not Updated");
            }

        }
    }
}
