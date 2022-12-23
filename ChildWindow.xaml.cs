using System.Windows;
using System.Windows.Input;

namespace Drag;

/// <summary>
/// Interaction logic for ChildWindow.xaml
/// </summary>
public partial class ChildWindow : Window
{
    public ChildWindow()
    {
        InitializeComponent();
    }

    private Point LastPoint;

    private void Window_LocationChanged(object sender, System.EventArgs e)
    {

        // get reference to Card
        var childWindow = (ChildWindow)sender;

        LastPoint = new Point(childWindow.Left, childWindow.Top);
        System.Diagnostics.Debug.WriteLine(LastPoint);
        
    }
}
