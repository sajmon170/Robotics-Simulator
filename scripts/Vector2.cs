using System;

public record struct Vector2 : IEquatable<Vector2> {
    public int X { get; init; }
    public int Y { get; init; }

    public bool Equals(Vector3 other) {
        return other.X == this.X
            && other.Y == this.Y
    }

    public override int GetHashCode() {
        return (X, Y).GetHashCode();
    }
}
