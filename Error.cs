using System;

public class ErrorHandlingService
{
    public void HandleError(Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
        // Vous pouvez ajouter d'autres actions ici, comme l'enregistrement des erreurs dans un fichier.
    }
}

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