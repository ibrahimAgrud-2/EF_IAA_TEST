
using EF_InternApplicationAutomator.DataAccess.Application;
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

        public List<ApplicationResponseDTO> GetAllApplications()
        {
            return _ApplicationDataAccess.GetAllApplication();
        }

        public ApplicationResponseDTO Find(int appID)
        {
            return _ApplicationDataAccess.Find(appID);
        }

        public int UpdateApplication(int appID, ApplicationCreateDTO appResponseDTO)
        {
            return _ApplicationDataAccess.UpdateApplication(appID, appResponseDTO);
        }

        public int AddApplication(ApplicationCreateDTO newApplication)
        {
           
            if (_person.IsPersonExistByEmail(newApplication.GithubURL))
            {
               
            }

            return _ApplicationDataAccess.AddApplication(newApplication);
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