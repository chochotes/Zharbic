public class CalculInputService
{
    public string GetUserInput()
    {
        Console.Write("Veuillez saisir la chaîne de calcul : ");
        string input = Console.ReadLine();

        // Validation basique pour s'assurer que la saisie n'est pas vide
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new InvalidOperationException("Erreur : la saisie ne peut pas être vide.");
        }

        return input;
    }
}