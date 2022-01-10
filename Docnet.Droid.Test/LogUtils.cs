using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace XamarinAndroidCommon.Tools
{
    public class LogUtils
    {
        public static void Debug(string tag, string msg)
        {
            Log.Debug(tag, msg);
        }
        public static void Error(string tag, string msg)
        {
            Log.Error(tag, msg);
        }
        public static void Info(string tag, string msg)
        {
            Log.Info(tag, msg);
        }
        public static void Warn(string tag, string msg)
        {
            Log.Warn(tag, msg);
        }
    }
}