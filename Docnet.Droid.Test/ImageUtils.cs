using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using XamarinCommon.Tools;
using File = Java.IO.File;
using Path = System.IO.Path;

namespace XamarinAndroidCommon.Tools
{
    public class ImageUtils
    {
        private static readonly string TAG = "ImageUtils";

        public static async Task<string> SaveImageToFolderPathAsync(Context context, Bitmap bitmap, string folderPath)
        {
            return await Task.Run(() =>
            {
                if (bitmap == null) return null;

                var isSaved = true;
                ;
                //WARN:这里混用了Java.IO和System.IO
                /*首先创建文件夹*/
                var appDir = new File(folderPath);
                if (!appDir.Exists()) appDir.Mkdir(); //创建文件夹
                var fileName = TimeUtils.CurrentSystemTimeMillis + ".jpg";
                var file = new File(appDir, fileName);
                LogUtils.Info("test_sign", "图片全路径localFile = " + appDir.AbsolutePath + fileName);
                FileStream stream = null;
                try
                {
                    var filePath = Path.Combine(folderPath, fileName);
                    stream = new FileStream(filePath, FileMode.Create);
                    bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);//质量压缩在不改变像素的大小的前提下,降低图像的质量,改变存储带线啊哦
                }
                catch (Exception e)
                {
                    Toast.MakeText(context, "保存图片失败", ToastLength.Short);
                    isSaved = false;
                }
                finally
                {
                    if (stream != null)
                        try
                        {
                            stream.Close();
                            //回收
                            bitmap.Recycle();
                        }
                        catch (Exception e)
                        {
                            LogUtils.Error(TAG, "流释放出错");
                            isSaved = false;
                        }
                }

                if (isSaved)
                    return file.AbsolutePath;
                return null;
            });
        }

        /// <summary>
        ///     异步读取图片，再填充ImageView时可能因为异步而有加载慢一拍的感觉
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="reqWidth"></param>
        /// <param name="reqHeight"></param>
        /// <returns></returns>
        public static async Task<Bitmap> ReadBitmapFromImageFileAsync(string imagePath, int reqWidth, int reqHeight)
        {
            //来自Google文档的高效加载大型位图
            // First decode with inJustDecodeBounds=true to check dimensions
            return await Task.Run(() =>
            {
                var options = new BitmapFactory.Options();
                options.InJustDecodeBounds = true; //这个选项意味着不加载图像到内存
                BitmapFactory.DecodeFile(imagePath, options);

                // Calculate inSampleSize
                options.InSampleSize = CalculateInSampleSizeByNearestNeighbour(options, reqWidth, reqHeight);

                // Decode bitmap with inSampleSize set
                options.InJustDecodeBounds = false;
                return BitmapFactory.DecodeFile(imagePath, options);
            });
        }

        /// <summary>
        ///      Google文档:读取位图尺寸和类型
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static BitmapFactory.Options ReadBitmapInforFromImageFile(string imagePath)
        {
            var options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true; //这个选项意味着不加载图像到内存
            BitmapFactory.DecodeFile(imagePath, options);
            return options;
        }

        /// <summary>
        /// Google文档:高效加载大型位图
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="reqWidth"></param>
        /// <param name="reqHeight"></param>
        /// <param name="sampleMethod">1为邻近采样(快速),2为线性采样(慢)</param>
        /// <returns></returns>
        public static Bitmap ReadBitmapFromImageFile(string imagePath, int reqWidth, int reqHeight,int sampleMethod)
        {
            //来自Google文档的高效加载大型位图
            // First decode with inJustDecodeBounds=true to check dimensions

            switch (sampleMethod)
            {
                   case 1:
                    {
                        var options = new BitmapFactory.Options();
                        options.InJustDecodeBounds = true; //这个选项意味着不加载图像到内存
                        BitmapFactory.DecodeFile(imagePath, options);
                        // Calculate inSampleSize
                        options.InSampleSize = CalculateInSampleSizeByNearestNeighbour(options, reqWidth, reqHeight);

                        // Decode bitmap with inSampleSize set
                        options.InJustDecodeBounds = false;
                        return BitmapFactory.DecodeFile(imagePath, options);
                        break;
                    }
                   case 2:
                   {
                       Bitmap bitmap = BitmapFactory.DecodeFile(imagePath);
                       Bitmap compress = Bitmap.CreateScaledBitmap(bitmap, bitmap.Width / reqWidth, bitmap.Height / reqHeight, true);
                       return compress;
                       break;
                   }
                   default:
                   {
                       return null;
                   }
            }
        }
        
        /// <summary>
        /// 直接从文件加载图片，可能OOM
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static Bitmap ReadBitmapFromImageFile(string imagePath)
        {
            return BitmapFactory.DecodeFile(imagePath);
        }



        /// <summary>
        ///     对原来的位图采样:邻近采样
        /// </summary>
        /// <param name="options"></param>
        /// <param name="reqWidth"></param>
        /// <param name="reqHeight"></param>
        /// <returns></returns>
        private static int CalculateInSampleSizeByNearestNeighbour(
            BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            var height = options.OutHeight;
            var width = options.OutWidth;
            var inSampleSize = 1;

            if (height > reqHeight || width > reqWidth)
            {
                var halfHeight = height / 2;
                var halfWidth = width / 2;

                // Calculate the largest inSampleSize value that is a power of 2 and keeps both
                // height and width larger than the requested height and width.
                while (halfHeight / inSampleSize >= reqHeight
                       && halfWidth / inSampleSize >= reqWidth)
                    inSampleSize = inSampleSize * 2;
            }
            return inSampleSize;
        }

    }
}
