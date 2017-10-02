using System.Collections.Generic;

namespace BehaviourTreePOC
{
    public class Root : IBehaviour
    {
        protected List<Node> _nodes = null;
        protected Node _currentNode = null;
        protected int _index = 0;

        protected Node CurrentNode { get { return _currentNode; } set { _currentNode = value; } }

        public Root()
        {
            _nodes = new List<Node>();
        }

        ~Root()
        {
            if ( _nodes != null )
            {
                _nodes.Clear();
                _nodes = null;
            }

            _currentNode = null;
        }

        public void Setup()
        {
            _currentNode = _nodes?[0] ?? null;
        }

        public void AddNode( Node node )
        {
            if ( !_nodes.Contains( node ) )
            {
                _nodes.Add( node );
            }
        }

        public void RemoveNode( Node node )
        {
            _nodes.Remove( node );
        }

        public bool Run()
        {
            if ( !_currentNode.Run() )
            {
                if ( ++_index >= _nodes.Count )
                    _index = 0;

                _currentNode = _nodes[_index];
            }

            return true;
        }
    }
}