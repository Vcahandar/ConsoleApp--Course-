

using CourseApp.Controllers;
using ServiceLayer.Helpers;

TeacherController teacher=new TeacherController();

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
            case 1:
                teacher.Create();
                break;
            case 2: 
                teacher.GetAll();
                break;
            case 3: Console.WriteLine("Delete");
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
    ConsoleColor.Cyan.WriteConsole("Teacher Options: 1 - Create, 2 - Get All, 3 - Delete");
}
