using System;
using System.Collections.Generic;

// czy robić Vector3::MakeRandom() lub Utility::MakeRandom()?
// dodać tileRegistry
//       - getTileType(int id)
//       - getRandom()
//       - getMatching(int connector) -> List<TileType>
//         ^^^ Dictionary<Connector, List<TileType>>;
// styl: dodać consty

class WaveFunctionCollapse : IGenerator {
    private static Random random = new();
    private Vector3 minBound = new();
    private Vector3 maxBound = new();
    private Tileset tileset;
    private Dictionary<Vector3, List<Tile>> domain = new();

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

    private void initializeDomain() {
        // var rotations = GenerateRotations();

        // Implementation using the waterfall design pattern:
        // All rights reserved.
        // for (x: x_axis)
        //     for (y: y_axis)
        //         for (z: z_axis)
        //             for (tileType: tileset)
        //                 for (direction: directions)
        //                     domain.At(new Vector3() {X = x, Y = y, Z = z})
        //                           .Add(new Tile(tileType, direction));

        // Optimized: 
        // List<Tile> rotatedTiles = tileset.RotateAll();
        // for (tile: world)
        //     domain.At(new Vector3() {X = x, Y = y, Z = z})
        //           .Append(rotatedTiles); // WARNING: This appends references,
        //                                              not new objects!
    }
    
    public void generate(World world) {
        World copy = new(world);
        initializeDomain();
        generateBounds();
        setInitialTiles(copy, 3);
        
        // List<Vector3> minEntropy;

        // 0. Wylosować kilka początkowych kafelków (opcjonalne)
        // 1. Pozyskać tile o najmniejszej entropii
        // 2. Wybrać tile i nadać mu wartość
        // 3. Propagować

        world = copy;
    }
    
}
