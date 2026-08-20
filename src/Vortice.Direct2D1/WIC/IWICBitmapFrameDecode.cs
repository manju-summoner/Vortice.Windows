// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.WIC;

public unsafe partial class IWICBitmapFrameDecode
{
    /// <summary>
    /// Gets the color contexts associated with the frame.
    /// </summary>
    /// <param name="colorContexts">
    /// The color contexts to fill. The instances must be created by the caller
    /// (see <see cref="IWICImagingFactory.CreateColorContext"/>) before calling this method.
    /// </param>
    /// <param name="actualCount">The number of color contexts contained in the frame.</param>
    /// <remarks>
    /// The generated <see cref="GetColorContexts(int, IWICColorContext[], out int)"/> overload passes an
    /// uninitialized buffer to the native method, which makes it fail with E_INVALIDARG. Use this overload instead.
    /// Pass an empty array to query <paramref name="actualCount"/> only.
    /// </remarks>
    public Result GetColorContexts(IWICColorContext[] colorContexts, out int actualCount)
    {
        ArgumentNullException.ThrowIfNull(colorContexts);

        actualCount = 0;

        Span<IntPtr> pointers = colorContexts.Length < 1024 / sizeof(IntPtr)
            ? stackalloc IntPtr[colorContexts.Length]
            : new IntPtr[colorContexts.Length];
        for (var i = 0; i < colorContexts.Length; i++)
        {
            var colorContext = colorContexts[i];
            if (colorContext is null)
                throw new ArgumentException($"The color context at index {i} has not been created.", nameof(colorContexts));

            pointers[i] = colorContext.NativePointer;
        }

        Result result;
        fixed (void* actualCountPtr = &actualCount)
            fixed (void* pointersPtr = pointers)
                result = (Result)((delegate* unmanaged[Stdcall]<IntPtr, int, void*, void*, int>)this[9U])(
                    NativePointer, colorContexts.Length, pointersPtr, actualCountPtr);

        GC.KeepAlive(colorContexts);
        return result;
    }
}
