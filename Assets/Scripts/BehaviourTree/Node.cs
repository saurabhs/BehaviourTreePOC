using System.Collections.Generic;

namespace BehaviourTreePOC
{
    public abstract class Node : IBehaviour
    {
        public List<Task> _tasks = null;
        public IBehaviour parent = null;

        public Node( IBehaviour parent )
        {
            this.parent = parent;
        }

        ~Node()
        {
            if ( _tasks != null )
            {
                _tasks.Clear();
                _tasks = null;
            }

            parent = null;
        }

        public virtual void SetParent( IBehaviour parent )
        {
            this.parent = parent;
        }

        public virtual void AddAction( Task task )
        {
            if ( _tasks == null )
                _tasks = new List<Task>();

            if ( _tasks.Contains( task ) )
                return;

            _tasks.Add( task );
        }

        public virtual void RemoveAction( Task task )
        {
            if ( _tasks == null )
                return;

            _tasks.Remove( task );
        }

        public abstract void Run();
    }
}