using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MISA.BTL.Common;
using MISA.BTL.Database.Interfaces;

namespace MISA.BTL.Database
{
    public class EmployeeDatabase: DbConnector, IEmployeeDatabase
    {
        DbConnector dbConnector;
        public EmployeeDatabase()
        {
            dbConnector = new DbConnector();
        }
        
        public bool CheckDuplicateEmployeeCode(string code)
        {
            var employee = dbConnection.Query<Employee>($"SELECT * FROM Employee WHERE EmployeeCode = '{code}'");
            if (employee != null)
            {
                foreach (var obj in employee)
                {
                    return true;
                }    
            }
            return false;
        }

        public IEnumerable<Employee> GetEmployeeById(string id)
        {
            return dbConnector.GetDataById<Employee>(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return dbConnector.GetAllData<Employee>();
        }

        public IEnumerable<Employee> GetEmployeeByCode(string code)
        {
            return dbConnector.GetDataByCode<Employee>(code);
        }

        public int Insert(Employee employee)
        {
            var affectRows = dbConnector.Insert<Employee>(employee);
            return affectRows;
        }

        public int Update(Employee employee)
        {
            var affectRows = dbConnector.Update<Employee>(employee);
            return affectRows;
        }

        public int Delete(Employee employee)
        {
            var affectRows = dbConnector.Delete<Employee>(employee);
            return affectRows;
        }

        public bool CheckDuplicatePhoneNumber(string phoneNumber)
        {
            var employee = dbConnection.Query<Employee>($"SELECT * FROM Employee WHERE PhoneNumber = '{phoneNumber}'");
            if (employee != null)
            {
                foreach (var obj in employee)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckDuplicateIdentityNumber(string identityNumber)
        {
            var employee = dbConnection.Query<Employee>($"SELECT * FROM Employee WHERE IdentityNumber = '{identityNumber}'");
            if (employee != null)
            {
                foreach (var obj in employee)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckEmptyFullName(string fullName)
        {
            if (fullName == string.Empty)
            {
                return true;
            }
            return false;
        }

        public bool CheckEmptyPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == string.Empty)
            {
                return true;
            }
            return false;
        }

        public bool CheckEmptyEmail(string email)
        {
            if (email == string.Empty)
            {
                return true;
            }
            return false;
        }

        public bool CheckEmptyIdentityNumber(string identityNumber)
        {
            if (identityNumber == string.Empty)
            {
                return true;
            }
            return false;
        }

        public bool CheckEmptyEmployeeCode(string employeeCode)
        {
            if (employeeCode == string.Empty)
            {
                return true;
            }
            return false;
        }

    }
}
