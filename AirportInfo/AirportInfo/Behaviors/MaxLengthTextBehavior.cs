using Xamarin.Forms;

namespace AirportInfo.Behaviors
{
    public class MaxLengthTextBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthTextBehavior), 0);

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable) => bindable.TextChanged += Bindable_TextChanged;

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
            {
                ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
            }
        }

        protected override void OnDetachingFrom(Entry bindable) => bindable.TextChanged -= Bindable_TextChanged;
    }
}
