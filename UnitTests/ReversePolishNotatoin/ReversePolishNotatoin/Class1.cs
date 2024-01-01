using System;
using System.Collections.Generic;

public class RPNCalculator
{
    public static double EvaluateRPN(string expression)
    {
        Stack<double> stack = new Stack<double>();

        string[] tokens = expression.Split(' ');

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double operand))
            {
                // If the token is a number, push it onto the stack
                stack.Push(operand);
            }
            else if (IsOperator(token))
            {
                // If the token is an operator, pop operands, perform the operation, and push the result back
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                double result = PerformOperation(token, operand1, operand2);
                stack.Push(result);
            }
            else
            {
                throw new ArgumentException("Invalid token: " + token);
            }
        }

        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression");
        }
    }

    private static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    private static double PerformOperation(string operation, double operand1, double operand2)
    {
        switch (operation)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0)
                    throw new DivideByZeroException("Cannot divide by zero");
                return operand1 / operand2;
            default:
                throw new ArgumentException("Invalid operation: " + operation);
        }
    }
}