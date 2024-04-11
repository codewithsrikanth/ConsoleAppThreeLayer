using EmpBusinessLayer;
using EmpDataLayer;

namespace ConsoleAppUI
{
    class Program
    {        
        static void Main(string[] args)
        {
            EmpBusiness obj = new EmpBusiness();
            Console.WriteLine("Employee Data is: ");
            foreach (var emp in obj.GetEmployees())
            {
                Console.WriteLine($"{emp.Eno}   {emp.EmpName}   {emp.Job}   {emp.Salary}    {emp.DeptName}");
            }
            Console.WriteLine();
            Console.WriteLine("Select Database Operation: ");
            Console.WriteLine("1. Get Employee By ID\n2. Insert Employee\n3. Update Employee\n4. Delete Employee");
            int dbOperation =Convert.ToInt16(Console.ReadLine());
            switch (dbOperation)
            {
                case 1:
                    Console.WriteLine("Enter Employee ID: ");
                    int empID = Convert.ToInt16(Console.ReadLine());
                    Employee emp = GetEmployee(empID);
                    Console.WriteLine($"{emp.Eno}   {emp.EmpName}   {emp.Salary}    {emp.Job}   {emp.DeptName}");
                    break;
                case 2:
                    Console.WriteLine("Enter Employee Details: ");
                    Employee newEmp = new Employee();
                    newEmp.Eno = Convert.ToInt16(Console.ReadLine());
                    newEmp.EmpName = Console.ReadLine();
                    newEmp.Job = Console.ReadLine();
                    newEmp.Salary = Convert.ToDouble(Console.ReadLine());
                    newEmp.DeptName = Console.ReadLine();
                    int recAffected = InsertEmp(newEmp);
                    if(recAffected > 0)
                        Console.WriteLine("Record Inserted");
                    else
                        Console.WriteLine("Reconrd Not Inserted");
                    break;
                case 3:
                    //Update - Assignment
                    break;
                case 4:
                    Console.WriteLine("Enter Eno: ");
                    int eno = Convert.ToInt16(Console.ReadLine());
                    int recCount = DeleteEmp(eno);
                    if (recCount > 0)
                        Console.WriteLine("Record Deleted");
                    else
                        Console.WriteLine("Reconrd Not Deleted");
                    break;
                default:
                    break;
            }
            Console.Read();
        }
        static Employee GetEmployee(int empID)
        {
            EmpBusiness obj = new EmpBusiness();
            return obj.GetEmployee(empID);
        }
        static int InsertEmp(Employee emp)
        {
            EmpBusiness obj = new EmpBusiness();
            return obj.InsertEmp(emp);
        }
        static int DeleteEmp(int eno)
        {
            EmpBusiness obj = new EmpBusiness();
            return obj.DeleteEmp(eno);
        }
    }
}
