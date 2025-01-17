﻿using EmployeeManagement.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.ExtensionMethod
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData( this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee()
                {
                    Id = 1,
                    Name = "Mary",
                    Email = "Mary@Email.com",
                    Department = Dept.IT,
                    Address = "street no.1"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "John",
                    Email = "John@Email.com",
                    Department = Dept.Developer,
                    Address = "street no.2"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Mark",
                    Email = "Mark@Email.com",
                    Department = Dept.Developer,
                    Address = "street no.3"
                });
               
        }
    }
}
