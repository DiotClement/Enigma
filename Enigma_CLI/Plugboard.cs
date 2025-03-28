namespace Enigma_CLI
{
	/// <summary>
	/// This class represents the plugboard of the Enigma machine.
	/// </summary>
	public class Plugboard
	{
		private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private Dictionary<char, char> _connections = new Dictionary<char, char>();

		public void AddConnection(char letter1, char letter2)
		{
			letter1 = char.ToUpper(letter1);
			letter2 = char.ToUpper(letter2);

			if (letter1 == letter2 || !_alphabet.Contains(letter1) || !_alphabet.Contains(letter2))
			{
				throw new ArgumentException("Invalid connection.");
			}

			_connections[letter1] = letter2;
			_connections[letter2] = letter1;
		}

		public char Substitution(char letter)
		{
			letter = char.ToUpper(letter);
			return _connections.TryGetValue(letter, out char result) ? result : letter;
		}
	}
}