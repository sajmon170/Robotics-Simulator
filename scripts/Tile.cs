using System;
using System.Collections.Generic;

using Connector = int;

public class Tile {
    public TileType Type { get; }
    private Direction frontDirection { get; set; }
    private static Face[,] rot = {
        // North
        {Face.Up, Face.Down, Face.Front, Face.Right, Face.Back, Face.Left}, 
        // East
        {Face.Up, Face.Down, Face.Left, Face.Front, Face.Right, Face.Back},
        // South
        {Face.Up, Face.Down, Face.Back, Face.Left, Face.Front, Face.Right},
        // West
        {Face.Up, Face.Down, Face.Right, Face.Back, Face.Left, Face.Front}
    };

    public Tile(TileType type, Direction frontDirection = Direction.North) {
        this.Type = type;
        this.frontDirection = frontDirection;
    }

    public Tile(Tile tile) {
        this.Type = tile.Type;
        this.frontDirection = tile.frontDirection;
    }

    public List<Connector> Get(Face face) {
        return Type.Connectors.Get(rot[(int)frontDirection, (int)face]);
    }
}
