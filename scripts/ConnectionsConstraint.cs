using System;
using System.Collections.Generic;

using Connector = int;

public class ConnectionsConstraint // : IEnumerable
{
    private const int CubeFaceCount = 6;
    private List<Connector>[] connectors = new List<Connector>[CubeFaceCount]; 
    
    public ConnectionsConstraint(List<Connector> up,
                                 List<Connector> down,
                                 List<Connector> left,
                                 List<Connector> right,
                                 List<Connector> front,
                                 List<Connector> back) {
        
        connectors[(int)Face.Up]    = up;
        connectors[(int)Face.Down]  = down;
        connectors[(int)Face.Left]  = left;
        connectors[(int)Face.Right] = right;
        connectors[(int)Face.Front] = front;
        connectors[(int)Face.Back]  = back;
    }

    public List<Connector> Get(Face face) {
        return connectors[(int)face];
    }
}
