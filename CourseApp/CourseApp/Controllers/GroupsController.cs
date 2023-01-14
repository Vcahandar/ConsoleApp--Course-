using DomainLayer.Models;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = DomainLayer.Models.Group;

namespace CourseApp.Controllers
{
    public class GroupsController
    {
        private readonly IGroupServices _groupServices;

        public GroupsController()
        {
            _groupServices = new GroupServices();


        }

        public void Create()
        {
            string pettern = "^(?!\\s+$)[a-zA-Z]+$";

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
        TeacherId: string teacherId1 = Console.ReadLine();
            int teacherId;
            bool isTrueTeacherId = int.TryParse(teacherId1, out teacherId);
            
            
                if (!isTrueTeacherId)
                {
                    ConsoleColor.Red.WriteConsole("You don't have a group");
                    goto TeacherId;
                }
                else if (Regex.IsMatch(teacherId1, pettern))
                {
                    ConsoleColor.Red.WriteConsole("Please Add Teacher Id");
                    goto TeacherId;

                }


            ConsoleColor.DarkCyan.WriteConsole("Please add Group name:");
        GroupName: string groupName = Console.ReadLine();
            if (groupName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Group name:");
                goto GroupName;

            }
            //else if (!Regex.IsMatch(groupName, pettern))
            //{
            //    ConsoleColor.Red.WriteConsole("Please add letter ");
            //    goto GroupName;
            //}

            ConsoleColor.DarkCyan.WriteConsole("Please add Group capacity:");
        GroupCapacity: string groupCapacity = Console.ReadLine();

            if (groupCapacity == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Group capacity:");
                goto GroupCapacity;
            }

            int capacity;

            bool isTrue = int.TryParse(groupCapacity, out capacity);

            if (isTrue && isTrueTeacherId)
            {
                try
                {
                    Group group = new Group
                    {
                        Name = groupName,
                        Capacity = capacity,
                        Ceratdate = DateTime.Now,
                    };

                    var response = _groupServices.Create(group, teacherId);
                    ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name},  Capacity:{response.Capacity}, Datetime:{response.Ceratdate} name:{response.Teacher.Name} ");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Teacher Id:");
                    goto GroupCapacity;

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please Enter the correct Capacity");
                goto GroupCapacity;
            }

        }
             
     }


}

 
