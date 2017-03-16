﻿using GovDelivery.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityBusiness.Data
{
    public class GovDeliveryContext : DbContext
    {
        public GovDeliveryContext():base() { }

        public DbSet<EmailSubscriber> Subscribers { get; set; }

        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
