﻿using System;
using System.Linq;
using ProjectDriveSafe.Models;

namespace ProjectDriveSafe.Models
{
    public class EFCollisionRepository : ICollisionRepository
    {
        private RDSContext context { get; set; }

        public EFCollisionRepository (RDSContext temp)
        {
            context = temp;
        }

        public IQueryable<Crash> Crashes => context.crashes;

        public Crash GetCrash(int crashid)
        {
            var crash = context.crashes.Single(x => x.CRASH_ID == crashid);
            return crash;
        }

        public void EditCollision(Crash c)
        {
            context.Update(c);
            context.SaveChanges();
        }

        public void SaveCollision(Crash c)
        {
            context.SaveChanges();
        }

        public void CreateCollision(Crash c)
        {
            context.Add(c);
            context.SaveChanges();
        }

        public void DeleteCollision(Crash c)
        {
            context.Remove(c);
            context.SaveChanges();
        }
    }
}
