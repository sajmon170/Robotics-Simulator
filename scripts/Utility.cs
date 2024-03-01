using System;

public static class Utility {
    private static Random random = new();
    
    public static T RandomChoice<T>()
    where T : System.Enum {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(random.Next(0, values.Length));
    }
}
