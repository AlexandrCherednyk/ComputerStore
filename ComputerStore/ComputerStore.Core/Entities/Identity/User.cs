﻿namespace ComputerStore.Core.Identity.Entities;
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
}
