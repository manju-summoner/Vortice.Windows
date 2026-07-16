// Copyright (c) Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using SharpGen.Runtime;

namespace Vortice.MediaFoundation;

public partial class IMFSourceReader
{
    /// <summary>
    /// 非同期モードのソースリーダーへサンプル読み取りを要求します。
    /// 結果は <see cref="IMFSourceReaderCallback.OnReadSample"/> に通知されます。
    /// </summary>
    public unsafe void ReadSampleAsync(int streamIndex, int controlFlags = 0)
    {
        Result result = ((delegate* unmanaged[Stdcall]<nint, int, int, void*, void*, void*, void*, int>)this[9U])(
            NativePointer,
            streamIndex,
            controlFlags,
            null,
            null,
            null,
            null);
        result.CheckError();
    }
}
