using CommunityToolkit.Maui.Storage;
using System.Text;

namespace FileSaverEx
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object? sender, EventArgs e)
        {
            try
            {
                var text = "This is a text";
                var fileStream = new MemoryStream(Encoding.UTF8.GetBytes(text));

                var result = await FileSaver.Default.SaveAsync("test.txt", fileStream, CancellationToken.None);
            
                if(!result.IsSuccessful)
                    throw result.Exception;
            }
            catch(Exception ex)
            {
                var message = ex.Message;
            }
        }
    }
}
