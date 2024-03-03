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
    
    // TODO: May be changed to an array
    private Dictionary<Vector3, List<Tile>> domain = new();

    public WaveFunctionCollapse(Tileset tileset) {
        this.tileset = tileset;
    }

    private void GenerateBounds() {
        maxBound = Vector3.MakeRandom(5, 20);
        minBound = -maxBound;
    }

    private void SetTile(World world, Vector3 position, Tile tile) {
        world.SetTile(position, tile);
        domain[position] = new List<Tile>{ tile };
        PropagateConstraints(world, position);
    }

    private void SetRandomTile(World world, Vector3 position) {
        List<Tile> domainAtPosition = domain[position];
        Tile randomTile = domainAtPosition[random.Next(domainAtPosition.Count)];
        SetTile(world, position, randomTile);
    }

    private void SetInitialTiles(World world, int number) {
        HashSet<Vector3> usedPositions = new();

        while (usedPositions.Count != number) {
            var pos = Vector3.MakeRandom(minBound, maxBound);

            if (!usedPositions.Add(pos)) {
                continue;
            }

            SetRandomTile(world, pos);
        }
    }

    private List<Tile> GetRotatedTiles() {
        List<Tile> result = new();
        
        foreach (TileType tt in tileset.GetAll()) {
            foreach (Direction d in Enum.GetValues(typeof(Direction))) {
                result.Add(new Tile(tt, d));
            }
        }

        return result;
    }

    private void InitializeDomain() {
        List<Tile> rotatedTiles = GetRotatedTiles();

        for (int x = minBound.X; x < maxBound.X; ++x) {
            for (int y = minBound.Y; y < maxBound.Y; ++y) {
                for (int z = minBound.Z; z < maxBound.Z; ++z) {
                    domain.Add(new Vector3() { X = x, Y = y, Z = z }, 
                               new List<Tile>(rotatedTiles));
                }
            }
        }
   }

    // min and max are inclusive bounds
   private bool IsInBounds(Vector3 a, Vector3 min, Vector3 max) {
        return a.X >= min.X && a.X <= max.X &&
               a.Y >= min.Y && a.Y <= max.Y &&
               a.Z >= min.Z && a.Z <= max.Z;
   }

   private List<Vector3> GetUnvisitedNeighbours(Vector3 pos, HashSet<Vector3> visited) {
        List<Vector3> possibleNeighbours = new() {
            new Vector3() { X = pos.X - 1, Y = pos.Y,     Z = pos.Z    },
            new Vector3() { X = pos.X,     Y = pos.Y - 1, Z = pos.Z    },
            new Vector3() { X = pos.X,     Y = pos.Y,     Z = pos.Z - 1}, 
            new Vector3() { X = pos.X + 1, Y = pos.Y,     Z = pos.Z    },
            new Vector3() { X = pos.X,     Y = pos.Y + 1, Z = pos.Z    },
            new Vector3() { X = pos.X,     Y = pos.Y,     Z = pos.Z + 1}
        };

        // TODO: Can be refactored using LINQ
        foreach (Vector3 neighbour in possibleNeighbours) {
            if (visited.Contains(neighbour) || !IsInBounds(neighbour, minBound, maxBound)) {
                possibleNeighbours.Remove(neighbour);
            }
        }

        return possibleNeighbours;
   }

    private void PropagateConstraints(World world, Vector3 source) {
        Tile changedTile = world.GetTile(source);
        // TODO: May be changed to an array
        HashSet<Vector3> visited = new();
        Queue<Vector3> toVisit = new();
        toVisit.Enqueue(source);

        // TODO: {...}
    }
    
    public void Generate(World world) {
        World copy = new(world);
        GenerateBounds();
        InitializeDomain();
        SetInitialTiles(copy, 3);
        
        // List<Vector3> minEntropy;

        // 0. Wylosować kilka początkowych kafelków (opcjonalne)
        // 1. Pozyskać tile o najmniejszej entropii
        // 2. Wybrać tile i nadać mu wartość
        // 3. Propagować

        world = copy;
    }
    
}