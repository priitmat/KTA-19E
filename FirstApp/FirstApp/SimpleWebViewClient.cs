using Android.Webkit;

namespace firstApp {
    public class SimpleWebViewClient :WebViewClient {
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request) {
            view.LoadUrl(request.Url.ToString());
            return base.ShouldOverrideUrlLoading(view, request);
        }
    }
}