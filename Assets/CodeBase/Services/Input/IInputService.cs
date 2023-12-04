using System;

namespace CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        Action<bool> Hit { get; set; }
        void Cleanup();
    }
}