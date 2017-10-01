namespace BehaviourTreePOC
{
    public class Task : IBehaviour
    {
        protected Constants.Action _action;

        public Task( Constants.Action action )
        {
            _action = action;
        }

        public virtual void SetAction( Constants.Action action )
        {
            _action = action;
        }

        public virtual bool Run()
        {
            return _action();
        }
    }
}