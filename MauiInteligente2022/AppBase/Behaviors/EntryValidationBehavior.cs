using MauiInteligente2022.AppBase.Validations;

namespace MauiInteligente2022.AppBase.Behaviors;

public class EntryValidationBehavior : Behavior<Entry> {
    static readonly BindablePropertyKey IsValidPropertyKey =
        BindableProperty.CreateReadOnly(nameof(IsValid), typeof(ValidationResult),
            typeof(EntryValidationBehavior), ValidationResult.None);

    public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

    public ValidationResult IsValid => (ValidationResult)GetValue(IsValidProperty);

    static readonly BindableProperty ValidationTypeProperty =
        BindableProperty.Create(nameof(ValidationType), typeof(ValidationType), typeof(EntryValidationBehavior),
            ValidationType.None, defaultBindingMode: BindingMode.OneWay);

    public ValidationType ValidationType {
        get => (ValidationType)GetValue(ValidationTypeProperty);
        set => SetValue(ValidationTypeProperty, value);
    }

    protected override void OnAttachedTo(Entry bindable) {
        bindable.TextChanged += Bindable_TextChanged;
    }

    private void Bindable_TextChanged(object sender, TextChangedEventArgs e) {
        var entry = sender as Entry;
    }

    protected override void OnDetachingFrom(BindableObject bindable) {
        
    }
}