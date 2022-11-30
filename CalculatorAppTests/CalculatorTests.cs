namespace CalculatorAppTests;

public class CalculatorTests
{
    // Max()
    // Sum (n1, n2, n3, n4, n5, n6)
    // Sum (new int[]{1, 2, 3, 4})
    // Divide (n1, n2) Dica: Criar um novo tipo de exceção
    // IsPrime (n1)
    // Subtract (n1, n2)

    [Fact] // marca o método sobre o qual vai correr o teste
    public void Sum_Two_Numbers_Success()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Sum(12, 23);
        var expected = 12 + 23;

        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(12, 23, 35)]
    [InlineData(-10, 2, -8)]
    [InlineData(2, 3, 5)]
    [InlineData(-20, 20, 0)]
    [InlineData(100, 123, 223)]
    public void Sum_Numbers_Success(int n1, int n2, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Sum(n1, n2);

        //Assert
        Assert.Equal(expected, result);
    }

    // Sum (new int[]{1, 2, 3, 4})
    [Theory]
    [InlineData(10, 1, 2, 3, 4)]
    public void Sum_Collection_Numbers_Success(int expected, params int[] numbers)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Sum(numbers);
       
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3, 6, 9)]
    public void Subtract_Two_Numbers_Success(int expected, int n1, int n2)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Subtract(n2, n1);
        
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(8, 4, 8)]
    public void Max_Number_Success(int expected, int n1, int n2)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Max(n1, n2);
       
        //Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(true, 5)]
    public void Is_Prime_Success(bool expected, int n1)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Prime(n1);

        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    public void Division_Number_Success(int n1, int n2, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Division(n1, n2);

        //Assert
        Assert.Equal(expected, result);
    }


}