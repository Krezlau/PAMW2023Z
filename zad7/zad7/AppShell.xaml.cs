namespace zad7;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("AddABookPage", typeof(AddABookPage));
        Routing.RegisterRoute("BookListPage", typeof(BookListPage));
        Routing.RegisterRoute("BookDetailsPage", typeof(BookDetailsPage));
        Routing.RegisterRoute("EditBookPage", typeof(EditBookPage));
        Routing.RegisterRoute("ChangePasswordPage", typeof(ChangePasswordPage));
        Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
        Routing.RegisterRoute("HomePage", typeof(MainPage));
    }
}