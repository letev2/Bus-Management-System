﻿using BusManagementSystem.Context;
using BusManagementSystem.DTOS;
using BusManagementSystem.Entities;
using BusManagementSystem.Enums;
using BusManagementSystem.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagementSystem.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDbContext _context;

        public TripRepository()
        {
            _context = new ApplicationDbContext();
        }
        public Trip Create(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
            return trip;
        }

        public void Delete(Trip trip)
        {
            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
           return _context.Trips.Any(x => x.Id == id);
        }

        public Trip Get(int id)
        {
            var trip = _context.Trips.Find(id);
            return trip;
        }

        public List<Trip> GetAll()
        {
            return _context.Trips.ToList();
        }

        public Trip GetByReference(string reference)
        {
            return _context.Trips.SingleOrDefault(x => x.TripReference == reference);
        }

        public List<TripDto> GetTripsByDateAndLocation(Location from, Location to, DateTime date)
        {
            return _context.Trips.Include(t => t.Bus).Include(t=>t.Driver).Where(s => s.TakeOffPoint == from && s.LandingPoint == to && s.TakeOffTime.Date == date).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReference = trip.TripReference,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.Status,
                Price = trip.Price,
            }).ToList();
        }

        public List<TripDto> GetTripsByDriver(int driverId)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Driver).Where(x => x.DriverId == driverId).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReference = trip.TripReference,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.Status,
                Price = trip.Price,
            }).ToList();
        }

        public Trip Update(Trip trip)
        {
            _context.Trips.Update(trip);
            _context.SaveChanges();
            return trip;
        }

        public List<TripDto> GetInitialisedTrips()
        {
           return _context.Trips.Include(t => t.Bus).Include(t => t.Driver).Where(x => x.Status == TripStatus.Initialize).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
               AvailableSeat = trip.AvailableSeat,
               LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReference = trip.TripReference,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.Status,
                Price = trip.Price,
            }).ToList();
            

        }
        public List<TripDto> GetTripsByBus(string registrationNumber)
        {
            var trips = _context.Trips.Include(r => r.Bus).Include(r => r.Driver).Where(r => r.Bus.RegistrationNumber == registrationNumber).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReference = trip.TripReference,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.Status,
                Price = trip.Price,
            }).ToList();
            return trips;

        }

        public List<TripDto> GetTripsByDate(DateTime date)
        {
            var trips = _context.Trips.Include(t => t.Bus).Include(t => t.Driver).Where(r => r.TakeOffTime.Date == date).Select(trip => new TripDto

            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReference = trip.TripReference,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.Status,
                Price = trip.Price,
            }).ToList();
            return trips;
        }

        public List<TripDto> GetCompletedTrips()
        {
            //return _context.Trips.
            throw new NotImplementedException();
        }

        public List<TripDto> GetAvailableTrips(Location from, Location to, DateTime date)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Driver).Where(s => s.TakeOffPoint == from && s.LandingPoint == to && s.TakeOffTime.Date == date && s.AvailableSeat > 0).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReference = trip.TripReference,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.Status,
                Price = trip.Price,
            }).ToList();
        }
    }
}
