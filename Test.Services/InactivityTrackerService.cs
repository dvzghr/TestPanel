using System;
using Test.Services.Interface;

namespace Test.Services
{
    public class InactivityTrackerService : IInactivityTrackerService
    {
        public event EventHandler Timeout;
        public bool IsActive { get; }
        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
