using System;
using System.Collections.Generic;

using Connector = int;

public class ConnectionsConstraint : IEnumerable
{
    private const int CubeFaceCount = 6;
    private List<Connector>[CubeFaceCount] connectors = new(); 
    
    public ConnectionsConstraint(List<Connector> up,
                                 List<Connector> down,
                                 List<Connector> left,
                                 List<Connector> right,
                                 List<Connector> front,
                                 List<Connector> back) {
        
        connectors[Faces.Up]    = up;
        connectors[Faces.Down]  = down;
        connectors[Faces.Left]  = left;
        connectors[Faces.Right] = right;
        connectors[Faces.Front] = front;
        connectors[Faces.Back]  = back;
    }

    public List<Connector> GetUp() {
        return connectors[Faces.Up];
    }

    public List<Connector> GetDown() {
        return connectors[Faces.Down];
    }

    public List<Connector> GetLeft() {
        return connectors[Faces.Left];
    }

    public List<Connector> GetRight() {
        return connectors[Faces.Right];
    }

    public List<Connector> GetFront() {
        return connectors[Faces.Front];
    }

    public List<Connector> GetBack() {
        return connectors[Faces.Back];
    }
}
