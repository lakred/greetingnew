namespace Greeting.Test
{
    public class GreetingTest
    {
        private readonly Greeting _sut;
        public GreetingTest()
        {
            _sut = new Greeting();
        }
        [Fact]
        public void SimpleGreet()
        {
            var result= _sut.Greet("Bob");
            Assert.Equal("Hello, Bob.", result);
        }
        [Fact]
        public void EmptyGreet()
        {
            var result = _sut.Greet(null);
            Assert.Equal("Hello, my friend.", result);
        }
        [Fact]
        public void UpperGreet()
        {
            var result = _sut.Greet("JERRY");
            Assert.Equal("HELLO, JERRY!", result);
        }
        [Fact]
        public void TwoNamesGreet()
        {
            var result = _sut.Greet("Jill", "Jane");
            Assert.Equal("Hello, Jill and Jane.", result);
        }
            [Fact]
        public void MoreNamesGreet()
        {
            var result = _sut.Greet("Amy", "Brian", "Charlotte");
            Assert.Equal("Hello, Amy, Brian, and Charlotte.", result);
        }
        [Fact]
        public void MixedGreet()
        {
            var result = _sut.Greet("Amy", "BRIAN", "Charlotte");
            Assert.Equal("Hello, Amy and Charlotte. AND HELLO BRIAN!", result);
        }
        [Fact]
        public void SplitGreet()
        {
            var result = _sut.Greet("Bob", "Charlie, Dianne");
            Assert.Equal("Hello, Bob, Charlie, and Dianne.", result);
        }
    }
}