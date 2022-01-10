using System;
using System.Runtime.InteropServices;
using Docnet.Core.Exceptions;
using System.IO;

using Docnet.Core.Utils;

namespace Docnet.Core.Bindings
{
    internal sealed class DocumentWrapper : IDisposable
    {
        private readonly IntPtr _ptr;

        public FpdfDocumentT Instance { get; private set; }

        public DocumentWrapper(string filePath, string password)
        {
            Instance = fpdf_view.FPDF_LoadDocument(filePath, password);

            if (Instance == null)
            {
                throw new DocnetLoadDocumentException("unable to open the document", fpdf_view.FPDF_GetLastError());
            }
        }

        public DocumentWrapper(byte[] bytes, string password)
        {
            _ptr = Marshal.AllocHGlobal(bytes.Length);

            Marshal.Copy(bytes, 0, _ptr, bytes.Length);

            Instance = fpdf_view.FPDF_LoadMemDocument(_ptr, bytes.Length, password);

            if (Instance == null)
            {
                throw new DocnetLoadDocumentException("unable to open the document", fpdf_view.FPDF_GetLastError());
            }
        }

        private readonly int _id;
        /// <summary>
        /// CHANGED,添加了读取文件流的用法
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="password"></param>
        public DocumentWrapper(System.IO.Stream stream,string password)
        {
            //https://github.com/pvginkel/PdfiumViewer/blob/master/PdfiumViewer/PdfFile.cs
            _id = StreamManager.Register(stream);

            Instance = fpdf_view.FPDF_LoadCustomDocument(stream,password,_id);

            if (Instance == null)
            {
                throw new DocnetLoadDocumentException("unable to open the document", fpdf_view.FPDF_GetLastError());
            }
        }

        public DocumentWrapper(FpdfDocumentT instance)
        {
            Instance = instance;

            if (Instance == null)
            {
                throw new DocnetLoadDocumentException("unable to open the document");
            }
        }

        public void Dispose()
        {
            if (Instance == null)
            {
                return;
            }
            //CHANGED
            StreamManager.Unregister(_id);

            fpdf_view.FPDF_CloseDocument(Instance);

            Marshal.FreeHGlobal(_ptr);

            Instance = null;
        }
    }
}
