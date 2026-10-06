using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 


namespace Shared.Application
{
    public class ApplicationResponseDTO
    {
        [Required]
        public int ApplicationID { get; set; }

        [Required]
        public int PersonID { get; set; }

        /// <summary>
        /// An Nullable Value. So check it before use it
        /// </summary>
        public int? ReviewedByUserID { get; set; }

        /// <summary>
        /// An Nullable Value. So check it before use it
        /// </summary>
        public DateTime? ReviewDate { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string University { get; set; }

        [Required]
        [MaxLength(30)]
        public string Department { get; set; }

        [Required]
        public short ClassYear { get; set; }

        [Required]
        public byte Status { get; set; } 

        [MaxLength(150)]
        public string Notes { get; set; } 

        [MaxLength(150)]
        public string CVPath { get; set; }

        [MaxLength(50)]
        public string LinkedinURL { get; set; }

        [MaxLength(50)]
        public string GithubURL { get; set; }

        public ApplicationResponseDTO(int applicationID, int personID, int? reviewedByUserID,
            DateTime? reviewDate, DateTime applicationDate, string university, string department,
            short classYear, byte status, string notes, string cvPath, string linkedinURL, string githubURL)
        {
            this.ApplicationID = applicationID;
            this.PersonID = personID;
            this.ReviewedByUserID = reviewedByUserID;
            this.ReviewDate = reviewDate;
            this.ApplicationDate = applicationDate;
            this.University = university;
            this.Department = department;
            this.ClassYear = classYear;
            this.Status = status;
            this.Notes = notes;
            this.CVPath = cvPath;
            this.LinkedinURL = linkedinURL;
            this.GithubURL = githubURL;
        }
    }
}