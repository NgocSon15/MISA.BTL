using System;
using System.Collections.Generic;
using System.Text;
using MISA.BTL.Common;

namespace MISA.BTL.Database.Interfaces
{
    public interface IEmployeeDatabase
    {
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployeeById(string id);
        int Insert(Employee employee);
        IEnumerable<Employee> GetEmployeeByCode(string code);
        bool CheckDuplicateEmployeeCode(string code);
        bool CheckDuplicatePhoneNumber(string phoneNumber);
        bool CheckDuplicateIdentityNumber(string identityNumber);
        bool CheckEmptyEmployeeCode(string fullName);
        bool CheckEmptyFullName(string fullName);
        bool CheckEmptyPhoneNumber(string phoneNumber);
        bool CheckEmptyEmail(string email);
        bool CheckEmptyIdentityNumber(string identityNumber);
        int Update(Employee employee);
        int Delete(Employee employee);

    }
}
