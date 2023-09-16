using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UsersService : IUsersService
    {
        public readonly DevFreelaDbContext _dbContext;

        public UsersService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel userInputModel)
        {
            var newUser = new User(userInputModel.FullName, userInputModel.Email, userInputModel.BirtDat);

            _dbContext.Users.Add(newUser);

            return newUser.Id;
        }
        public List<UsersViewModel> GetById(int id)
        {
            var users = _dbContext.Users;

            var userViewlModel = users.Select(u => new UsersViewModel(u.FullName, u.Email,u.BirtDat,u.CreateAt,u.Active)).ToList(); 

            return userViewlModel;
        }
    }
}
