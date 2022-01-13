# Docnet
尝试对 https://github.com/GowenGit/docnet修改,最后整合到我的docnet fork项目
原项目通过CppSharp对Pdfium的C头文件进行了包装供C#调用,
但是原项目不适用于移动平台,因此通过搜集移动平台的libpdfium文件构建,其它源码基本未修改。

- 对iOS使用静态库失败,总是出现EntryPointNotFound,大量搜索后未解决,准备使用iOS自带的PDFKit渲染,如果需要其他的绘制功能,可以添加其他Pdf绘制库
