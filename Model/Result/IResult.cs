using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
