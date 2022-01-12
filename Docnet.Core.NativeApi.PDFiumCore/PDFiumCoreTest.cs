using PDFiumCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Docnet.Core.NativeApi.PDFiumCore
{
    public static class PDFiumCoreTest
    {
        public static void Init()
        {
            FPDF_LIBRARY_CONFIG_ config = new FPDF_LIBRARY_CONFIG_();
            config.Version = 2;
            //config.MPIsolate = null;
            config.MV8EmbedderSlot = 0;
            fpdfview.FPDF_InitLibraryWithConfig(config);
        }
    }
}
