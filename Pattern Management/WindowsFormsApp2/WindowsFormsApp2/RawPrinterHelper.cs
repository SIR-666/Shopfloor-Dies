using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

public class RawPrinterHelper
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class DOCINFOA
    {
        [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
        [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
        [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
    }

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool StartDocPrinter(IntPtr hPrinter, int Level, [In] DOCINFOA pDocInfo);

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

    public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
    {
        int dwWritten = 0;
        IntPtr hPrinter = IntPtr.Zero;
        DOCINFOA di = new DOCINFOA
        {
            pDocName = "Raw Document",
            pDataType = "RAW"
        };
        bool bSuccess = false;

        if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
        {
            if (StartDocPrinter(hPrinter, 1, di))
            {
                if (StartPagePrinter(hPrinter))
                {
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                    EndPagePrinter(hPrinter);
                }
                EndDocPrinter(hPrinter);
            }
            ClosePrinter(hPrinter);
        }
        return bSuccess;
    }

    public static bool SendBytesToPrinter(string szPrinterName, byte[] data)
    {
        IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(data.Length);
        Marshal.Copy(data, 0, pUnmanagedBytes, data.Length);
        bool success = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, data.Length);
        Marshal.FreeCoTaskMem(pUnmanagedBytes);
        return success;
    }

    public static bool SendStringToPrinter(string szPrinterName, string szString)
    {
        IntPtr pBytes;
        int dwCount = szString.Length;
        pBytes = Marshal.StringToCoTaskMemAnsi(szString);
        bool result = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
        Marshal.FreeCoTaskMem(pBytes);
        return result;
    }

    public static bool SendImageToPrinter(string szPrinterName, Bitmap bmp)
    {
        MemoryStream ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Bmp);
        byte[] bmpBytes = ms.ToArray();

        IntPtr unmanagedPointer = Marshal.AllocHGlobal(bmpBytes.Length);
        Marshal.Copy(bmpBytes, 0, unmanagedPointer, bmpBytes.Length);

        bool success = SendBytesToPrinter(szPrinterName, unmanagedPointer, bmpBytes.Length);

        Marshal.FreeHGlobal(unmanagedPointer);
        return success;
    }
}
