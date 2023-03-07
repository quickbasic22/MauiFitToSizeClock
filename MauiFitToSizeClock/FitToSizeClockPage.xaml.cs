using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MauiFitToSizeClock;

public partial class FitToSizeClockPage : ContentPage
{
	Label clockLabel;

    public FitToSizeClockPage()
	{
		InitializeComponent();
		clockLabel = new Label
		{
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			TextColor = Colors.Red
		};
		Content = clockLabel;
	}

	private void ContentPage_SizeChanged(object sender, EventArgs e)
	{
		// Scale the font size to the page width
		//     (based on 11 characters in the diplayed string).
		if (this.Width > 0)
			clockLabel.FontSize = this.Width / 6;

		// Start the timer going.
        clockLabel.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Set the Text property of the Label.
                clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
            return true;
        });

    }
}

