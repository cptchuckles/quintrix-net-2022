using System;
using Microsoft.AspNetCore.Identity;

namespace QuintrixMVC.Models;

public class User : IdentityUser
{
    public uint CashMoney { get; set; }
}
