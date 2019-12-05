using System;

namespace Beryl.Utilities.NodeSelection
{
    public class SelectorException<ParameterType>:Exception
    {
        public readonly ParameterType X;

        public SelectorException(ParameterType x):base("No node found associated to the argument: "+x.ToString())
        {
            X = x;
        }
    }
}
