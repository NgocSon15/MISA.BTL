using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BTL.Common
{
    public class ServiceResult
    {
        public object Data { get; set; }
        public string Messenger { get; set; }
        /// <summary>
        /// Mã kết quả
        /// </summary>
        public MISAEnum MISACode { get; set; }
    }
}
