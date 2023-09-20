using BorderlessEntryDemo.Handler;

namespace BorderlessEntryDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
            {
                if (view is CustomEntry)
                {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            });


            MainPage = new AppShell();
        }
    }
}
