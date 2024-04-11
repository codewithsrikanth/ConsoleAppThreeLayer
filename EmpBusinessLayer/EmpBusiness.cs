using EmpDataLayer;

namespace EmpBusinessLayer
{
    public class EmpBusiness
    {
        CompanyDBDataContext context = new CompanyDBDataContext();
        public List<Employee> GetEmployees()
        {
            return context.GetEmployees();
        }
        public Employee GetEmployee(int id)
        {
            return context.GetEmployee(id);
        }
        public int InsertEmp(Employee emp)
        {
            return context.InsertEmp(emp);
        }
        public int DeleteEmp(int eno)
        {
            return context.DeleteEmp(eno);
        }
    }
}
