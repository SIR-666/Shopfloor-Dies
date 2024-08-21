using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class BitmapHelper
{
    public static byte[] ConvertBitmapToMonochromeBytes(Bitmap bmp)
    {
        int threshold = 127;
        MemoryStream ms = new MemoryStream();
        for (int y = 0; y < bmp.Height; y++)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                Color pixelColor = bmp.GetPixel(x, y);
                byte pixelValue = (byte)(pixelColor.GetBrightness() > 0.5 ? 0 : 1);
                ms.WriteByte(pixelValue);
            }
        }
        return ms.ToArray();
    }

    public static byte[] GetImageCommand(Bitmap bitmap)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.WriteByte(0x1D); // GS
            ms.WriteByte(0x76); // v
            ms.WriteByte(0x30); // 0

            int width = bitmap.Width / 8;
            int height = bitmap.Height;

            ms.WriteByte((byte)(width % 256));  // Width low byte
            ms.WriteByte((byte)(width / 256));  // Width high byte
            ms.WriteByte((byte)(height % 256)); // Height low byte
            ms.WriteByte((byte)(height / 256)); // Height high byte

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width * 8; x += 8)
                {
                    byte byteValue = 0;
                    for (int bit = 0; bit < 8; bit++)
                    {
                        byteValue <<= 1;
                        if (x + bit < bitmap.Width)
                        {
                            Color pixelColor = bitmap.GetPixel(x + bit, y);
                            if (pixelColor.GetBrightness() <= 0.5)
                            {
                                byteValue |= 0x01;
                            }
                        }
                    }
                    ms.WriteByte(byteValue);
                }
            }
            return ms.ToArray();
        }
    }
}
