# MockDemo

This is a simple demo solution illustrating how to use Moq to assist in unit testing.

The scenario here is that there is an interface called "IStudent". There are four methods on this interface (AddTwoNumbers, SubtractTwoNumbers, MultiplyTwoNumbers, DivideTwoNumbers).

Implementations of this interface are expected to use an injected ICalculator dependency to perform these mathematical operations, and then use another injected dependency (IResultService) to log the result (or, if there is an exception, to log that).

We assume that the injected instances of ICalculator and IResultService have been tested, so the system under test here is our implementation of IStudent.

Actually, there are two supplied implementations: GoodStudent and BadStudent. Guess which one is a good implementation of IStudent? :-)

If you look at the unit tests, you'll see how Moq is used to create mocked implementations of ICalculator and IResultService, thus supplying us with opportunities to observe and verify the behavior of the IStudent implementation.

These mocked implementations are then used to create either a GoodStudent or a BadStudent, and then the unit tests exercise the four IStudent methods.

The unit tests verify not only that the correct methods on ICalculator and IResultService were called, but also that they were called with the correct parameters and the correct number of times.
