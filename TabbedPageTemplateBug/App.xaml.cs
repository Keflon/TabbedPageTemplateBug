namespace TabbedPageTemplateBug;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var rootPage = new TabbedPage();
        rootPage.ItemsSource = new List<object> { new Vm1(), new Vm2(), new Vm3() };
        rootPage.ItemTemplate = new TabbedItemTemplateSelector();
        MainPage = rootPage;
    }
    public class Vm1 { }
    public class Vm2 { }
    public class Vm3 { }
    class TabbedItemTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Vm1)
                return new DataTemplate(() => new ContentPage() { Title = "Type 1" });
            if (item is Vm2)
                return new DataTemplate(() => new ContentPage() { Title = "Type 2" });
            if (item is Vm3)
                return new DataTemplate(() => new ContentPage() { Title = "Type 3" });

            return null;
        }
    }
}

