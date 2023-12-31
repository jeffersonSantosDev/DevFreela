﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels; 

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectServices
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);        
        int Create(NewProjectInputModel inputModel);        
        void Update(UpdateProjectInputModel inputModel);        
        void Delete(int id);        
        void CreateComment(CreateCommentInputModel inputModel);         
        void Start(int id);
        void Finish(int id);
    }
}
