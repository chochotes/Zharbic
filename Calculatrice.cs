using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public static class Calculator
    {
        public static void Calcul(string expression)
        {
            try
            {
                int resultat = EvaluerCalcul(expression);
                Console.WriteLine($"Résultat : {resultat}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        private static int EvaluerCalcul(string expression)
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
                    EvaluerOperateur(element, stack);
                }
            }

            VerifierResultatFinal(stack);

            return stack.Pop();
        }

        private static void EvaluerOperateur(string operateur, Stack<int> stack)
        {
            if (stack.Count < 2)
                throw new InvalidOperationException("Erreur de syntaxe : opération impossible");

            int operand2 = stack.Pop();
            int operand1 = stack.Pop();

            switch (operateur)
            {
                case "+":
                    stack.Push(operand1 + operand2);
                    break;
                case "-":
                    stack.Push(operand1 - operand2);
                    break;
                case "*":
                    stack.Push(operand1 * operand2);
                    break;
                case "/":
                    EvaluerDivision(operand2, stack, operand1);
                    break;
                default:
                    throw new InvalidOperationException($"Erreur : opérateur inconnu '{operateur}'");
            }
        }

        private static void EvaluerDivision(int operand2, Stack<int> stack, int operand1)
        {
            if (operand2 == 0)
                throw new InvalidOperationException("Erreur : division par zéro");

            stack.Push(operand1 / operand2);
        }

        private static void VerifierResultatFinal(Stack<int> stack)
        {
            if (stack.Count != 1)
                throw new InvalidOperationException("Erreur de syntaxe : opération impossible");
        }
    }
}
