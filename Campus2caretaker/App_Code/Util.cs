using System;
using System.Collections.Generic;
using System.Web;

public static class Util
{
    public static void DisplayMessage(string message)
    {
        if (HttpContext.Current.Session["Messages"] as List<string> == null)
            HttpContext.Current.Session["Messages"] = new List<string>();
        (HttpContext.Current.Session["Messages"] as List<string>).Add(message);
    }
}
