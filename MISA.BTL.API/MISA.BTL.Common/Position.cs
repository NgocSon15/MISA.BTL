using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.BTL.Common
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public string Id
        {
            get
            {
                return PositionId.ToString();
            }
        }
        public string PositionName { get; set; }
    }
}
