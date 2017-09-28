namespace BehaviourTreePOC
{
    public class Selector : Node
    {
        //public List<Task> _tasks
        //public IBehaviour parent

        public Selector( IBehaviour parent ) : base( parent )
        {
        }

        public override void Run()
        {
            foreach ( var task in _tasks )
            {
                if ( task._action.Invoke() )
                {
                    break;
                }
            }
        }
    }
}