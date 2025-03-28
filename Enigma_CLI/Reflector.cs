namespace Enigma_CLI
{
	/// <summary>
	/// This class represents the reflector of the Enigma machine.
	/// </summary>
	public class Reflector
	{
		private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private readonly string _conf;

		public Reflector()
		{
			this._conf = "YRUHQSLDPXNGOKMIEBFZCWVJAT"; // Reflector UKW B
		}

		public char Reflect(char letter)
		{
			return _alphabet[_conf.IndexOf(letter)];
		}
	}
}