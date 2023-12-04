namespace CodeBase.Player.ItemInHandStates
{
    public interface IBasePlayerItemInHandState
    {
        void Exit()
        { }

        void Update()
        { }

        void FixedUpdate()
        { }

        void OnDrawGizmos()
        { }
    }
}