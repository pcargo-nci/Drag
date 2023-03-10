using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Drag;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
[ObservableObject]
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // add the initial cards
        Cards.Add(CardCreate());
        Cards.Add(CardCreate());
        Cards.Add(CardCreate());
    }

    /// <summary>
    /// Represents list of Cards
    /// </summary>
    public ObservableCollection<Card> Cards { get; } = new ObservableCollection<Card>();

    /// <summary>
    /// Represents open ChildWindows
    /// </summary>
    List<ChildWindow> ChildWindows = new();

    // Create a dummy card
    /// <summary>
    /// Creates a Card
    /// </summary>
    private Card CardCreate()
    {
        Card newCard = new();
        newCard.MouseLeftButtonDown += Card_MouseLeftButtonDown;
        return newCard;
    }

    /// <summary>
    /// Handle MouseDown on Card
    /// </summary>
    private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // get reference to Card
        var card = (Card)sender;
        
        // get anchor point
        var anchor = card.PointToScreen(new Point(0,0));

        // create window
        ChildWindow childWindow = new()
        {
            // position window
            Top = anchor.Y,
            Left = anchor.X
        };

        ChildWindows.Add(childWindow);

        card.MouseLeftButtonDown -= Card_MouseLeftButtonDown;
        Cards.Remove(card);

        // show window
        childWindow.Show();

        // start dragging
        childWindow.DragMove();
    }

    /// <summary>
    /// Handle MainWindow Closing
    /// </summary>
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        // close the ChildWindows
        foreach(ChildWindow childWindow in ChildWindows)
        {
            childWindow.Close();
        }
    }

}
