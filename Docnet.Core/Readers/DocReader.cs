using Docnet.Core.Bindings;
using Docnet.Core.Exceptions;
using Docnet.Core.Models;
using Xamarin.Essentials;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local
namespace Docnet.Core.Readers
{
    internal class DocReader : IDocReader
    {
        private readonly DocumentWrapper _docWrapper;
        private readonly PageDimensions _dimensions;

        public DocReader(string filePath, string password, PageDimensions dimensions)
        {
            _dimensions = dimensions;

            lock (DocLib.Lock)
            {
                _docWrapper = new DocumentWrapper(filePath, password);
            }
        }

        public DocReader(byte[] bytes, string password, PageDimensions dimensions)
        {
            _dimensions = dimensions;

            lock (DocLib.Lock)
            {
                _docWrapper = new DocumentWrapper(bytes, password);
            }
        }

        /// <summary>
        /// CHANGED,,添加了读取文件流的用法
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="password"></param>
        public DocReader(System.IO.Stream stream,string password)
        {
            if (stream == null)
                throw new System.ArgumentNullException(nameof(stream));
            lock (DocLib.Lock)
            {
                _docWrapper = new DocumentWrapper(stream, password);
            }
        }

        /// <inheritdoc />
        public PdfVersion GetPdfVersion()
        {
            var version = 0;

            lock (DocLib.Lock)
            {
                var success = fpdf_view.FPDF_GetFileVersion(_docWrapper.Instance, ref version) == 1;

                if (!success)
                {
                    throw new DocnetException("failed to get pdf version");
                }
            }

            return new PdfVersion(version);
        }

        /// <inheritdoc />
        public int GetPageCount()
        {
            lock (DocLib.Lock)
            {
                return fpdf_view.FPDF_GetPageCount(_docWrapper.Instance);
            }
        }

        /// <inheritdoc />
        public IPageReader GetPageReader(int pageIndex)
        {
            return new PageReader(_docWrapper, pageIndex, _dimensions);
        }

        /// <inheritdoc />
        public PDFSize GetPageSize(int pageIndex)
        {
            double width=0;
            double height=0;
            var result = fpdf_view.FPDF_GetPageSizeByIndex(_docWrapper.Instance, pageIndex, ref width, ref height);
            if (result == 0)
            {
                return new PDFSize(0, 0);
            }
            else
            {
                return new PDFSize(width, height);
            }
        }
        public void Dispose()
        {
            lock (DocLib.Lock)
            {
                _docWrapper?.Dispose();
            }
        }
    }
}
