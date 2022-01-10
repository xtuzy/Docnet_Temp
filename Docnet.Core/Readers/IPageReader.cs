using System;
using System.Collections.Generic;
using Docnet.Core.Converters;
using Docnet.Core.Models;

namespace Docnet.Core.Readers
{
    public interface IPageReader : IDisposable
    {
        /// <summary>
        /// Gets page index.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Get scaled page width.单位dp,与平台无关
        /// </summary>
        int GetPageWidth();

        /// <summary>
        /// Get scaled page width.单位Pixel,与各平台dpi相关
        /// </summary>
        int GetPageWidthPixel();

        /// <summary>
        /// Get scaled page high.单位dp,与平台无关
        /// </summary>
        int GetPageHeight();
        /// <summary>
        /// Get scaled page high.单位Pixel,与各平台dpi相关
        /// </summary>
        int GetPageHeightPixel();

        /// <summary>
        /// Get page text.
        /// </summary>
        string GetText();

        /// <summary>
        /// Get all page characters with
        /// their bounding boxes.
        /// </summary>
        IEnumerable<Character> GetCharacters();

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list.
        /// </summary>
        byte[] GetImage(RenderFlags flags);

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list.
        /// </summary>
        byte[] GetImage();
        /// <summary>
        /// CHANGED,由于Pdfium得到的宽高是平台无关的大小,因此根据dpi来获取渲染图片的像素大小
        /// </summary>
        /// <param name="dpi"></param>
        /// <returns></returns>
        byte[] GetImage(int dpi);

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list. Then it
        /// applies a predefined byte transformation
        /// to modify the image.
        /// </summary>
        byte[] GetImage(IImageBytesConverter converter);

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list. Then it
        /// applies a predefined byte transformation
        /// to modify the image.
        /// </summary>
        byte[] GetImage(IImageBytesConverter converter, RenderFlags flags);
    }
}
