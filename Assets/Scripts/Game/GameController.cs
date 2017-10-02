using UnityEngine;
using BehaviourTreePOC;

public class GameController : MonoBehaviour
{
    public Root root = null;
    public System.Collections.Generic.List<bool> results = new System.Collections.Generic.List<bool>();

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
        seq.Setup();

        var sel = new Selector( root );
        sel.AddAction( new Task( Task4 ) );
        sel.AddAction( new Task( Task5 ) );
        seq.Setup();

        root.AddNode( seq );
        root.AddNode( sel );
        root.Setup();
    }

    private void Setup2()
    {
        root = new Root();

        var rootSelector = new Selector( root );

        var seq = new Sequence( rootSelector );
        seq.AddAction( new Task( Task1 ) );
        seq.AddAction( new Task( Task2 ) );
        seq.AddAction( new Task( Task3 ) );

        var sel = new Sequence( rootSelector );
        sel.AddAction( new Task( Task4 ) );
        sel.AddAction( new Task( Task5 ) );

        rootSelector.AddAction( seq );
        rootSelector.AddAction( sel );

        root.AddNode( rootSelector );
        root.Setup();
    }

    void Update()
    {
        root.Run();
    }

    private bool Task1()
    {
        print( "task 1" );
        return results[0];
    }

    private bool Task2()
    {
        print( "task 2" );
        return results[1];
    }

    private bool Task3()
    {
        print( "task 3" );
        return results[2];
    }

    private bool Task4()
    {
        print( "task 4" );
        return results[3];
    }

    private bool Task5()
    {
        print( "task 5" );
        return results[4];
    }
}