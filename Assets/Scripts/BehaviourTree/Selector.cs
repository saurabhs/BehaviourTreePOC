namespace BehaviourTreePOC
{
    public class Selector : Node
    {
        public Selector( IBehaviour parent ) : base( parent )
        {
            _behaviour = new System.Collections.Generic.List<IBehaviour>();
        }

        public override bool Run()
        {
            foreach ( var task in _behaviour )
            {
                if ( task.Run() )
                {
                    return false;
                }
            }

            return true;
        }
    }
}