using System;
using System.Collections.Generic;
using System.Text;
using MISA.BTL.Common;

namespace MISA.BTL.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        ServiceResult Insert(Employee employee);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployeeById(string id);
        IEnumerable<Employee> GetEmployeeByCode(string code);
        ServiceResult Update(Employee employee);
        ServiceResult Delete(Employee employee);
    }
}
