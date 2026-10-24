using System.Numerics;
 
 namespace Lab11;
 
 public class Calculator<T> where T : INumber<T>
 {
     // public Calculator()
     // {
     //     Type type = typeof(T);
     //
     //     if (type != typeof(int) &&
     //         type != typeof(float) &&
     //         type != typeof(double) &&
     //         type != typeof(decimal))
     //     {
     //         throw new NotSupportedException(
     //             $"Type {type.Name} is not supported.");
     //     }
     // }
     
     public T Add(T a, T b)
     {
         return a + b;
     }
 
     public T Subtract(T a, T b)
     {
         return a - b;
     }
 
     public T Multiply(T a, T b)
     {
         return a * b;
     }
 
     public T Divide(T a, T b)
     {
         if (b == T.Zero)
             throw new DivideByZeroException();
 
         return a / b;
     }
 
     public T Pow(T number, int exponent)
     {
         if (exponent == 0)
             return T.One;
 
         if (exponent < 0)
         {
             if (number == T.Zero)
                 throw new DivideByZeroException();
 
             T positiveResult = Pow(number, -(long)exponent);
             return T.One / positiveResult;
         }
 
         T result = T.One;
 
         for (long i = 0; i < exponent; i++)
         {
             result *= number;
         }
 
         return result;
     }
 
     private T Pow(T number, long exponent)
     {
         T result = T.One;
 
         for (long i = 0; i < exponent; i++)
         {
             result *= number;
         }
 
         return result;
     }
 }