using UnityEngine;
using BehaviourTreePOC;

public class GameController : MonoBehaviour
{
    public Root root = null;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        root = new Root();

        var seq = new Sequence( root );
        seq.AddAction( new Task( Task1 ) );
        seq.AddAction( new Task( Task2 ) );
        seq.AddAction( new Task( Task3 ) );

        var sel = new Selector( root );
        sel.AddAction( new Task( Task4 ) );
        sel.AddAction( new Task( Task5 ) );

        root.AddNode( seq );
        root.AddNode( sel );

        root.Setup();
    }

    void Update()
    {
        root.Run();
    }

    private bool Task1()
    {
        print( "task 1" );
        return true;
    }

    private bool Task2()
    {
        print( "task 2" );
        return false;
    }

    private bool Task3()
    {
        print( "task 3" );
        return false;
    }

    private bool Task4()
    {
        print( "task 4" );
        return true;
    }

    private bool Task5()
    {
        print( "task 5" );
        return false;
    }
}