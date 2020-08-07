using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AForum.Helpers
{
    public interface IPostFormatter
    {
        public string Prettify(string postContent);
    }
}
