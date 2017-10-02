using System.Collections.Generic;

namespace BehaviourTreePOC
{
    public abstract class Node : IBehaviour
    {
        protected IBehaviour _parent = null;

        protected List<IBehaviour> _actions = null;
        protected IBehaviour _currentAction = null;

        protected int _index = 0;

        public IBehaviour Parent { get { return _parent; } /*set { _parent = value; }*/ }

        public Node( IBehaviour parent )
        {
            _actions = new List<IBehaviour>();
            _parent = parent;
            _index = 0;
        }

        ~Node()
        {
            if ( _actions != null )
            {
                _actions.Clear();
                _actions = null;
            }

            _currentAction = null;
            _parent = null;
        }

        public abstract bool Run();

        public virtual void AddAction( IBehaviour action )
        {
            if ( !_actions.Contains( action ) )
            {
                _actions.Add( action );
            }
        }

        public virtual void RemoveAction( IBehaviour action )
        {
            if ( _actions != null )
            {
                _actions.Remove( action );
            }
        }

        public virtual void Setup()
        {
            if ( _actions == null || _actions.Count == 0 )
                return;

            _currentAction = _actions[0];
        }
    }
}