﻿using DomainLayer.Models;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class TeacherRepository : IRepositories<Teacher>
    {
        public void Create(Teacher entity)
        {
            if (entity == null) throw new ArgumentNullException();

            AppDbContext<Teacher>.datas.Add(entity);
        }

        public void Delete(Teacher entity)
        {
            if (entity == null) throw new ArgumentNullException();  

            AppDbContext<Teacher>.datas.Remove(entity);
        }

        public Teacher Get(Predicate<Teacher> predicate)
        {
            return AppDbContext<Teacher>.datas.Find(predicate);
        }

       

        public List<Teacher> GetAll(Predicate<Teacher> predicate=null)
        {
            return predicate==null ? AppDbContext<Teacher>.datas:AppDbContext<Teacher>.datas.FindAll(predicate);
        }

        public bool Update(Teacher entity)
        {
            if (entity == null) throw new ArgumentNullException();
            var result = Get(teacher => teacher.Id == entity.Id);
            if (result != null)
            {

                result.Name = entity.Name;
                result.Surname = entity.Surname;
                result.Address = entity.Address;
                result.Age = entity.Age;
            }
            return true;
        }
    }
}
