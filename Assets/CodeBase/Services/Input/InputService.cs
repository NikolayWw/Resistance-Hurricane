using System;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        public Action<bool> Hit { get; set; }

        private readonly MainControls _controlsAction;

        public InputService()
        {
            _controlsAction = new MainControls();
            _controlsAction.Player.Enable();

            _controlsAction.Player.LeftHit.performed += _ => Hit?.Invoke(false);
            _controlsAction.Player.RightHit.performed += _ => Hit?.Invoke(true);
        }
        public void Cleanup()
        {
            Hit = null;
        }
    }
}