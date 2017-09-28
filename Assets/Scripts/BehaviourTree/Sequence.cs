namespace BehaviourTreePOC
{
    public class Sequence : Node
    {
        //public List<Task> _tasks
        //public IBehaviour parent

        public Sequence( IBehaviour parent ) : base( parent )
        {
        }

        public override void Run()
        {
            foreach ( var task in _tasks )
            {
                if ( !task._action.Invoke() )
                {
                    break;
                }
            }
        }
    }
}