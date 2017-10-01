namespace BehaviourTreePOC
{
    public abstract class Node : IBehaviour
    {
        protected System.Collections.Generic.List<IBehaviour> _behaviour = null;
        protected IBehaviour _parent = null;
        protected IBehaviour _currentNode = null;

        public IBehaviour Parent { get { return _parent; } }

        public Node( IBehaviour parent )
        {
            _parent = parent;
        }

        ~Node()
        {
            if ( _behaviour != null )
            {
                _behaviour.Clear();
                _behaviour = null;
            }

            _parent = null;
        }

        public virtual void SetParent( IBehaviour parent )
        {
            _parent = parent;
        }

        public virtual void AddAction( IBehaviour task )
        {
            if ( _behaviour == null )
                _behaviour = new System.Collections.Generic.List<IBehaviour>();

            if ( _behaviour.Contains( task ) )
                return;

            _behaviour.Add( task );
        }

        public virtual void RemoveAction( IBehaviour task )
        {
            if ( _behaviour == null )
                return;

            _behaviour.Remove( task );
        }

        public abstract bool Run();
    }
}