using System;
using System.Collections.Generic;

using Connector = int;

public class ConnectionsConstraint : IEnumerable
{
    private const int CubeFaceCount = 6;
    private List<Connector>[CubeFaceCount] connectors = new();
    private enum Directions {
        Up,
        Down,
        Left,
        Right,
        Front,
        Back 
    };
    
    public ConnectionsConstraint(List<Connector> up,
                                 List<Connector> down,
                                 List<Connector> left,
                                 List<Connector> right,
                                 List<Connector> front,
                                 List<Connector> back) {
        
        connectors[Directions.Up]    = up;
        connectors[Directions.Down]  = down;
        connectors[Directions.Left]  = left;
        connectors[Directions.Right] = right;
        connectors[Directions.Front] = front;
        connectors[Directions.Back]  = back;
    }

    public List<Connector> GetUp() {
        return connectors[Directions.Up];
    }

    public List<Connector> GetDown() {
        return connectors[Directions.Down];
    }

    public List<Connector> GetLeft() {
        return connectors[Directions.Left];
    }

    public List<Connector> GetRight() {
        return connectors[Directions.Right];
    }

    public List<Connector> GetFront() {
        return connectors[Directions.Front];
    }

    public List<Connector> GetBack() {
        return connectors[Directions.Back];
    }
}
