using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        bool IRepositoryBase<LeaveAllocation>.Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        bool IRepositoryBase<LeaveAllocation>.Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        ICollection<LeaveAllocation> IRepositoryBase<LeaveAllocation>.FindAll()
        {

            var leaveAllocations = _db.LeaveAllocations.ToList();
            return leaveAllocations;
        }

        LeaveAllocation IRepositoryBase<LeaveAllocation>.FindById(int Id)
        {
            var leaveAllocations = _db.LeaveAllocations.Find(Id);
            return leaveAllocations;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        bool IRepositoryBase<LeaveAllocation>.Update(LeaveAllocation entity)
        {

            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
