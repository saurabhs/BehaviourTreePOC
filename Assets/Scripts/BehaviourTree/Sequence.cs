namespace BehaviourTreePOC
{
    public class Sequence : Node
    {
        public Sequence( IBehaviour parent ) : base( parent )
        {
        }

        public override bool Run()
        {
            foreach ( var task in _actions )
            {
                if ( !task.Run() )
                {
                    return false;
                }
            }

            return false;
        }
    }
}