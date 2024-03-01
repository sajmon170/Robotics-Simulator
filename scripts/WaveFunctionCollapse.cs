using System;
using System.Collections.Generic;

// czy robić Vector3::MakeRandom() lub Utility::MakeRandom()?
// dodać tileRegistry
//       - getTileType(int id)
//       - getRandom()
//       - getMatching(int connector) -> List<TileType>
//         ^^^ Dictionary<Connector, List<TileType>>;

class WaveFunctionCollapse : IGenerator {
    private Random  random   = new();
    private Vector3 minBound = new();
    private Vector3 maxBound = new();
    private Tileset tileset;

    public WaveFunctionCollapse(Tileset tileset) {
        this.tileset = tileset;
    }

    private void generateBounds() {
        maxBound = Vector3.MakeRandom(5, 20);
        minBound = -maxBound;
    }

    private void setInitialTiles(World world, int number) {
        HashSet<Vector3> usedPositions = new();

        while (usedPositions.Count != number) {
            var pos = Vector3.MakeRandom(minBound, maxBound);

            if (!usedPositions.Add(pos)) {
                continue;
            }

            world.SetTile(pos, tileset.MakeRandomTile());
        }
    }
    
    public void generate(World world) {
        generateBounds();
        setInitialTiles(world, 3);
        
        // List<Vector3> minEntropy;

        // 0. Wylosować kilka początkowych kafelków (opcjonalne)
        // 1. Pozyskać tile o najmniejszej entropii
        // 2. Wybrać tile i nadać mu wartość
        // 3. Propagować
    }
    
}
