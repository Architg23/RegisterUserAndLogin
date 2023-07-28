using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserandLogin.Models;

namespace RegisterUserAndLogin.Models
{
    public class DataContext :DbContext
    {
       public DbSet<User> Users { get; set; }
    }
}