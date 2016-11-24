﻿using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Core.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeEntity GetEmployee(Guid id);

        List<EmployeeEntity> GetAllEmployees();

        void Create(EmployeeEntity employeeEntity);

        void Update(EmployeeEntity employeeEntity);
    }
}