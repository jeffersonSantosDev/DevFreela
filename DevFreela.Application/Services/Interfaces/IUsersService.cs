﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUsersService
    {
        List<UsersViewModel> GetById(int id);
        int Create(CreateUserInputModel userInputModel);
    }
}
