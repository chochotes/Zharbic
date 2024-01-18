using System;

class Program
{
    static void Main()
    {
        try
        {
            string expression = "2 3 5 + ";
            int result = EvaluerExpression(expression);
            Console.WriteLine($"R�sultat : {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }

    static int EvaluerExpression(string expression)
    {
        string[] elements = expression.Split(' ');
        Stack<int> stack = new Stack<int>();

        foreach (string element in elements)
        {
            if (int.TryParse(element, out int nombre))
            {
                stack.Push(nombre);
            }
            else
            {
                if (stack.Count < 2)
                    throw new InvalidOperationException("Erreur de syntaxe : op�ration impossible");

                int operand2 = stack.Pop();
                int operand1 = stack.Pop();

                switch (element)
                {
                    case "+":
                        stack.Push(operand1 + operand2);
                        break;
                    case "-":
                        stack.Push(operand1 - operand2);
                        break;
                    case "":
                        stack.Push(operand1 * operand2);
                        break;
                    case "/":
                        if (operand2 == 0)
                            throw new InvalidOperationException("Erreur : division par z�ro");
                        stack.Push(operand1 / operand2);
                        break;
                    default:
                        throw new InvalidOperationException($"Erreur : op�rateur inconnu '{element}'");
                }
            }
        }

        if (stack.Count != 1)
            throw new InvalidOperationException("Erreur de syntaxe : op�ration impossible");

        return stack.Pop();
    }
}