using System;
using System.Collections.Generic;
using System.Text;

namespace Docnet.Core
{
    internal static class Setting
    {
#if __ANDROID__
        internal const string DllName = "pdfium";
#else
        internal const string DllName = "__Internal";
#endif
    }
}
