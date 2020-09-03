using System;

namespace Bank.Kata.App
{
    public class Amount
    {
        public Amount(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Amount AmountOf(int value)
        {
            return new Amount(value);
        }

        public Amount Plus(Amount amount)
        {
            return AmountOf(Value + amount.Value);
        }

        public bool IsGreaterThan(Amount amount)
        {
            return Value > amount.Value;
        }

        public Amount AbsoluteValue()
        {
            return AmountOf(Math.Abs(Value));
        }

        public string MoneyRepresentation()
        {
            return Value.ToString("#.##");
        }

        public Amount Negative()
        {
            return AmountOf(-Value);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Amount;

            if (ReferenceEquals(other, null)) return false;
            if (GetType() != obj.GetType()) return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Value.GetHashCode();
            }
        }

        public override string ToString() => 
            $"{nameof(Amount)} {{ {nameof(Value)}: {Value} }}";
    }
}
