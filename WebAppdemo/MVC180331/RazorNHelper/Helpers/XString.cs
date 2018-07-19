using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class XString
{
    public static String Truncate(String input, int maxlength)
    {
        if (input.Length < maxlength)
        {
            return input;
        }
        var substr = input.Substring(0, maxlength) + "...";
        return substr;
    }
}