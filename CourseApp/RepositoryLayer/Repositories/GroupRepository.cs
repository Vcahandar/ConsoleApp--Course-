using DomainLayer.Models;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class GroupRepository : IRepositories<Group>
    {
        public void Create(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();

            AppDbContext<Group>.datas.Add(entity);
        }

        public void Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Group entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
