namespace Enigma_CLI
{
	/// <summary>
	/// This class represents the plugboard of the Enigma machine.
	/// </summary>
	public class Plugboard
	{
		private readonly Dictionary<char, char> _connections = new Dictionary<char, char>();

		public void AddConnection(char letter1, char letter2)
		{
			if (letter1 == letter2 || !char.IsLetter(letter1) || !char.IsLetter(letter2))
				throw new ArgumentException("Invalid connection (only letters A-Z are allowed and the same letter cannot be used).");

			_connections[letter1] = letter2;
			_connections[letter2] = letter1;
		}

		public char Substitution(char letter)
		{
			return _connections.TryGetValue(letter, out var output) ? output : letter;
		}
	}
}