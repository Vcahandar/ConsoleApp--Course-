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

namespace CourseApp.Controllers
{
    public class TeacherController
    {
        private readonly ITeacherService _teacherService;

        public TeacherController()
        {
            _teacherService = new TeacherService();
        }
        public void Create()
        {
            string pettern = "^(?!\\s+$)[a-zA-Z]+$";


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher name:");
        TeacherName: string teacherName = Console.ReadLine();

            if (teacherName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher name:");
                goto TeacherName;
            }
            else if (!Regex.IsMatch(teacherName, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter ");
                goto TeacherName;

            }


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher surname:");
        TeacherSurname: string teacherSurname = Console.ReadLine();

            if (teacherSurname == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher surname:");
                goto TeacherSurname;
            }
            else if (!Regex.IsMatch(teacherSurname, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter");
                goto TeacherSurname;

            }


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher address:");
        TeacherAddress: string teacherAddress = Console.ReadLine();

            if (teacherAddress == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher address:");
                goto TeacherAddress;
            }


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher age:");
        TeacherAge: string teacherAgeStr = Console.ReadLine();

            if (teacherAgeStr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher age:");
                goto TeacherAge;
            }


            int teachAge;

            bool isTeacherAge = int.TryParse(teacherAgeStr, out teachAge);

            if (isTeacherAge)
            {

                try
                {
                    Teacher teacher = new Teacher
                    {
                        Name = teacherName,
                        Surname = teacherSurname,
                        Age = teachAge,
                        Address = teacherAddress,
                    };

                    var response = _teacherService.Create(teacher);
                    ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Surname: {response.Surname}, Age:{response.Age}, Address:{response.Address}");

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Teacher name again:");

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("You cannot register correctly, please register again.");
                goto TeacherName;
            }


        }

        public void GetAll()
        {
            var result = _teacherService.GetAll();

            if (result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data Not Found!");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age:{item.Age}, Address:{item.Address}");

                }
            }
        }

        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id for delete:");
        TeacherId: string teacherId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(teacherId, out id);

            if (isCorrectId)
            {
                try
                {
                    _teacherService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully delete");
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher Id again");
                    goto TeacherId;
                }



            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format teacher Id");
                goto TeacherId;

            }
        }

        public void Search()
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
                var result = _teacherService.Search(searchText);

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age:{item.Age}, Address:{item.Address}");
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher Id again");
                goto SearchText;
            }

        }

        public void GetById()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
        ById: string GetById = Console.ReadLine();

            if (GetById == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher age:");
                goto ById;
            }

            int byIdNum;

            bool isByIdnNum = int.TryParse(GetById, out byIdNum);
            if (isByIdnNum)
            {

                try
                {
                    Teacher teacher = new Teacher
                    {
                        Id = byIdNum,
                    };

                    var result = _teacherService.GetById(byIdNum);
                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age:{result.Age}, Address:{result.Address}");


                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Teacher name again:");
                }
            }



        }

        public void Update()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
            EnterId: string teacherId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(teacherId, out id);

            string pettern = "^(?!\\s+$)[a-zA-Z]+$";

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Name:");
        TeacherName: string newName = Console.ReadLine();
            
            if (newName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher name:");
                goto TeacherName;
            }
            else if (!Regex.IsMatch(newName, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter ");
                goto TeacherName;

            }

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Surname:");
        TeacherSurname: string newSurname = Console.ReadLine();

            if (newSurname == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher name:");
                goto TeacherSurname;
            }
            else if (!Regex.IsMatch(newSurname, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter ");
                goto TeacherSurname;
            }


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Address:");
        TeacherAddress: string newAddress = Console.ReadLine();

            if (newAddress == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher Address:");
                goto TeacherSurname;
            }
            else if (!Regex.IsMatch(newAddress, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter ");
                goto TeacherAddress;
            }


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Age:");
            TeacherAge: string newAge = Console.ReadLine();
            if (newAge == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher Age:");
                goto TeacherAge;
            }
            else if (!Regex.IsMatch(newAddress, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add letter ");
                goto TeacherAge;
            }
            int age;
            bool isAgeTrue = int.TryParse(newAge, out age);

            if (isIdTrue)
            {
                try
                {
                    Teacher teacher = new Teacher
                    {
                        Name = newName,
                        Surname = newSurname,
                        Address = newAddress,
                        Age = age

                    };

                    Teacher newTeacher = new();
                   newTeacher = _teacherService.Update(id, teacher);
                    ConsoleColor.Red.WriteConsole("Succesfully updated");

                   
                   
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Teacher was not found. Try again:");

            }




        }


    }
}







   
