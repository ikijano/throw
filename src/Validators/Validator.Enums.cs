namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfOutOfRange<TValue>(
        TValue value,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
        where TValue : struct, Enum
    {
#if NET5_0_OR_GREATER
        if (!Enum.IsDefined(value))
#else
        if (!Enum.IsDefined(typeof(TValue), value))
#endif
        {
            ExceptionThrower.ThrowOutOfRange(paramName, value, exceptionCustomizations, "Value should be defined in enum.");
        }
    }
}
