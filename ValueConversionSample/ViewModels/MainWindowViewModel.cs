using ReactiveUI;

namespace ValueConversionSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // The initial value is 2. 
        private decimal? _number1 = 2;

        /// <summary>
        /// This is our Number 1
        /// </summary>
        public decimal? Number1
        {
            get => _number1;
            set => this.RaiseAndSetIfChanged(ref _number1, value);
        }


        // The initial value is 3.
        private decimal? _number2 = 3;

        /// <summary>
        /// This is our Number 2
        /// </summary>
        public decimal? Number2
        {
            get => _number2;
            set => this.RaiseAndSetIfChanged(ref _number2, value);
        }


        // The initial value is "+" (Add).
        private string _operator = "+";

        /// <summary>
        /// Gets or sets the operator to use. The initial value is "+"
        /// </summary>
        public string Operator
        {
            get => _operator;
            set => this.RaiseAndSetIfChanged(ref _operator, value);
        }

        /// <summary>
        /// Gets a collection of available operators
        /// </summary>
        public string[] AvailableMathOperators { get; } =
        [
            "+", "-", "*", "/"
        ];
    }
}
