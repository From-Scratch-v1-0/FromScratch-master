using FS_DAL.Context;
using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratch.Models.Repositories
{
    //NewRepository//
    //მოკლედ პროექტებისთვის შევქმენი ახალი რეფოზითორი!!//
    public interface IProjectRepository
    {
        void AddProject(ProjectProduct projprod);
        bool ExistProject(string projname);
        IEnumerable<ProjectProduct> GetAllProjects();
    }
    public class ProjectRepository:IProjectRepository
    {
        private readonly FSContext _fscontext;
        public ProjectRepository(FSContext fscontext)
        {
            _fscontext = fscontext;
        }
        public void AddProject(ProjectProduct projprod)
        {
            _fscontext.ProjectProduct.Add(projprod);
            _fscontext.SaveChanges();
        }
        public bool ExistProject(string projname)
        {
            var proj = _fscontext.ProjectProduct.Any(u => u.ProjectName == projname);
            if (proj)
                return true;
            return false;
        }
        public IEnumerable<ProjectProduct> GetAllProjects()
        {
            return _fscontext.ProjectProduct.ToList();
        }
    }
}
