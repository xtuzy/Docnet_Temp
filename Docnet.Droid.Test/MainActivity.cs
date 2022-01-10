using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Docnet.Core;
using Docnet.Core.Models;
using SkiaSharp;
using System.Runtime.InteropServices;
using System.IO;
using SkiaSharp.Views.Android;
using AndroidX.AppCompat.App;
using AndroidX.Core.Content;
using Android;
using XamarinAndroidCommon.Tools;
using Xamarin.Essentials;
using Xamarin.Helper.Files;

namespace TestDocnet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var bt = FindViewById<Button>(Resource.Id.button1);
            var imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            bt.Click += (sender, e) =>
            {
                ExampleFixture();
                RenderToImage();
                imageView.SetImageBitmap(_bitmap);
            };
            // Need to ask for write permissions on SDK 23 and up, this is ignored on older versions
            AppUtils.RequestExternalStoragePermission(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        private const string Path = "/storage/emulated/0/Download/Sample.pdf";
        public IDocLib DocNet;
        Android.Graphics.Bitmap _bitmap;
        public void ExampleFixture()
        {
            DocNet = DocLib.Instance;
        }
        public void RenderToImage()
        {

            LogUtils.Info("RenderToImage", $"{File.Exists(Path)} 存在pdf");
            //从路径直接读取
            //var docReader = DocNet.GetDocReader(Path,new PageDimensions(1700, 2220));
            //从流读取
            /*using (StreamReader sr = new StreamReader(Path))
            {
            }*/
            //var fileStream = File.OpenRead(Path);
            var fileStream = FileHelper.ReadMemoryStreamFromAssets(this,"XamarinBinding.pdf");
            var docReader = DocNet.GetDocReader(fileStream, null);
            var size = docReader.GetPageSize(0);
            LogUtils.Info("RenderToImage", $"PageNativeSize:{size.Width },{size.Height}");
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var density = mainDisplayInfo.Density;
            LogUtils.Info("RenderToImage",$"屏幕密度:{density}");
            //Toast.MakeText(this, $"屏幕密度:{density}", ToastLength.Long).Show();
            var pageReader = docReader.GetPageReader(0);
            var rawBytes = pageReader.GetImage(dpi:(int)(density*160));

            var width = pageReader.GetPageWidthPixel();
            var height = pageReader.GetPageHeightPixel();
            LogUtils.Info("RenderToImage", $"Size:{width },{height}");
            var characters = pageReader.GetCharacters();

            //using var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using var bmp = new SKBitmap();

            //AddBytes(bmp, rawBytes);
            //DrawRectangles(bmp, characters);

            //Skiasharp方法
            // pin the managed array so that the GC doesn't move it
            var gcHandle = GCHandle.Alloc(rawBytes, GCHandleType.Pinned);
            // install the pixels with the color type of the pixel data
            var info = new SKImageInfo((int)width,(int)height, SKColorType.Bgra8888, SKAlphaType.Unpremul);
            bmp.InstallPixels(info, gcHandle.AddrOfPinnedObject(), info.RowBytes, delegate { gcHandle.Free(); }, null);
            _bitmap = bmp.ToBitmap();
            ImageUtils.SaveImageToFolderPathAsync(this, _bitmap, "/storage/emulated/0/Download");
            var s = pageReader.GetText();
            //LogUtils.Info("RenderToImage", s);
            var cList = pageReader.GetCharacters();
            int i = 0;
            foreach(var c in cList)
            {
                LogUtils.Info("RenderToImage", c.Char.ToString());
                if (i == 10)
                {
                    break;
                }
                i++;
            }
            docReader.Dispose();
        }

        /*private static void AddBytes(Bitmap bmp, byte[] rawBytes)
        {
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
            var pNative = bmpData.Scan0;

            Marshal.Copy(rawBytes, 0, pNative, rawBytes.Length);
            bmp.UnlockBits(bmpData);
        }*/

        /*private static void DrawRectangles(Bitmap bmp, IEnumerable<Character> characters)
        {
            var pen = new Pen(Color.Red);

            using var graphics = Graphics.FromImage(bmp);

            foreach (var c in characters)
            {
                var rect = new Rectangle(c.Box.Left, c.Box.Top, c.Box.Right - c.Box.Left, c.Box.Bottom - c.Box.Top);
                graphics.DrawRectangle(pen, rect);
            }
        }*/
    }
}
