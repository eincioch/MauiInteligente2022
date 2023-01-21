using System.Windows.Input;

namespace MauiInteligente2022.AppBase.Controls;

public partial class MenuItem : Border {
	public MenuItem() {
		InitializeComponent();
	}

	public static readonly BindableProperty SourceProperty =
		BindableProperty.Create(nameof(Source), typeof(ImageSource)
						, typeof(MenuItem), null, propertyChanged: SourcePropertyChanged);

	public ImageSource Source {
		get => (ImageSource)GetValue(SourceProperty);
		set => SetValue(SourceProperty, value);
	}

    public static readonly BindableProperty TextProperty 
        = BindableProperty.Create(nameof(Text), typeof(String), typeof(MenuItem), 
            null, propertyChanged: TextPropertyChanged);
    
    public string Text {
        get => (String)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty MenuCommandProperty 
        = BindableProperty.Create(nameof(MenuCommand), typeof(ICommand), 
            typeof(MenuItem), null, propertyChanged: MenuCommandPropertyChanged);

    public ICommand MenuCommand {
        get => (ICommand)GetValue(MenuCommandProperty);
        set => SetValue(MenuCommandProperty, value);
    }

    static void SourcePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
		var menuItem = bindable as MenuItem;
		menuItem.image.Source = newValue as ImageSource;
	}

    static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        var menuItem = bindable as MenuItem;
        menuItem.label.Text = newValue as String;
    }

    static void MenuCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
        var menuItem = bindable as MenuItem;
        menuItem.image.Command = newValue as ICommand;
    }
}