using System.Reflection;

namespace Infrastructure;

public static class AssemblyRefence
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}