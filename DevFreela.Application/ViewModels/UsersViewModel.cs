using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel(string fullName, string email, DateTime birtDat, DateTime createAt, bool active)
        {
            FullName = fullName;
            Email = email;
            BirtDat = birtDat;
            CreateAt = createAt;
            Active = active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirtDat { get; private set; }
        public DateTime CreateAt { get; private set; }
        public bool Active { get; private set; }
    }
}
