using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding.Models.BaseResponseModels
{
    public class NewApiBaseResponseModel
    {
        public int Code { get; set; }
        public bool HasError { get; set; }
        public ResponseMessage Message { get; set; }
    }
}
