﻿using EntityLayer.Concrete;
using EntityLayer.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework;

public class Context:DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get;set; }

    public  DbSet<Order> Orders { get; set; }



}