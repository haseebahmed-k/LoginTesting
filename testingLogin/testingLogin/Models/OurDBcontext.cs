using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace testingLogin.Models
{
    public class OurDBcontext : DbContext

    {

        public DbSet<UserAccount> userAccount { get; set; }
    }
}