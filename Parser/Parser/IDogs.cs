using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IElement {}

    abstract class AFields
    {
        public abstract List<IElement> Elements { get; set; }
    }

    abstract class AParse
    {
        public abstract AFields FormatParse(string filepath);
    }
}
