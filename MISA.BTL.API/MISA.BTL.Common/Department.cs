using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.BTL.Common
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string Id
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        public string DepartmentName { get; set; }
    }
}
