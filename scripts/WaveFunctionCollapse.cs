using System;
using System.Collections.Generic;

// czy robić Vector3::MakeRandom() lub Utility::MakeRandom()?
// dodać tileRegistry
//       - getTileType(int id)
//       - getRandom()
//       - getMatching(int connector) -> List<TileType>
//         ^^^ Dictionary<Connector, List<TileType>>;

class WaveFunctionCollapse : IGenerator {
    Random  random   = new();
    Vector3 minBound = new();
    Vector3 maxBound = new();
    Tileset tileset;

    public WaveFunctionCollapse(Tileset tileset) {
        this.tileset = tileset;
    }

    private void generateBounds() {
        minBound = new Vector3() {
            X = random.Next(-20, -5),
            Y = random.Next(-20, -5),
            Z = random.Next(-20, -5)
        };

        maxBound = new Vector3() {
            X = random.Next(5, 20),
            Y = random.Next(5, 20),
            Z = random.Next(5, 20)
        };
    }

    private void setInitialTiles(World world, int number) {
        HashSet<Vector3> usedPositions = new();

        while (usedPositions.Count != number) {
            var pos = new Vector3() {
                random.Next(minBound.X, maxBound.X),
                random.Next(minBound.Y, maxBound.Y),
                random.Next(minBound.Z, maxBound.Z)
            };

            if (!usedPositions.Add(pos)) {
                continue;
            }


            // Version 1
            //world.SetTile(pos, new Tile(tileset.GetRandom()));

            // Version 2
            //
            // world.SetTile(pos, new Tile(Utility.GetRandom(tileset)
            //                             Utility.GetRandom(Direction)));

            // Version 3
            // world.SetTile(pos, Tile.MakeRandom());
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
