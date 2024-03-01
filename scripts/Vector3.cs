using System;

public record struct Vector3 : IEquatable<Vector3> {
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }
    public static Random random = new();

    public bool Equals(Vector3 other) {
        return other.X == this.X
            && other.Y == this.Y
            && other.Z == this.Z;
    }

    public override int GetHashCode() {
        return (X, Y, Z).GetHashCode();
    }

    /// <summary>
    /// Generates a new <c>Vector3</c> with every coordinate
    /// between <c>coordMin</c> (inclusive) and <c>coordMax</c> (exclusive)
    /// </summary>
    public static Vector3 MakeRandom(int coordMin, int coordMax) {
        return new Vector3() {
            X = random.Next(coordMin, coordMax),
            Y = random.Next(coordMin, coordMax),
            Z = random.Next(coordMin, coordMax)
        };
    }

    /// <summary>
    /// Generates a new <c>Vector3</c> with coordinates
    /// between <c>lowerBound</c> (inclusive) and <c>upperBound</c> (exclusive)
    /// </summary>
    public static Vector3 MakeRandom(Vector3 lowerBound, Vector3 upperBound) {
        return new Vector3() {
            X = random.Next(lowerBound.X, upperBound.X),
            Y = random.Next(lowerBound.Y, upperBound.Y),
            Z = random.Next(lowerBound.Z, upperBound.Z)
        };
    }

    public static Vector3 operator-(Vector3 u) {
        return new Vector3() {
            X = -u.X,
            Y = -u.Y,
            Z = -u.Z
        };
    }
}
