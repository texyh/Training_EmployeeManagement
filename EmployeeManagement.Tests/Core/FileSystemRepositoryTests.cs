﻿using EmployeeManagement.Core.Models;
using EmployeeManagement.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Linq;
using static EmployeeManagement.Tests.Constants;
using EmployeeManagement.Core.Data.FileSystem;

namespace EmployeeManagement.Tests
{
    [TestClass]
    public class FileSystemRepositoryTests
    {
        private readonly static string _filepath = ConfigurationManager.AppSettings["EmployeeFilePath"];

        [TestInitialize]
        public void InitTest()
        {
            var employees = Data.EmployeeEntities;

            File.WriteAllText(_filepath, JsonConvert.SerializeObject(employees, Formatting.Indented));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.WriteAllText(_filepath, string.Empty);
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Create_FileSystemRepository_Instance()
        {
            var repo = new FileSystemEmployeeRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Save_Employee()
        {
            var repo = new FileSystemEmployeeRepository();
            var employee = new EmployeeEntity();

            employee.Firstname = "Ngozi";
            employee.Lastname = "Adekola";
            employee.Salary = 100000;
            employee.SkillLevel = 5;
            employee.JobTitle = JobTitle.SoftwareDeveloper;
            employee.Gender = Gender.Female;

            repo.Create(employee);
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Read_All_Employees()
        {
            var repo = new FileSystemEmployeeRepository();
            var employees = repo.GetAllEmployees();

            Assert.AreEqual(2, employees.Count);
            Assert.AreEqual(Data.User1Id, employees.First().Id);
            Assert.AreEqual(Data.User2Id, employees[1].Id);
        }
    }
}
