using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagment.Service.Delegates
{
    public class WorkingWithDelegates
    {
        Func<int, int, int> Multiply;
        Func<int, int, int> Devide;
        Func<int, int, int> Sum;
        Func<int, int, int> Minus;
        Func<int, int, int> FindProcent;
       


    }

    public static int Multiply(int a, int b)
    {
        var res = a * b;
        return res;
    }

    public static int Devide(int a, int b, int c)
    {
        var res = a / b;
        return res;
    }

    public static int Sum(int a, int b)
    {
        var res = a + b;
        return res;
    }

    public static int Minus(int a, int b)
    {
        var res = int.Abs(a - b);
        return res;
    }

    public static int FindProcent(int total, int TargetProcent)
    {
        var res = total / 100 * TargetProcent;
        return res;
    }
}
