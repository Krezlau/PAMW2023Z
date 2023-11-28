using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad7.ViewModels;

namespace zad7;

public partial class AddABookPage : ContentPage
{
    public AddABookPage(AddABookViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}