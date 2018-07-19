using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Hỗ trợ quản lý session
/// </summary>
public class XSession
{

    /// <summary>
    /// Truy xuất giỏ hàng
    /// </summary>
    public static ShoppingCart Cart
    {
        get
        {
            var Cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
            if (Cart == null)
            {
                Cart = new ShoppingCart();
                HttpContext.Current.Session["Cart"] = Cart;
            }
            return Cart;
        }
    }

    /// <summary>
    /// Truy xuất người dùng đăng nhập
    /// </summary>
    public static Customer User
    {
        get
        {
            return HttpContext.Current.Session["User"] as Customer;
        }
        set
        {
            HttpContext.Current.Session["User"] = value;
        }
    }

    public static void RemoveUser()
    {
        HttpContext.Current.Session.Remove("User");
    }

    public static string ReturnUrl 
    {
        get
        {
            return HttpContext.Current.Session["ReturnUrl"] as String;
        }
        set
        {
            HttpContext.Current.Session["ReturnUrl"] = value;
        }
    }

    /// <summary>
    /// Truy xuất người dùng đăng nhập
    /// </summary>
    public static Master Master
    {
        get
        {
            return HttpContext.Current.Session["Master"] as Master;
        }
        set
        {
            HttpContext.Current.Session["Master"] = value;
        }
    }
}