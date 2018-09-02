using AirportInfo.Validation;
using Xamarin.Forms;

namespace AirportInfo.Behaviors
{
    public class TurnValidOnFocusBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty ValidityObjectProperty =
            BindableProperty.Create("ValidityObject", typeof(IValidity), typeof(TurnValidOnFocusBehavior), null);

        private Entry _entry;

        public IValidity ValidityObject
        {
            get => (IValidity)GetValue(ValidityObjectProperty);
            set => SetValue(ValidityObjectProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            _entry = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;

            bindable.Focused += OnEntryFocused;
        }

        protected override void OnBindingContextChanged() => base.OnBindingContextChanged();

        protected override void OnDetachingFrom(Entry bindable)
        {
            _entry = null;
            BindingContext = null;
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.Focused -= OnEntryFocused;
            base.OnDetachingFrom(bindable);
        }

        private void OnBindingContextChanged(object sender, System.EventArgs e) => BindingContext = _entry?.BindingContext;

        private void OnEntryFocused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused && ValidityObject != null)
            {
                ValidityObject.IsValid = true;
            }
        }
    }
}
