using System;
using System.Collections.Generic;
using System.Text;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;
using MISA.BTL.Database;
using MISA.BTL.Database.Interfaces;

namespace MISA.BTL.Business
{
    public class EmployeeBusiness:IEmployeeBusiness
    {
        IEmployeeDatabase _employeeDatabase;
        public EmployeeBusiness(IEmployeeDatabase employeeDatabase)
        {
            _employeeDatabase = employeeDatabase;
        }

        public ServiceResult Delete(Employee employee)
        {
            return new ServiceResult()
            {
                Data = _employeeDatabase.Delete(employee),
                Messenger = "Xóa nhân viên thành công",
                MISACode = MISAEnum.Success,
            };
        }

        public IEnumerable<Employee> GetEmployeeByCode(string code)
        {
            return _employeeDatabase.GetEmployeeByCode(code);
        }

        public IEnumerable<Employee> GetEmployeeById(string id)
        {
            return _employeeDatabase.GetEmployeeById(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDatabase.GetEmployees();
        }

        public ServiceResult Insert(Employee employee)
        {
            // 1. check trùng mã: 
            if (_employeeDatabase.CheckDuplicateEmployeeCode(employee.EmployeeCode) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Duplicate_Code,
                    MISACode = MISAEnum.BadRequest,
                };
            } 
            if (_employeeDatabase.CheckDuplicatePhoneNumber(employee.PhoneNumber) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Duplicate_PhoneNumber,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckDuplicateIdentityNumber(employee.IdentityNumber) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Duplicate_IdentityNumber,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyEmployeeCode(employee.EmployeeCode) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Error_Required_Code,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyFullName(employee.FullName) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_FullName,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyPhoneNumber(employee.PhoneNumber) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_PhoneNumber,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyEmail(employee.Email) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_Email,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyIdentityNumber(employee.IdentityNumber) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_IdentityNumber,
                    MISACode = MISAEnum.BadRequest
                };
            }
            return new ServiceResult()
            {
                Data = _employeeDatabase.Insert(employee),
                Messenger = Properties.Resources.Msg_Add_Success,
                MISACode = MISAEnum.Success
            };
        }

        public ServiceResult Update(Employee employee)
        {
            if (_employeeDatabase.CheckEmptyEmployeeCode(employee.EmployeeCode) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Error_Required_Code,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyFullName(employee.FullName) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_FullName,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyPhoneNumber(employee.PhoneNumber) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_PhoneNumber,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyEmail(employee.Email) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_Email,
                    MISACode = MISAEnum.BadRequest
                };
            }
            if (_employeeDatabase.CheckEmptyIdentityNumber(employee.IdentityNumber) == true)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Erro_Required_IdentityNumber,
                    MISACode = MISAEnum.BadRequest
                };
            }
            return new ServiceResult()
            {
                Data = _employeeDatabase.Update(employee),
                Messenger = Properties.Resources.Msg_Update_Success,
                MISACode = MISAEnum.Success,
            };
        }
    }
}
