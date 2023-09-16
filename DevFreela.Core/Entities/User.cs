using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirtDat = birthDate;
            Active = true;
                       
            CreateAt = DateTime.Now;
            Skills = new List<UserSkills> { };
            OwnedProjects = new List<Project> { };
            FreelancedProjects = new List<Project>();
            
            
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirtDat { get; private set; }
        public DateTime CreateAt { get; private set; }
        public bool Active { get; private set; }
        public List<UserSkills> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelancedProjects { get; private set; }
    }
}
