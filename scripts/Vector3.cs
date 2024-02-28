using System;

public record struct Vector3 : IEquatable<Vector3> {
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }

    public bool Equals(Vector3 other) {
        return other.X == this.X
            && other.Y == this.Y
            && other.Z == this.Z;
    }

    public override int GetHashCode() {
        return (X, Y, Z).GetHashCode();
    }
}
