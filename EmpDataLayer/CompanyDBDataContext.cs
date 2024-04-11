using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmpDataLayer
{
    public class CompanyDBDataContext
    {
        SqlConnection con = null;
        public List<Employee> GetEmployees()
        {
            con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            List<Employee> employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand("select * from Employee", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Eno = Convert.ToInt32(dr["Eno"]);
                    emp.EmpName = Convert.ToString(dr["Ename"]);
                    emp.Job = Convert.ToString(dr["Job"]);
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.DeptName = Convert.ToString(dr["Dname"]);
                    employees.Add(emp);
                }
            }
            con.Close();
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            Employee emp = new Employee();
            SqlCommand cmd = new SqlCommand("select * from Employee where Eno=" + id, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    emp.Eno = Convert.ToInt32(dr["Eno"]);
                    emp.EmpName = Convert.ToString(dr["Ename"]);
                    emp.Job = Convert.ToString(dr["Job"]);
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    emp.DeptName = Convert.ToString(dr["Dname"]);
                }
            }
            con.Close();
            return emp;
        }
        public int InsertEmp(Employee emp)
        {
            con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            SqlCommand cmd = new SqlCommand($"insert into Employee values({emp.Eno},'{emp.EmpName}','{emp.Job}',{emp.Salary},'{emp.DeptName}')",con);
            con.Open();
            int rec = cmd.ExecuteNonQuery();
            con.Close();
            return rec;
        }
        public int DeleteEmp(int eno)
        {
            con = new SqlConnection("server=.;database=CompanyDB;integrated security=true;");
            SqlCommand cmd = new SqlCommand($"delete from Employee where Eno={eno}", con);
            con.Open();
            int rec = cmd.ExecuteNonQuery();
            con.Close();
            return rec;
        }
    }
}
