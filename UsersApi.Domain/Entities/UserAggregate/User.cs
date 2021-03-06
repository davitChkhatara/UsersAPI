﻿using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Domain.Interfaces;

namespace UsersApi.Domain.Entities.UserAggregate
{
    public class User : IdentityUser, IAggregateRoot
    {

        public string PersonalId { get; private set; }
        public bool? Married { get; private set; }
        public bool? HasJob { get; private set; }
        public decimal? MonthlySalary { get; private set; }
        public int? AddressId { get; private set; }
        public virtual Address Address { get; private set; }

        private User()
        {

        }

        public User(string userName, string email, string personalId, string phoneNumber, Address address,  bool? married , bool? hasJob, decimal? monthlySalary)
        {
            Guard.Against.NullOrEmpty(personalId, nameof(personalId));
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            if (hasJob.HasValue && hasJob.Value)
            {
                Guard.Against.Null(monthlySalary, nameof(monthlySalary));
                Guard.Against.NegativeOrZero(monthlySalary.Value, nameof(monthlySalary));
            }
            PersonalId = personalId;
            Married = married;
            HasJob = hasJob;
            MonthlySalary = monthlySalary;
            UserName = userName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public void UpdateUserInfo(bool? married, bool? hasJob, decimal? monthlySalary, string phoneNumber)
        {
            Married = married.HasValue ? married.Value : Married;
            HasJob = hasJob.HasValue ? hasJob.Value : HasJob;
            MonthlySalary = (monthlySalary.HasValue && hasJob.HasValue && hasJob.Value) ? monthlySalary.Value : MonthlySalary;
            PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? PhoneNumber : phoneNumber;
        }

        public void UpdateUserAddress(string city, string street, string country)
        {
            if(Address != null)
            {
                Address.UpdateAddress(city, street, country);
            }
            else
            {
                Address = new Address(street, city, street);
            }
        }
    }
}
