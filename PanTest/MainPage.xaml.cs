namespace PanTest
{
    public partial class MainPage
    {
        private bool safeMode;
         
        public MainPage()
        {
            InitializeComponent();
        }

        private void Panned(object sender, PanUpdatedEventArgs e)
        {
            try
            {
                switch (e.StatusType)
                {
                    case GestureStatus.Running:

                        this.translationX.Text = $"Translation X: {e.TotalX}";
                        this.translationY.Text = $"Translation Y: {e.TotalY}";

                        if (safeMode)
                        {
                            this.border.TranslationX += e.TotalX;
                            this.border.TranslationY += e.TotalY;
                        }
                        else
                        {
                            //In case of Object Rotation
                            this.border.TranslationX += e.TotalX * Math.Cos(0) - e.TotalY * Math.Sin(0);
                            this.border.TranslationY += e.TotalX * Math.Sin(0) + e.TotalY * Math.Cos(0);
                        }
                        break;
                }
            }
            catch
            {
                //Ignore
            }
        }
        private void ResetPosition(object sender, EventArgs e)
        {
            this.border.TranslationX = 0;
            this.border.TranslationY = 0;
        }
        private void ChangeMode(object sender, EventArgs e)
        {
            this.safeMode = !this.safeMode;
            this.safe.Text = this.safeMode ? "On" : "Off";
        }
    }
}
