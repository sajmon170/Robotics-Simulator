using System;

public class TileType {
    private ConnectionsConstraint connectors;
    private int id { get; }
    
    Tile(ConnectionsConstraint connectors, int id) {
        this.connectors = connectors;
        this.id = id;
    }
};
