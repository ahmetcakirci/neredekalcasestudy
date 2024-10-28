using System.Reflection;

namespace Report.Infrastructure;

public static class AssemblyRefence
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}