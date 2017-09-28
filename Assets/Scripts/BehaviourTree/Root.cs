using System.Collections.Generic;

namespace BehaviourTreePOC
{
    public class Root : IBehaviour
    {
        public List<Node> nodes = null;
        public Node currentNode = null;

        public Root()
        {
        }

        ~Root()
        {
        }

        public void Setup()
        {
            currentNode = nodes?[0] ?? null;
        }

        public void UpdateCurrentNode( Node node )
        {
            currentNode = node;
        }

        public void AddNode( Node node )
        {
            if ( nodes == null )
                nodes = new List<Node>();

            if ( nodes.Contains( node ) )
                return;

            nodes.Add( node );
        }

        public void RemoveNode( Node node )
        {
            if ( nodes == null )
                return;

            nodes.Remove( node );
        }

        public void Run()
        {
            currentNode?.Run();

            //int index = 0;
            //while ( index < nodes.Count )
            //{
            //    nodes[index].Run();
            //}
        }
    }
}