using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.DataAccess.Application
{
    public class ApplicationDataAccess
    {

        
        private readonly IAADbContext _Context;
        public ApplicationDataAccess(IAADbContext context)
        {
            _Context = context;
        }


        public List<ApplicationResponseDTO> GetAllApplication()
        {
            List<ApplicationEntity> applications = _Context.Applications.ToList();

            List<ApplicationResponseDTO> applicationResponseDTOs = new List<ApplicationResponseDTO>();

            //mapping
            foreach (var app in applications)
            {
                applicationResponseDTOs.Add(new ApplicationResponseDTO(app.ApplicationID,app.PersonID,app.ReviewedByUserID,app.ReviewDate,app.ApplicationDate,app.University,app.Department,app.ClassYear,app.Status,app.Notes,app.LinkedinURL,app.GithubURL));
            }
            return applicationResponseDTOs;
        }
        public ApplicationResponseDTO Find(int appID)
        {
            ApplicationEntity app = _Context.Applications.Find(appID);
            if (app == null)
            {
                //Log
                return null;
            }
            else
            {
                return new ApplicationResponseDTO(app.ApplicationID, app.PersonID, app.ReviewedByUserID, app.ReviewDate, app.ApplicationDate, app.University, app.Department, app.ClassYear, app.Status, app.Notes, app.LinkedinURL, app.GithubURL);
            }
        }
        public int AddApplication(ApplicationCreateDTO app)
        {

            ApplicationEntity appEntity = new ApplicationEntity(
                0, app.PersonID, app.ReviewedByUserID, app.ReviewDate, app.ApplicationDate, app.University, app.Department, app.ClassYear, app.Status, app.Notes, app.LinkedinURL, app.GithubURL
            );

            EntityEntry<ApplicationEntity> pw = _Context.Applications.Add(appEntity);

            if (_Context.SaveChanges() > 0)
            {
                return appEntity.ApplicationID;
            }

            return -1;
        }

        public int UpdateApplication(int appID, ApplicationCreateDTO appResponseDTO)
        {
            var app = _Context.Applications.Find(appID);

            if (app == null || appResponseDTO == null)
            {
                return -1;
            }

            app.PersonID = appResponseDTO.PersonID;
            app.ReviewedByUserID = appResponseDTO.ReviewedByUserID;
            app.ReviewDate = appResponseDTO.ReviewDate;
            app.ApplicationDate = appResponseDTO.ApplicationDate;
            app.University = appResponseDTO.University;
            app.Department = appResponseDTO.Department;
            app.ClassYear = appResponseDTO.ClassYear;
            app.Status = appResponseDTO.Status;
            app.Notes = appResponseDTO.Notes;
            app.LinkedinURL = appResponseDTO.LinkedinURL;
            app.GithubURL = appResponseDTO.GithubURL;

            if (_Context.SaveChanges() > 0)
            {
                return appID;
            }

            return -1;
        }

        public bool DeleteApplication(int appID)
        {
            return _Context.Applications
                    .Where(a => a.ApplicationID == appID)
                    .ExecuteDelete() > 0;
        }

        public bool IsApplicationExists(int appID)
        {
            return _Context.Applications.Any(app=>app.ApplicationID==appID);
        }

    }
}
