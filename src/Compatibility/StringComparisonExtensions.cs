#if !NET5_0_OR_GREATER
namespace System.Runtime.CompilerServices;

internal static class StringComparisonExtensions
{
    public static bool Contains(this string str, string value, StringComparison comparison)
    {
        return str.IndexOf(value, comparison) >= 0;
    }
}
#endif
