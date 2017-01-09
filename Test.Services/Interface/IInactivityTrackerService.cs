using System;

namespace Test.Services.Interface
{
    public interface IInactivityTrackerService
    {
        event EventHandler Timeout;
        bool IsActive { get; }
        void Restart();
        void Stop();
    }
}
