using CommunityToolkit.Maui.Core;

namespace SideLayout.ViewModels;

public partial class DrawingViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<IDrawingLine> lines = new();

    [RelayCommand]
    public void Clear()
    {
        Lines.Clear();
    }

    [RelayCommand]
    public void Save()
    {
        
    }
}
