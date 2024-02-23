using System.Collections.Generic;

// TODO:
// Jakie są granice generacji? Gdzie generator ma generować
// i na czym?
// - Zastanowić nad architekturą. Jeżeli OK:
//   - zaimplementować floor map
//   - zaimplementować wall map?
// - zaimplementować class WaveFunctionCollapse : IGenerator

class World {
    private Dictionary<Vector3, TileType> worldMap = new();
    private Dictionary<Vector2, int> floorMap = new();
    private TileType defaultTileType;
    
    public World(TileType defaultTileType) {
        this.defaultTileType = defaultTileType;
    }

    public TileType GetTileType(Vector3 position) {
        return worldMap.GetValueOrDefault(position, defaultTileType);
    }

    public void SetTileType(Vector3 position, TileType tileType) {
        worldMap.Add(position, tileType);
    }
}
