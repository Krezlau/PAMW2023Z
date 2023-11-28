namespace zad7;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("AddABookPage", typeof(AddABookPage));
        Routing.RegisterRoute("BookListPage", typeof(BookListPage));
    }
}