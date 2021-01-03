using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.BTL.Common
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Id { 
            get {
                return EmployeeId.ToString();
            } 
        }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public Guid PositionId { get; set; }
        public string PositionName { get; set; }
        public string IdPosition { 
            get {
                return PositionId.ToString();
            } 
        }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string IdDepartment { 
            get
            {
                return DepartmentId.ToString();
            }
        }
        public string PersonalTaxCode { get; set; }
        public string Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public int WorkStatus { get; set; }
    }
}
