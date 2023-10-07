using FizzBuzzApp;

var fbExec = new FizzBuzzExecutor(15, prependIndex: false)
    .AddProcessor((x) => x % 3 == 0 ? "Fizz" : null)
    .AddProcessor((x) => x % 5 == 0 ? "Buzz" : null);

foreach (var state in fbExec)
{
    Console.WriteLine(state);
}