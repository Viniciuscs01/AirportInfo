using System.Windows.Input;
using Xamarin.Forms;

namespace AirportInfo.Behaviors
{
    public class ValidateOnTextChangedBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty ValidateCommandProperty =
                BindableProperty.Create("ValidateCommand", typeof(ICommand),
                    typeof(ValidateOnTextChangedBehavior), default(ICommand),
                    BindingMode.OneWay, null);

        private VisualElement _element;

        public ICommand ValidateCommand
        {
            get => (ICommand)GetValue(ValidateCommandProperty);
            set => SetValue(ValidateCommandProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            _element = bindable;
            bindable.TextChanged += Bindable_TextChanged;
            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            _element = null;
            BindingContext = null;
            bindable.TextChanged -= Bindable_TextChanged;
            bindable.BindingContextChanged -= OnBindingContextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ValidateCommand != null && ValidateCommand.CanExecute(null))
            {
                ValidateCommand.Execute(null);
            }
        }

        private void OnBindingContextChanged(object sender, System.EventArgs e) => BindingContext = _element?.BindingContext;
    }
}
