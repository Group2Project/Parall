using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

[Serializable()]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class mStruct
{
    private String methodName;
    private List<object> arguments;
    private LinkedList<object> par;
    private object result;
    public mStruct(string mtN, List<object> arg)
    {
        methodName = mtN;
        arguments = arg;
    }
    public String getMethodName()
    {
        return methodName;
    }
    public dynamic getArg(int pos)
    {
        return arguments[pos];
    }
}
