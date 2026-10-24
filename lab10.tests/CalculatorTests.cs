namespace lab10.tests;

public class Tests
{
    private StringCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new StringCalculator();
    }

    [Test]
    public void Add_ReturnsZeroForEmptyString()
    {
        Assert.That(_calculator.Add(""),Is.EqualTo("0"));
    }

    [TestCase("1", "1")]
    [TestCase("1.1", "1.1")]
    public void Add_ReturnsItself(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }

    [TestCase("1,2", "3")]
    [TestCase("1.1,1.2", "2.3")]
    public void Add_ReturnsSum(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }
    
    [TestCase("1,2,3", "6")]
    [TestCase("1.1,1.2,1.3", "3.6")]
    public void Add_ManyNumbers_ReturnsSum(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }

    [TestCase("1\n2,3", "6")]
    public void Add_NewSeparator(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }
    
    [TestCase("175.2,\n35", "Number expected but '\\n' found at position 6.")]
    public void Add_MissingSeparator(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }
    
    [TestCase("1,3,", "Number expected but EOF found.")]
    public void Add_ReturnsErrorWhenInputEndsWithSeparator(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }

    [TestCase("//;\n1;2", "3")]
    [TestCase("//sep\n2sep3", "5")]
    [TestCase("//|\n1|2,3", "'|' expected but ',' found at position 3.")]
    public void Add_CustomDelimiter(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }

    [TestCase("-1,2", "Negative not allowed : -1")]
    [TestCase("2,-4,-5", "Negative not allowed : -4, -5")]
    public void Add_NegativeNumber_ThrowsException(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }

    [TestCase("-1,,2", "Negative not allowed : -1\nNumber expected but ',' found at position 3.")]
    public void Add_NegativeNumberAndSeparator_ThrowsException(string numbers, string expected)
    {
        Assert.That(_calculator.Add(numbers), Is.EqualTo(expected));
    }

    [TestCase("1,2,3", "6")]
    public void Add_MultipleCalls_ReturnsSum(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }
    
    [Test]
    public void Multiply_ReturnsOneForEmptyString()
    {
        Assert.That(_calculator.Multiply(""), Is.EqualTo("1"));
    }

    [TestCase("1", "1")]
    [TestCase("1.1", "1.1")]
    public void Multiply_ReturnsItself(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("2,3", "6")]
    [TestCase("1.1,1.2", "1.32")]
    public void Multiply_ReturnsProduct(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("1,2,3", "6")]
    [TestCase("1.1,1.2,1.3", "1.716")]
    public void Multiply_ManyNumbers_ReturnsProduct(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("1\n2,3", "6")]
    public void Multiply_NewSeparator(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("175.2,\n35", "Number expected but '\\n' found at position 6.")]
    public void Multiply_MissingSeparator(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("1,3,", "Number expected but EOF found.")]
    public void Multiply_ReturnsErrorWhenInputEndsWithSeparator(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("//;\n2;3", "6")]
    [TestCase("//sep\n2sep3", "6")]
    [TestCase("//|\n1|2,3", "'|' expected but ',' found at position 3.")]
    public void Multiply_CustomDelimiter(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("-1,2", "Negative not allowed : -1")]
    [TestCase("2,-4,-5", "Negative not allowed : -4, -5")]
    public void Multiply_NegativeNumber_ThrowsException(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("-1,,2", "Negative not allowed : -1\nNumber expected but ',' found at position 3.")]
    public void Multiply_NegativeNumberAndSeparator_ThrowsException(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }

    [TestCase("2,3,4", "24")]
    public void Multiply_MultipleCalls_ReturnsProduct(string numbers, string expected)
    {
        Assert.That(_calculator.Multiply(numbers), Is.EqualTo(expected));
    }
}