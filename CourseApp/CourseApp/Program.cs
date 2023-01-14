﻿

using CourseApp.Controllers;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Enum;

TeacherController teacher=new TeacherController();
GroupsController groups=new GroupsController();

while (true)
{
    GetOptions();

    Option: string option =Console.ReadLine();


    int selectedOption;

    bool isCorrectOption= int.TryParse(option, out selectedOption);

    if (isCorrectOption)
    {
       switch(selectedOption)
        {
            case (int)Options.CreateTeacher:
                teacher.Create();
                break;
            case (int)Options.UptadeTeacher:
                teacher.Update();
                break;
            case (int)Options.DeleteTeacher:
                teacher.Delete();
                break;
            case (int)Options.GetByTeacherById:
                teacher.GetById();
                break;
            case (int)Options.GettAllTeachers:
                teacher.GetAll();
                break;
            case (int)Options.SearchForTeacherNameAndSurname:
                teacher.Search();
                break;
            case (int)Options.CreateGroup:
                groups.Create();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please add correct option");
                goto Option;
        }

    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please add correct format option");
        goto Option;
    }


}

static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option: ");
    ConsoleColor.Cyan.WriteConsole("Teacher Options:\n1 - Create\n2 - Update Teacher\n3 - Delete\n4 - Get teacher by id\n5 - Get all teachers\n6 - Search for teacher name and surname\n7 - Create Groups");
}

