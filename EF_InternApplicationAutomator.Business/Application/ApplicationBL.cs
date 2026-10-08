
using EF_InternApplicationAutomator.DataAccess.Application;
using Shared;
using Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.Business.Application
{
    public class ApplicationBL
    {



        ApplicationDataAccess _ApplicationDataAccess;
        PersonBL _person;

        public ApplicationBL(ApplicationDataAccess applicationDataAccess,PersonBL person)
        {
            _ApplicationDataAccess = applicationDataAccess;
            _person = person;
        }

        public List<ApplicationListDTO> GetAllApplications()
        {
            return _ApplicationDataAccess.GetAllApplication();
        }

        public ApplicationResponseDTO Find(int appID)
        {
            return _ApplicationDataAccess.Find(appID);
        }

        public int UpdateApplication(int appID, ApplicationUpdateDTO appResponseDTO)
        {
            return _ApplicationDataAccess.UpdateApplication(appID, appResponseDTO);
        }

        public int AddApplication(ApplicationCreateSecure newApplicationDTO)
        {
            if (newApplicationDTO == null || newApplicationDTO.PersonInfo == null)
            {
                return -1;
            }
            //mapping

            int personID = 0;
            PersonResponseSDTO? personCreateSDTO = _person.FindByEmail(newApplicationDTO.PersonInfo.Email);
            if(personCreateSDTO==null)
            {
                personID=_person.AddPerson(newApplicationDTO.PersonInfo);

            }
            else
            {
                personID = personCreateSDTO.PersonID;
            }

            //mapping
            //TODO: sistemde aktif user kimse onun ID'sini alsın
            ApplicationCreateDTO application = new ApplicationCreateDTO(personID, newApplicationDTO.PersonInfo,2,null,DateTime.Now.Date, newApplicationDTO.University, newApplicationDTO.Department, newApplicationDTO.ClassYear, 1, newApplicationDTO.Notes, newApplicationDTO.LinkedinURL, newApplicationDTO.GithubURL);



            return _ApplicationDataAccess.AddApplication(application);
        }

        public bool DeleteApplication(int appID)
        {
            return _ApplicationDataAccess.DeleteApplication(appID);
        }
        
        public bool IsApplicationExists(int appID)
        {
            return _ApplicationDataAccess.IsApplicationExists(appID);
        }
    }
}