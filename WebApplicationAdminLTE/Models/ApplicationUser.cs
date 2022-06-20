﻿using Microsoft.AspNetCore.Identity;

namespace WebApplicationAdminLTE.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public byte[] ProfilePicture { get; set; } = new byte[1];
}