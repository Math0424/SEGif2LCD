using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SEGIF2LCD
{
    class BitmapHelper
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct PixelColor
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }

        public static BitmapSource[] GetFrames(Image image, int width, int height)
        {
            BitmapSource[] images = new BitmapSource[image.GetFrameCount(FrameDimension.Time)];
            for (int i = 0; i < images.Length; i++)
            {
                var sourceBitmap = GetBitmapSource((Bitmap)image);
                images[i] = new TransformedBitmap(sourceBitmap, new ScaleTransform(width / sourceBitmap.Width, height / sourceBitmap.Height));
                image.SelectActiveFrame(FrameDimension.Time, i);
            }
            return images;
        }

        public static PixelColor[,] GetPixels(BitmapSource source)
        {
            if (source.Format != PixelFormats.Bgra32)
                source = new FormatConvertedBitmap(source, PixelFormats.Bgra32, null, 0);

            int width = source.PixelWidth;
            int height = source.PixelHeight;
            PixelColor[,] result = new PixelColor[width, height];
            CopyPixels(source, result, width * 4);
            return result;
        }

        public static void CopyPixels(BitmapSource source, PixelColor[,] pixels, int stride)
        {
            var height = source.PixelHeight;
            var width = source.PixelWidth;
            var pixelBytes = new byte[height * width * 4];
            source.CopyPixels(pixelBytes, stride, 0);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    pixels[x, y] = new PixelColor
                    {
                        Blue = pixelBytes[(x + (y * width)) * 4 + 0],
                        Green = pixelBytes[(x + (y * width)) * 4 + 1],
                        Red = pixelBytes[(x + (y * width)) * 4 + 2],
                        Alpha = pixelBytes[(x + (y * width)) * 4 + 3],
                    };
        }

        public static BitmapSource GetBitmapSource(Bitmap image)
        {
            var rect = new Rectangle(0, 0, image.Width, image.Height);
            var bitmap_data = image.LockBits(rect, ImageLockMode.ReadOnly, image.PixelFormat);

            try
            {
                BitmapPalette palette = null;

                if (image.Palette.Entries.Length > 0)
                {
                    var palette_colors = image.Palette.Entries.Select(entry => System.Windows.Media.Color.FromArgb(entry.A, entry.R, entry.G, entry.B)).ToList();
                    palette = new BitmapPalette(palette_colors);
                }

                return BitmapSource.Create(
                    image.Width,
                    image.Height,
                    image.HorizontalResolution,
                    image.VerticalResolution,
                    ConvertPixelFormat(image.PixelFormat),
                    palette,
                    bitmap_data.Scan0,
                    bitmap_data.Stride * image.Height,
                    bitmap_data.Stride
                );
            }
            finally
            {
                image.UnlockBits(bitmap_data);
            }
        }

        private static System.Windows.Media.PixelFormat ConvertPixelFormat(System.Drawing.Imaging.PixelFormat sourceFormat)
        {
            switch (sourceFormat)
            {
                case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                    return PixelFormats.Bgr24;

                case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                    return PixelFormats.Bgra32;

                case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
                    return PixelFormats.Bgr32;
            }

            return new System.Windows.Media.PixelFormat();
        }

    }
}
