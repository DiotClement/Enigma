using Enigma_CLI;
using System.Text.RegularExpressions;

/// <summary>
/// This class represents the CLI of the Enigma machine.
/// </summary>
public class Program
{
	private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public static void Main(string[] args)
	{
		Console.WriteLine("---Enigma machine configuration---");

		// Rotors order configuration
		Console.WriteLine("Choose rotor order (rotors available from the Enigma I model: I, II, III)");
		string[] rotorKeys = { "I", "II", "III" };
		string[] order = new string[3];

		for (int i = 0; i < 3; i++)
		{
			string rotor;
			do
			{
				Console.Write($"Rotor {i + 1} ({(i == 0 ? "the fastest" : i == 1 ? "the intermediary" : "the slowest")}): ");
				rotor = Console.ReadLine().ToUpper();
			} while (!rotorKeys.Contains(rotor));

			order[i] = rotor;
		}

		// Rotors ring and position configurations
		Rotor[] rotorSettings = new Rotor[3];
		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine($"\nRotor {i + 1} ({(i == 0 ? "the fastest" : i == 1 ? "the intermediary" : "the slowest")})");

			char ringSetting;
			do
			{
				Console.Write($"Ring setting (A-Z): ");
				ringSetting = Console.ReadLine().ToUpper()[0];
			} while (!_alphabet.Contains(ringSetting));

			char position;
			do
			{
				Console.Write($"Initial position (A-Z): ");
				position = Console.ReadLine().ToUpper()[0];
			} while (!_alphabet.Contains(position));

			rotorSettings[i] = new Rotor(order[i], ringSetting, position);
		}

		// Plugboard configuration
		Console.WriteLine("\nPlugboard configuration (max 10 pairs, e.g. AB CD EF):");
		Plugboard plugboard = new Plugboard();

		var pairs = Console.ReadLine()?
			.ToUpper()
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Take(10)
			.Where(p => p.Length == 2 && p[0] != p[1] && _alphabet.Contains(p[0]) && _alphabet.Contains(p[1]));

		if (pairs != null)
		{
			foreach (var pair in pairs)
			{
				plugboard.AddConnection(pair[0], pair[1]);
			}
		}

		// Iniatilze Enigma machine
		EnigmaMachine enigma = new EnigmaMachine(plugboard, rotorSettings, new Reflector());

		// Encryption
		Console.WriteLine("\nEnter text to be encrypted (A to Z only):");
		string plainText = Console.ReadLine()?.ToUpper() ?? "";

		if (!Regex.IsMatch(plainText, @"^[A-Z\s]+$"))
		{
			Console.WriteLine("Only letters A-Z and spaces are allowed.");
			return;
		}

		string result = enigma.Encrypt(plainText);
		Console.WriteLine($"\nEncrypted text: {result}");
	}
}