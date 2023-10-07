using System.Collections;

namespace FizzBuzzApp.FizzBuzz
{
    public class FizzBuzzEnumerator : IEnumerator<string>
    {
        private int startIndex;
        private readonly int endIndex;

        private readonly bool prependIndex;
        private readonly List<Func<int, string?>> processors;

        private int currentIndex = 0;
        private string currentState = string.Empty;

        public FizzBuzzEnumerator(int start, int end, bool prependIndex, List<Func<int, string?>> processors)
        {
            this.startIndex = start - 1;
            this.endIndex = end;

            this.prependIndex = prependIndex;
            this.processors = processors;

            Reset();
        }

        public string Current => currentState;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex > endIndex)
            {
                return false;
            }
            currentState = CalculateState(currentIndex);
            return true;
        }

        public void Reset()
        {
            this.currentIndex = this.startIndex;
            this.currentState = string.Empty;
        }

        private string CalculateState(int index)
        {
            var state = string.Empty;
            foreach (var processor in this.processors)
            {
                state += processor(index) ?? string.Empty;
            }

            state = state == string.Empty ? GetIndexStr(index) : state;
            state = this.prependIndex ? $"{GetIndexStr(index)}: {state}" : state;

            return state;
        }

        private string GetIndexStr(int index)
        {
            return index.ToString().PadLeft(2, '0');
        }
    }
}
