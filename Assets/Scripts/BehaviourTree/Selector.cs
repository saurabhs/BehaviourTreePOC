namespace BehaviourTreePOC
{
    public class Selector : Node
    {
        public Selector( IBehaviour parent ) : base( parent )
        {
        }

        public override bool Run()
        {
            foreach ( var task in _actions )
            {
                if ( task.Run() )
                {
                    return false;
                }
            }

            return false;
        }
    }
}