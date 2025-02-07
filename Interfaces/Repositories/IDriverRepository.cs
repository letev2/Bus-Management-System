﻿using BusManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagementSystem.Interfaces.Repositories
{
    public interface IDriverRepository
    {
        Driver Create(Driver driver);

        Driver Get(int id);

        List<Driver> GetAll();

        Driver GetByLicenseNumber(string licenseNumber);


        Driver Update(Driver driver);

        void Delete(Driver driver);

        bool ExistById(int id);

        bool ExistByRegNumber(string licenseNumber);
    }
}
