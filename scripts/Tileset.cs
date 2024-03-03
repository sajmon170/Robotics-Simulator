using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Tileset : IEnumerable<TileType> {
    private Dictionary<int, TileType> tiles;
    private static Random random = new();
    
    // This should be called Add()
    public void Register(int id, TileType tile) {
        tiles.Add(id, tile);
    }

    public TileType Get(int id) {
        return tiles[id];
    }

    public List<TileType> GetAll() {    
        return tiles.Values.ToList();
    }

    // This needs to be tested
    public TileType GetRandomType() {
        return tiles.ElementAt(random.Next(0, tiles.Count)).Value;
    }

    public Tile MakeRandomTile() {
        return new Tile(GetRandomType(), Utility.RandomChoice<Direction>());
    }

    public IEnumerator<TileType> GetEnumerator() {
        return tiles.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return tiles.Values.GetEnumerator();
    }
}
