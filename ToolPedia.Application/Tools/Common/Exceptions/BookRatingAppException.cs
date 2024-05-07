using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolPedia.Application.Common.Exceptions
{
    public class ToolPediaException : Exception
    {
        public ToolPediaException(string message)
            : base(message) { }
    }

    public class ValidationException : ToolPediaException
    {
        public ValidationException(string message)
            : base(message) { }
    }

    public class ToolNotFoundException : ToolPediaException
    {
        public ToolNotFoundException(string message)
            : base(message) { }
    }

    public class QueryLengthException : ToolPediaException
    {
        public QueryLengthException(string message)
            : base(message) { }
    }
}
