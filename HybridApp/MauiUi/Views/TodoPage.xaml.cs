using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiUi.ViewModels;

namespace MauiUi.Views;

public partial class TodoPage : ContentPage
{
    public TodoPage(TodoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}