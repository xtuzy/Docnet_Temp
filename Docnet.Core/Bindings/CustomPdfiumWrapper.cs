using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Docnet.Core.Utils;

#pragma warning disable SA1300
#pragma warning disable CA1707
#pragma warning disable CA1051
#pragma warning disable SA1401
#pragma warning disable CA1052
#pragma warning disable SA1307
#pragma warning disable SA1214

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Docnet.Core.Bindings
{
    /// <summary>
    /// Flags:
    /// 1 - Incremental
    /// 2 - NoIncremental
    /// 3 - RemoveSecurity.
    /// </summary>
    internal class fpdf_save
    {
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Setting.DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "FPDF_SaveAsCopy")]
        internal static extern int FPDF_SaveAsCopy(IntPtr document, FpdfStreamWriter pFileWrite, uint flags);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Setting.DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "FPDF_SaveWithVersion")]
        private static extern int FPDF_SaveWithVersion(IntPtr document, FpdfStreamWriter pFileWrite, uint flags, int fileVersion);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool StreamWriteHandler(IntPtr writerPtr, IntPtr data, int size);

        [StructLayout(LayoutKind.Sequential)]
        internal class FpdfStreamWriter
        {
            public int version = 1;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public readonly StreamWriteHandler Handler;

            public FpdfStreamWriter(StreamWriteHandler handler)
            {
                Handler = handler;
            }
        }

        public static bool FPDF_SaveAsCopy(FpdfDocumentT document, Stream stream)
        {
            byte[] buffer = null;

            var fileWrite = new FpdfStreamWriter((writerPtr, data, size) =>
            {
                if (buffer == null || buffer.Length < size)
                {
                    buffer = new byte[size];
                }

                Marshal.Copy(data, buffer, 0, size);

                stream.Write(buffer, 0, size);

                return true;
            });

            var result = FPDF_SaveAsCopy(document.__Instance, fileWrite, 3);

            GC.KeepAlive(fileWrite);

            return result == 1;
        }
    }

    /// <summary>
    /// CHANGED,模仿PdfiumViewer项目从流读取
    /// </summary>
    internal partial class fpdf_view
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport(Setting.DllName, CallingConvention = CallingConvention.Cdecl,
    EntryPoint = "FPDF_LoadCustomDocument")]
            internal static extern IntPtr CustomFPDF_LoadCustomDocument([MarshalAs(UnmanagedType.LPStruct)] CustomFPDF_FILEACCESS pFileAccess,
    [MarshalAs(UnmanagedType.LPStr)] string password);
        }

        //外部调用
        public static FpdfDocumentT FPDF_LoadCustomDocument(Stream stream, string password,int id)
        {
            var getBlock = Marshal.GetFunctionPointerForDelegate(_getBlockDelegate);
            //https://github.com/pvginkel/PdfiumViewer/blob/master/PdfiumViewer/NativeMethods.Pdfium.cs
            var access = new CustomFPDF_FILEACCESS
            {
                m_FileLen = (uint)stream.Length,
                m_GetBlock = getBlock,
                m_Param = (IntPtr)id
            };
            //var __arg0 = ReferenceEquals(pFileAccess, null) ? IntPtr.Zero : pFileAccess.__Instance;
            var __ret = __Internal.CustomFPDF_LoadCustomDocument(access, password);
            FpdfDocumentT __result0;
            if (__ret == IntPtr.Zero)
                __result0 = null;
            else if (FpdfDocumentT.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (FpdfDocumentT)FpdfDocumentT
                    .NativeToManagedMap[__ret];
            else
                __result0 = FpdfDocumentT.__CreateInstance(__ret);
            return __result0;
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDF_GetBlockDelegate(IntPtr param, uint position, IntPtr buffer, uint size);

        private static readonly FPDF_GetBlockDelegate _getBlockDelegate = FPDF_GetBlock;

        /// <summary>
        /// CHANGED
        /// </summary>
        /// <param name="param"></param>
        /// <param name="position"></param>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int FPDF_GetBlock(IntPtr param, uint position, IntPtr buffer, uint size)
        {
            var stream = StreamManager.Get((int)param);
            if (stream == null)
                return 0;
            byte[] managedBuffer = new byte[size];

            stream.Position = position;
            int read = stream.Read(managedBuffer, 0, (int)size);
            if (read != size)
                return 0;

            Marshal.Copy(managedBuffer, 0, buffer, (int)size);
            return 1;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class CustomFPDF_FILEACCESS
    {
        public uint m_FileLen;
        public IntPtr m_GetBlock;
        public IntPtr m_Param;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class CustomFPDF_FILEWRITE
    {
        public int version;
        public IntPtr WriteBlock;
        public IntPtr stream;
    }
}
