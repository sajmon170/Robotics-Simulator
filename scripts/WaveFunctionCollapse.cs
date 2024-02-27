using System;

// czy robić Vector3::MakeRandom()?

class WaveFunctionCollapse : IGenerator {
    public void generate(World world) {
        Random random = new();
        world.CornerNETop = new Vector3() {
            X = random.Next(5, 20),
            Y = random.Next(5, 20),
            Z = random.Next(5, 20)
        };

        world.CornerSWBottom = new Vector3() {
            X = random.Next(-20, -5),
            Y = random.Next(-20, -5),
            Z = random.Next(-20, -5)
        };
    }
}
