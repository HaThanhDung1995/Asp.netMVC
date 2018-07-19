using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public static class XString
{
    public static String ToBase64(this String s)
    {
        var data = Encoding.UTF8.GetBytes(s);
        var encode = Convert.ToBase64String(data);
        return encode;
    }

    public static String FromBase64(this String s)
    {
        var encode = Convert.FromBase64String(s);
        var decode = Encoding.UTF8.GetString(encode);
        return decode;
    }

    public static String ToMd5(this String s)
    {
        var data = Encoding.UTF8.GetBytes(s);
        var data2 = MD5.Create().ComputeHash(data);
        var encode = Convert.ToBase64String(data2);
        return encode;
    }
}