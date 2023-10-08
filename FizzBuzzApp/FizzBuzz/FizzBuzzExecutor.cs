using System.Collections;

namespace FizzBuzzApp.FizzBuzz
{
    public class FizzBuzzExecutor : IEnumerable<string>
    {
        private readonly int start;
        private readonly int end;
        private readonly bool prependIndex;

        private List<Func<int, string?>> processors = new List<Func<int, string?>>();
        private Func<int, string>? defaultAction = null;

        public FizzBuzzExecutor(int end, int start = 1, bool prependIndex = false)
        {
            this.end = end;
            this.start = start;
            this.prependIndex = prependIndex;
        }

        public FizzBuzzExecutor AddProcessor(Func<int, string?> processor)
        {
            this.processors.Add(processor);
            return this;
        }

        public FizzBuzzExecutor SetDefaultAction(Func<int, string> defaultAction)
        {
            this.defaultAction = defaultAction;
            return this;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new FizzBuzzEnumerator(this.start, this.end, prependIndex, this.processors, this.defaultAction);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
