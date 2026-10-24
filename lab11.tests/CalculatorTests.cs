namespace Lab11.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator<int> _intCalc = null!;
    private Calculator<double> _doubleCalc = null!;
    private Calculator<decimal> _decimalCalc = null!;
    private Calculator<float> _floatCalc = null!;

    [SetUp]
    public void Setup()
    {
        _intCalc = new Calculator<int>();
        _doubleCalc = new Calculator<double>();
        _decimalCalc = new Calculator<decimal>();
        _floatCalc = new Calculator<float>();
    }

    [Test]
    public void Add_ReturnsSum()
    {
        Assert.That(_intCalc.Add(2, 3), Is.EqualTo(5));
        Assert.That(_doubleCalc.Add(2.5, 3.5), Is.EqualTo(6.0));
        Assert.That(_decimalCalc.Add(2.5m, 3.5m), Is.EqualTo(6.0m));
        Assert.That(_floatCalc.Add(2.5f, 3.5f), Is.EqualTo(6.0f));
    }

    [Test]
    public void Subtract_ReturnsDifference()
    {
        Assert.That(_intCalc.Subtract(5, 3), Is.EqualTo(2));
        Assert.That(_doubleCalc.Subtract(5.5, 2.5), Is.EqualTo(3.0));
        Assert.That(_decimalCalc.Subtract(5.5m, 2.5m), Is.EqualTo(3.0m));
        Assert.That(_floatCalc.Subtract(5.5f, 2.5f), Is.EqualTo(3.0f));
    }

    [Test]
    public void Multiply_ReturnsProduct()
    {
        Assert.That(_intCalc.Multiply(2, 3), Is.EqualTo(6));
        Assert.That(_doubleCalc.Multiply(2.5, 2.0), Is.EqualTo(5.0));
        Assert.That(_decimalCalc.Multiply(2.5m, 2.0m), Is.EqualTo(5.0m));
        Assert.That(_floatCalc.Multiply(2.5f, 2.0f), Is.EqualTo(5.0f));
    }

    [Test]
    public void Divide_ReturnsQuotient()
    {
        Assert.That(_intCalc.Divide(6, 3), Is.EqualTo(2));
        Assert.That(_doubleCalc.Divide(5.0, 2.0), Is.EqualTo(2.5));
        Assert.That(_decimalCalc.Divide(5.0m, 2.0m), Is.EqualTo(2.5m));
        Assert.That(_floatCalc.Divide(5.0f, 2.0f), Is.EqualTo(2.5f));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(
            () => _intCalc.Divide(5, 0));

        Assert.Throws<DivideByZeroException>(
            () => _doubleCalc.Divide(5.0, 0.0));

        Assert.Throws<DivideByZeroException>(
            () => _decimalCalc.Divide(5.0m, 0.0m));

        Assert.Throws<DivideByZeroException>(
            () => _floatCalc.Divide(5.0f, 0.0f));
    }

    [Test]
    public void Pow_ReturnsPower()
    {
        Assert.That(_intCalc.Pow(2, 3), Is.EqualTo(8));
        Assert.That(_doubleCalc.Pow(2.0, 3), Is.EqualTo(8.0));
        Assert.That(_decimalCalc.Pow(2.0m, 3), Is.EqualTo(8.0m));
        Assert.That(_floatCalc.Pow(2.0f, 3), Is.EqualTo(8.0f));
    }

    [Test]
    public void Pow_ZeroExponent_ReturnsOne()
    {
        Assert.That(_intCalc.Pow(5, 0), Is.EqualTo(1));
        Assert.That(_doubleCalc.Pow(5.0, 0), Is.EqualTo(1.0));
        Assert.That(_decimalCalc.Pow(5.0m, 0), Is.EqualTo(1.0m));
        Assert.That(_floatCalc.Pow(5.0f, 0), Is.EqualTo(1.0f));
    }

    [Test]
    public void Pow_NegativeExponent_ReturnsReciprocal()
    {
        Assert.That(_doubleCalc.Pow(2.0, -2), Is.EqualTo(0.25));
        Assert.That(_decimalCalc.Pow(2.0m, -2), Is.EqualTo(0.25m));
        Assert.That(_floatCalc.Pow(2.0f, -2), Is.EqualTo(0.25f));
    }
}