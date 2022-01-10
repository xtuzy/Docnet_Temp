using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace XamarinAndroidCommon.Tools
{
    /// <summary>
    /// 应用级别实用工具合集
    /// </summary>
    public class AppUtils
    {
        private readonly string TAG = "AppUtils";

        private static Context context;
        private static Thread uiThread;

        //private static Handler handler = new Handler(Looper.MainLooper);

        public static void Init(Context context)
        {
            AppUtils.context = context;
            AppUtils.uiThread = Thread.CurrentThread;
        }

        public static Context GetAppContext()
        {
            return context;
        }

        public static AssetManager GetAssets()
        {
            return context.Assets;
        }

        public static Resources GetResource()
        {
            return context.Resources;
        }

        public static bool IsUIThread()
        {
            return Thread.CurrentThread == uiThread;//这样确定?
        }

        /// <summary>
        /// 得到bitmap的大小
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static int GetBitmapSize(Bitmap bitmap)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {    //API 19
                return bitmap.AllocationByteCount;
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.HoneycombMr1)
            {//API 12
                return bitmap.ByteCount;
            }
            // 在低版本中用一行的字节x高度
            return bitmap.RowBytes * bitmap.Height;
        }

        /// <summary>
        /// 显示键盘
        /// </summary>
        /// <param name="view"></param>
        public static void ShowKeyboard(View view)
        {
            InputMethodManager imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
            if (imm != null)
                imm.ShowSoftInput(view, 0);
        }

        /// <summary>
        /// 隐藏键盘
        /// </summary>
        /// <param name="view"></param>
        public static void HideKeyboard(View view)
        {
            InputMethodManager imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
            if (imm != null)
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
        }


        /// <summary>
        /// 存储权限
        /// </summary>
        private static readonly string[] PERMISSIONS_STORAGE = {
        Android.Manifest.Permission.ReadExternalStorage,
        Android.Manifest.Permission.WriteExternalStorage,
        };

        /// <summary>
        /// Defines the REQUEST_EXTERNAL_STORAGE
        /// </summary>
        private static readonly int REQUEST_EXTERNAL_STORAGE = 1;

        /// <summary>
        /// 检查应用程序是否有权写入设备存储
        /// 如果应用没有权限，则系统将提示用户授予权限
        /// </summary>
        /// <param name="activity"></param>
        public static void RequestExternalStoragePermission(Activity activity)
        {
            // 检查我们是否具有写权限
            if (AndroidX.Core.App.ActivityCompat.CheckSelfPermission(activity, Android.Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted)
            {
                // 我们没有权限，所以提示用户
                AndroidX.Core.App.ActivityCompat.RequestPermissions(
                    activity,
                    PERMISSIONS_STORAGE,
                    REQUEST_EXTERNAL_STORAGE
                );
            }
        }
    }
}