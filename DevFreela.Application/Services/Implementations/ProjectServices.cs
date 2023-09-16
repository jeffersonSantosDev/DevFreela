﻿using DevFreela.Application.InputModels;
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
    public class ProjectServices : IProjectServices
    {
        public readonly DevFreelaDbContext _dbContext;
        public ProjectServices(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title,inputModel.Description,inputModel.IdClient,inputModel.IdFreelance,inputModel.TotalCost);

            _dbContext.Projects.Add(project); 

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);   
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id); 
             
            project?.Cancel();             
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
             
            project?.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectViewModel = projects.Select(p => new ProjectViewModel(p.Id,p.Title,p.CreatedAt)).ToList();

            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var projects = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (projects == null)  return null; 

            var projectDetailsViewModel = new ProjectDetailsViewModel(
            projects.Id,
            projects.Title,
            projects.Description,
            projects.TotalCost,
            projects.StartedAt,
            projects.FinishedAt                
            );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            
            project?.Start();            
            
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);            
        }
    }
}
