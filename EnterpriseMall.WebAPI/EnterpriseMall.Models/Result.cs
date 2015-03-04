using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMall.Models
{
    [Serializable]
    public class Result<T> where T : class, new()
    {
        public ResultBase<T> response { set; get; }
    }
}
