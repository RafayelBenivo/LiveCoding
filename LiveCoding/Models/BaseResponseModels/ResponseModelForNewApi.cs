using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding.Models.BaseResponseModels
{
    public class ResponseModelForNewApi<T> : NewApiBaseResponseModel
    {
        public T? Data { get; set; }
    }
}
