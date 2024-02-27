using System;

public class TileType {
    public ConnectionsConstraint Connectors { get; }
    public int Id { get; }
    
    TileType(ConnectionsConstraint connectors, int id) {
        this.Connectors = connectors;
        this.Id = id;
    }
}
