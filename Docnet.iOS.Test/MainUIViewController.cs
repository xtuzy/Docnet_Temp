using CoreFoundation;
using Docnet.Core;
using Foundation;
using Helper.Files;
using System;
using System.Drawing;
using UIKit;

namespace Docnet.iOS.Test
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("MainUIViewController")]
    public class MainUIViewController : UIViewController
    {
        public MainUIViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {

           

            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            var button = new UIButton(UIButtonType.RoundedRect) { TranslatesAutoresizingMaskIntoConstraints=false};
            View.Add(button);
            button.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            button.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
            button.SetTitle("打开Pdf", UIControlState.Normal);
            button.TouchUpInside += Button_TouchUpInside;
        }

        private void Button_TouchUpInside(object sender, EventArgs e)
        {
            //DocNet = DocLib.Instance;
            Core.NativeApi.PDFiumCore.PDFiumCoreTest.Init();
            RenderToImage();
        }

        public IDocLib DocNet;
        void RenderToImage()
        {
            var fileStream = FileHelper.FromResources("XamarinBinding.pdf");
            var docReader = DocNet.GetDocReader(fileStream, null);
            var size = docReader.GetPageSize(0);
        }
    }
}