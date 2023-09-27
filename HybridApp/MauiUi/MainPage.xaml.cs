using HybridWebView;

namespace MauiUi
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void HybridWebView_OnRawMessageReceived(object sender, HybridWebViewRawMessageReceivedEventArgs e)
        {
            var message = e.Message;

            if (string.IsNullOrWhiteSpace(message))
            {
                CheckInternet();
                return;
            }

            await Dispatcher.DispatchAsync(async () =>
            {
                await DisplayAlert("Message from JS", message, "Ok");
            });
        }

        private async void CheckInternet()
        {
            await Dispatcher.DispatchAsync(async () =>
            {
                var hasInternet = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
                var internetType = Connectivity.Current.ConnectionProfiles.FirstOrDefault();

                await Application.Current.MainPage.DisplayAlert("Internet",
                    $"Status: {hasInternet} of type {internetType}", "OK");
            });
        }
    }
}