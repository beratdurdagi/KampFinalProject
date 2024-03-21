using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class FalseResult : Result
{

    public FalseResult(string message) :base(false,message)
    {
        
    }

    public FalseResult() :base(false) { }
    

}
