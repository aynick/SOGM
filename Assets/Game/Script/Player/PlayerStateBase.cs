namespace Script
{
    public abstract class StateBase
    {
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void Enter();
        public abstract void Exit();
    }
}