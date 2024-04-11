namespace EmpDataLayer
{
    //Model Classes / POCO Classes / Contract Classes : These are used to share the data with in the application.
    public class Employee
    {
        public int Eno { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string DeptName { get; set; }
    }
}
