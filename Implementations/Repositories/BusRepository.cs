﻿using BusManagementSystem.Context;
using BusManagementSystem.Entities;
using BusManagementSystem.Enums;
using BusManagementSystem.Exceptions;
using BusManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagementSystem.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly ApplicationDbContext _context;

        public BusRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Bus Create(Bus bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
            return bus;
        }


        public void Delete(Bus bus)
        {
            
                _context.Buses.Remove(bus);
                _context.SaveChanges();
            
        }

        public bool ExistById(int id)
        {
            return _context.Buses.Any(b => b.Id == id);
        }

        public bool ExistByRegNumber(string regNum)
        {
            return _context.Buses.Any(b => b.RegistrationNumber == regNum);
        }

        public List<Bus> GetAll()
        {
            return _context.Buses.ToList();
        }

        public List<Bus> GetAvailableBuses()
        {
            return _context.Buses.Where(b => b.AvailabilityStatus == true).ToList();
        }

        public Bus Get(int id)
        {
            var bus = _context.Buses.Find(id);
          
            return bus;
        }

        public Bus GetByRegistrationNumber(string registrationNumber)
        {
            var bus = _context.Buses.SingleOrDefault(x => x.RegistrationNumber == registrationNumber);

            return bus;
        }

        public Bus Update(Bus bus)
        {
            _context.Buses.Update(bus);
            _context.SaveChanges();
            return bus;
        }
    }
}
