using System;

namespace MyApp.Db.DbOperations
{
    internal class EmployeeDBEntities : IDisposable
    {
        public object Employee { get; internal set; }
        public int Id { get; internal set; }

        public static implicit operator EmployeeDBEntities(Employee v)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}