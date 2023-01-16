using DomainLayer.Models;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    ConsoleColor.Green.WriteConsole(
                      $"Id: {response.Id}\nGroup Name: {response.Name}\nCapacity: {response.Capacity}" +
                      $"\nTeacher Name : {response.Teacher.Name}\nCreate date: {response.Ceratdate.ToString("dd.MM.yyyy")} ");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please Add the Teacher ID again:");
                    goto TeacherId;

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please Enter the correct Capacity");
                goto GroupCapacity;
            }

        }

        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Group Id for delete:");
        GroupId: string groupId = Console.ReadLine();

            int id;

            bool isCorrectId=int.TryParse(groupId, out id);
            if (isCorrectId)
            {
                try
                {
                    _groupServices.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully delete");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher Id again");
                    goto GroupId;
                }
            }

        }

        public void GetByIdGroup()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Group Id:");
        ByIdGroup: string GetById = Console.ReadLine();

            if (GetById == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Group Id:");
                goto ByIdGroup;
            }

            int byIdNum;

            bool isByIdTrue=int.TryParse(GetById, out byIdNum);
            if (isByIdTrue)
            {
                try
                {
                    Group gruop = new Group()
                    {
                        Id = byIdNum,
                    };

                    var result = _groupServices.GetGroupById(byIdNum);
                    ConsoleColor.Green.WriteConsole(
                      $"Id: {result.Id}\nGroup Name: {result.Name}\nCapacity: {result.Capacity}" +
                      $"\nTeacher Name : {result.Teacher.Name}\nCreate date: {result.Ceratdate.ToString("dd.MM.yyyy")} ");


                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Group Id again:");
                }

            }

        }

        public void GetGroupBySearchName()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
        SearchText: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please don't empty search text");
                goto SearchText;
            }

            try
            {
                var result = _groupServices.GetGroupBySearchName(searchText);

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole(
                                         $"Id: {item.Id}\nGroup Name: {item.Name}\nCapacity: {item.Capacity}" +
                                         $"\nTeacher Name : {item.Teacher.Name}\nCreate date: {item.Ceratdate.ToString("dd.MM.yyyy")} ");
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Retype the word you're looking for ");
                goto SearchText;

            }


        }

        public void GetGroupByTeacherName()
        {

            string pettern = "^(?!\\s+$)[a-zA-Z]+$";

            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
        SearchText: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please don't empty search text");
                goto SearchText;
            }
            else if (!Regex.IsMatch(searchText, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter ");
                goto SearchText;
            }
            try
            {
                var result = _groupServices.GetGroupByTeacherName(searchText);

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole(
                        $"Id: {item.Id}, Name: {item.Name}, Capacity: {item.Capacity}," +
                        $" Teacher Name : {item.Teacher.Name} Create date: {item.Ceratdate.ToString("dd,MM,yyyy")} ");
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Retype the word you're looking for");
                goto SearchText;
            }


        }

        public void GetGroupByCapacity()
        {
            string pettern = "^(?!\\s+$)[a-zA-Z]+$";

            ConsoleColor.DarkCyan.WriteConsole("Please add capacity number:");
        ByCapacityGroup: string GetByCapacity = Console.ReadLine();

            if (GetByCapacity == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Group Id:");
                goto ByCapacityGroup;
            }
            else if (Regex.IsMatch(GetByCapacity, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add number ");
                goto ByCapacityGroup;
            }

            int capacityNum;

            bool isCapacityNumTrue=int.TryParse(GetByCapacity, out capacityNum);
            if (isCapacityNumTrue)
            {
                try
                {
                    Group group = new Group()
                    {
                        Capacity= capacityNum,

                    };
                    var response = _groupServices.GetGroupByCapacity(capacityNum);
                    ConsoleColor.Green.WriteConsole(
                     $"Id: {response.Id}\nGroup Name: {response.Name}\nCapacity: {response.Capacity}" +
                     $"\nTeacher Name : {response.Teacher.Name}\nCreate date: {response.Ceratdate.ToString("dd.MM.yyyy")} ");

                }
                catch (Exception ex )
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Group Capacity again:");

                }

            }

        }

        public void GetGroupByTeacherId()
        {
            string pettern = "^(?!\\s+$)[a-zA-Z]+$";


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
        ById: string GetByTeacherId = Console.ReadLine();

            if (GetByTeacherId == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add don't empty Teacher Id:");
                goto ById;
            }
            else if (Regex.IsMatch(GetByTeacherId, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add Number");
                goto ById;
            }

            int teacherId;

            bool IsCorrectTeacherId=int.TryParse(GetByTeacherId, out teacherId);
            if (IsCorrectTeacherId)
            {
                try
                {
                    var result = _groupServices.GetGroupByTeacherId(teacherId);
                    foreach (var item in result)
                    {
                        ConsoleColor.Green.WriteConsole(
                       $"Id: {item.Id}, Name: {item.Name}, Capacity: {item.Capacity}," +
                       $" Teacher Name : {item.Teacher.Name} Create date: {item.Ceratdate.ToString("dd,MM,yyyy")} ");
                    }


                }
                catch (Exception ex )
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Retype the word you're looking for");
                    goto ById;
                }

            }
            else
            {
                

            }
        } //elsini duzelt ---- obsi methodlarda else lere bax!!!

        public void GetGroupCount()
        {
            var result= _groupServices.GetGroupCount();
            ConsoleColor.DarkCyan.WriteConsole($"All Group Count: {result}");

        }


        public void GetGroupUptade()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
        ById: string GetByTeacherId = Console.ReadLine();

            int id;
            bool isIdTrue=int.TryParse(GetByTeacherId, out id);
            if (isIdTrue)
            {
              ConsoleColor.DarkCyan.WriteConsole("Please Add new Group Name:");
                GroupName: string groupNewName = Console.ReadLine();
                if (groupNewName == string.Empty)
                {
                    ConsoleColor.Red.WriteConsole("Please add dont empty Group name:");
                    goto GroupName;
                }
                
                ConsoleColor.DarkCyan.WriteConsole("Please Add new Group Capacity:");
            GroupCapacity: string groupNewCapacity = Console.ReadLine();

                int capacity;
                bool isCapacityTrue=int.TryParse (groupNewCapacity, out capacity);
                if (groupNewCapacity == string.Empty)
                {
                    ConsoleColor.Red.WriteConsole("Please add dont empty Group name:");
                    goto GroupCapacity;
                }

                Group group = new Group()
                {
                    Name = groupNewName,
                    Capacity = capacity,
                };

                Group newGroup= _groupServices.Update(id, group);
                if (newGroup!=null)
                {
                    ConsoleColor.Green.WriteConsole(
                       $"Id: {newGroup.Id}, Name: {newGroup.Name}, Capacity: {newGroup.Capacity}," +
                       $" Teacher Name : {newGroup.Teacher.Name} Create date: {newGroup.Ceratdate.ToString("dd,MM,yyyy")} ");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Group was not found.Try again:");
                }
            }
        }

        public bool GetContains(string text)
        {
            if (Regex.IsMatch(text,@"[^A-Za-z"))
            {
                return true;
            }
            return false;
        }




    }


}

 
