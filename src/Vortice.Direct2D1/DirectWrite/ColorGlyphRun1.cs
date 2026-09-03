// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using Vortice.DCommon;

namespace Vortice.DirectWrite;

public partial class ColorGlyphRun1
{
    /// <summary>
    /// Glyph run to draw for this layer.
    /// </summary>
    public GlyphRun GlyphRun;

    /// <summary>
    /// Pointer to the glyph run description for this layer.
    /// This may be NULL.
    /// For example, when the original glyph run is split into multiple layers, one layer might have a description and the others have none.
    /// </summary>
    public GlyphRunDescription? GlyphRunDescription;

    /// <summary>
    /// X coordinate of the baseline origin for the layer.
    /// </summary>
    public float BaselineOriginX;

    /// <summary>
    /// Y coordinate of the baseline origin for the layer.
    /// </summary>
    public float BaselineOriginY;

    /// <summary>
    /// Color value of the run; if all members are zero, the run should be drawn using the current brush.
    /// </summary>
    public Color4 RunColor;

    /// <summary>
    /// Zero-based index into the font’s color palette; if this is 0xFFFF, the run should be drawn using the current brush.
    /// </summary>
    public ushort PaletteIndex;

    /// <summary>
    /// Type of glyph image format for this color run.
    /// Exactly one type will be set since TranslateColorGlyphRun has already broken down the run into separate parts.
    /// </summary>
    public GlyphImageFormats GlyphImageFormat;

    /// <summary>
    /// Measuring mode to use for this glyph run.
    /// </summary>
    public MeasuringMode MeasuringMode;

    #region Marshal
    /// <remarks>
    /// DWRITE_COLOR_GLYPH_RUN1 derives from DWRITE_COLOR_GLYPH_RUN in C++, so its own members start after
    /// the full size of the base struct including its tail padding (glyphImageFormat is at offset 88 on x64, not 84).
    /// Embedding the base struct reproduces that layout on every platform.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    internal unsafe struct __Native
    {
        public ColorGlyphRun.__Native Base;
        public GlyphImageFormats GlyphImageFormat;
        public MeasuringMode MeasuringMode;

        internal unsafe void __MarshalFree()
        {
            Base.__MarshalFree();
        }
    }

    internal unsafe void __MarshalFree(ref __Native @ref)
    {
        @ref.__MarshalFree();
    }

    internal unsafe void __MarshalFrom(ref __Native @ref)
    {
        GlyphRun = new GlyphRun();
        GlyphRun.__MarshalFrom(ref @ref.Base.GlyphRun);

        if (@ref.Base.GlyphRunDescription == null)
        {
            GlyphRunDescription = null;
        }
        else
        {
            GlyphRunDescription = new GlyphRunDescription();
            GlyphRunDescription.__MarshalFrom(ref *@ref.Base.GlyphRunDescription);
        }

        BaselineOriginX = @ref.Base.BaselineOriginX;
        BaselineOriginY = @ref.Base.BaselineOriginY;
        RunColor = @ref.Base.RunColor;
        PaletteIndex = @ref.Base.PaletteIndex;
        GlyphImageFormat = @ref.GlyphImageFormat;
        MeasuringMode = @ref.MeasuringMode;
    }
    #endregion Marshal
}
