using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        bool IRepositoryBase<LeaveHistory>.Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        bool IRepositoryBase<LeaveHistory>.Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        ICollection<LeaveHistory> IRepositoryBase<LeaveHistory>.FindAll()
        {
            var leaveHistory = _db.LeaveHistories.ToList();
            return leaveHistory;
        }

        LeaveHistory IRepositoryBase<LeaveHistory>.FindById(int Id)
        {
            var leaveHistory = _db.LeaveHistories.Find(Id);
            return leaveHistory;
        }

       public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        bool IRepositoryBase<LeaveHistory>.Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
