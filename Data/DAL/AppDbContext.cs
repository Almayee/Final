﻿using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
