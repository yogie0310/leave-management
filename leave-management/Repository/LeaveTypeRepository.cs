using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ICollection<LeaveType> GetEmployeesByLeaveType(int Id)
        {
            throw new NotImplementedException();
        }

        bool IRepositoryBase<LeaveType>.Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        bool IRepositoryBase<LeaveType>.Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        ICollection<LeaveType> IRepositoryBase<LeaveType>.FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        LeaveType IRepositoryBase<LeaveType>.FindById(int Id)
        {
            var leaveType = _db.LeaveTypes.Find(Id);
            return leaveType;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();

            return changes > 0;
        }

        bool IRepositoryBase<LeaveType>.Update(LeaveType entity) 
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }   

        public bool isExists(int Id)
        {
            var isExists = _db.LeaveTypes.Any(q => q.Id == Id);
            return isExists;
        }
    }
}
