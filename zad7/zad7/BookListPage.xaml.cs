﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad7.ViewModels;

namespace zad7;

public partial class BookListPage : ContentPage
{
    public BookListPage(BookListViewModel bookListViewModel)
    {
        InitializeComponent();
        BindingContext = bookListViewModel;
    }
}