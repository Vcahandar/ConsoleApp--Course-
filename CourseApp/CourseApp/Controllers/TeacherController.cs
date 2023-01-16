using DomainLayer.Models;
using ServiceLayer.Exceptions;
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
            //string pettern1 = "/[\\t\\n ]+/g\r\n";
            string pettern = "^(?!\\s+$)[a-zA-Z]+$";


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher name:");
        TeacherName: string teacherName = Console.ReadLine().Trim();

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
        TeacherSurname: string teacherSurname = Console.ReadLine().Trim();

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
        TeacherAddress: string teacherAddress = Console.ReadLine().Trim();

            if (teacherAddress == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher address:");
                goto TeacherAddress;
            }


            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher age:");
        TeacherAge: string teacherAgeStr = Console.ReadLine().Trim();

            if (teacherAgeStr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add dont empty Teacher age:");
                goto TeacherAge;
            }


         int teachAge;

            bool isTeacherAge = int.TryParse(teacherAgeStr, out teachAge);

            if (isTeacherAge &&teachAge>18&&teachAge<65)
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
                    goto TeacherAge;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("You cannot register correctly, please teacher age again add.");
                goto TeacherAge;
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

                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher name and surname");
                goto SearchText;
            }

        }

        public void GetById()
        {

            string pettern = "^(?!\\s+$)[a-zA-Z]+$";

            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
        ById: string GetById = Console.ReadLine();

            if (GetById == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please add don't empty Teacher Id:");
                goto ById;
            }
            else if (Regex.IsMatch(GetById, pettern))
            {
                ConsoleColor.Red.WriteConsole("Please add Id number ");
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

                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add Teacher Id again:");
                    goto ById;
                }
            }



        }


        public void Update()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id update:");
        ById: string getById = Console.ReadLine();
            int byIdNum;
            bool isCorrectId=int.TryParse(getById, out byIdNum);
            if (!isCorrectId)
            {
                ConsoleColor.Red.WriteConsole("Enter Correct Format Id");
                goto ById;

            }
            else
            {
                try
                {
                    var thereTheacher = _teacherService.GetById(byIdNum);
                    if (thereTheacher == null) throw new NotFoundException("Data not found");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto ById;
                }
                

                ConsoleColor.DarkCyan.WriteConsole("Add a new Teacher Name:");
            TeacherName: string newName = Console.ReadLine();
                if (GetRegex(newName))
                {
                    goto TeacherName;
                }

                ConsoleColor.DarkCyan.WriteConsole("Add a new Teacher Surname:");
            TeacherSurname: string newSurname = Console.ReadLine();
                if(GetRegex(newSurname))
                {
                    goto TeacherSurname;
                }

                ConsoleColor.DarkCyan.WriteConsole("Add a new Teacher Address:");
            AddressName: string newAddressName = Console.ReadLine();
                if(GetRegex(newAddressName))
                {
                    goto AddressName;
                }

                ConsoleColor.DarkCyan.WriteConsole("Add a new Teacher Age:");
            TeacherAge: string ageTeacherStr = Console.ReadLine();

                int ageTeacher;
                int checkAge = 0;
                if(String.IsNullOrEmpty(ageTeacherStr))
                {
                    ageTeacher = checkAge;
                }
                else
                {
                    bool isCorrectAge = int.TryParse(ageTeacherStr, out ageTeacher);
                    if (!isCorrectAge)
                    {
                        ConsoleColor.Red.WriteConsole("Please enter correct format age");
                        goto TeacherAge;
                    }
                }

                try
                {
                    Teacher teacher = new Teacher()
                    {
                        Name = newName,
                        Surname = newSurname,
                        Address= newAddressName,
                        Age = ageTeacher,
                    };
                    Teacher editTeacher = new();
                    editTeacher=_teacherService.Update(byIdNum, teacher);
                    ConsoleColor.White.WriteConsole("Succesfully Updated");

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto ById;

                }


            }
        }


        public bool GetRegex(string regex)
        {
            if (Regex.IsMatch(regex, @"[^A-Za-z]"))
            {
                return true;
            }
            return false;

        }



        #region update

        //public void Update()
        //{
        //    string pettern1 = @"$[\\p{L}\\s]+$";
        //    string pettern = "^[a-zA-Z]+$";

        //    ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Id:");
        //EnterId: string teacherId = Console.ReadLine();
        //    int id;
        //    bool isIdTrue = int.TryParse(teacherId, out id);
        //    if (Regex.IsMatch(teacherId, pettern))
        //    {
        //        ConsoleColor.Red.WriteConsole(" Teacher Error Id:");
        //        goto EnterId;
        //    }

        //    else if (teacherId == string.Empty)
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add don't empty Teacher Id:");
        //        goto EnterId;

        //    }


        //    ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Name:");
        //TeacherName: string newName = Console.ReadLine();

        //    //if (newName == string.Empty)
        //    //{
        //    //    ConsoleColor.Red.WriteConsole("Please add dont empty Teacher name:");
        //    //    goto TeacherName;
        //    //}
        //    /*else */
        //    if (Regex.IsMatch(newName, pettern1))
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add letter ");
        //        goto TeacherName;

        //    }
        //    else if ((Regex.IsMatch(newName, pettern)))
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add letter ");
        //        goto TeacherName;  
        //    }


        //    ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Surname:");
        //TeacherSurname: string newSurname = Console.ReadLine();

        //    if (Regex.IsMatch(newSurname, pettern1))
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add letter ");
        //        goto TeacherSurname;
        //    }


        //    ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Address:");
        //TeacherAddress: string newAddress = Console.ReadLine();

        //    if (Regex.IsMatch(newAddress, pettern1))
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add letter ");
        //        goto TeacherAddress;
        //    }


        //    ConsoleColor.DarkCyan.WriteConsole("Please add Teacher Age:");
        //TeacherAge: string newAge = Console.ReadLine();
        //    if (newAge == string.Empty)
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add dont empty Teacher Age:");
        //        goto TeacherAge;
        //    }
        //    else if (Regex.IsMatch(newAge, pettern))
        //    {
        //        ConsoleColor.Red.WriteConsole("Please add letter ");
        //        goto TeacherAge;
        //    }
        //    int age;
        //    bool isAgeTrue = int.TryParse(newAge, out age);

        //    if (isIdTrue)
        //    {
        //        try
        //        {
        //            Teacher teacher = new Teacher
        //            {
        //                Name = newName,
        //                Surname = newSurname,
        //                Address = newAddress,
        //                Age = age

        //            };

        //            Teacher newTeacher = new();
        //            newTeacher = _teacherService.Update(id, teacher);
        //            ConsoleColor.Green.WriteConsole("Succesfully updated");

        //        }
        //        catch (Exception ex)
        //        {

        //            ConsoleColor.Red.WriteConsole(ex.Message);
        //            goto EnterId;
        //        }
        //    }
        //    else
        //    {
        //        ConsoleColor.Red.WriteConsole("Teacher was not found. Try again:");
        //        goto TeacherSurname;

        //    }
        //}

        #endregion




    }
}
      








   
