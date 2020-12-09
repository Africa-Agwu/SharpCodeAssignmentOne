using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharpCodeAssignmentOne.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCodeAssignmentOne.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StudentInfo> StudentInfo { get; set; }
    }
}
