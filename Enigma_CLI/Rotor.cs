namespace Enigma_CLI
{
	/// <summary>
	/// This class represents the rotor of the Enigma machine.
	/// </summary>
	public class Rotor
	{
		private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private readonly string _conf;
		private readonly char _notch;
		private char _position;
		private readonly int _ringSetting;

		private static readonly Dictionary<string, (string conf, char notch)> _configurations = new Dictionary<string, (string conf, char notch)>()
		{
			["I"] = ("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q'), // Rotor I Model Enigma I
			["II"] = ("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E'), // Rotor II Model Enigma I
			["III"] = ("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V') // Rotor III Model Enigma I
		};

		public Rotor(string key, int ringSetting, char position)
		{
			/*if (!_configurations.ContainsKey(key))
				throw new ArgumentException($"Invalid rotor key: {key}");*/

			this._conf = _configurations[key].conf;
			this._notch = _configurations[key].notch;
			this._position = position;
			this._ringSetting = ringSetting;
		}

		public bool Rotate()
		{
			_position = _alphabet[(_alphabet.IndexOf(_position) + 1) % _alphabet.Length];
			return _position == _notch;
		}

		public char Encrypt(char letter, bool forward)
		{
			letter = char.ToUpper(letter);
			if (!_alphabet.Contains(letter))
				return letter;

			int offset = _alphabet.IndexOf(_position) - (_ringSetting - 1);
			int letterIndex = _alphabet.IndexOf(letter);

			if (forward)
			{
				// Passage avant
				int inputPos = (letterIndex + offset + _alphabet.Length) % _alphabet.Length;
				char wiredChar = _conf[inputPos];
				int outputPos = (_alphabet.IndexOf(wiredChar) - offset + _alphabet.Length) % _alphabet.Length;
				return _alphabet[outputPos];
			}
			else
			{
				// Passage inverse
				int inputPos = (letterIndex + offset + _alphabet.Length) % _alphabet.Length;
				int wiredPos = _conf.IndexOf(_alphabet[inputPos]);
				int outputPos = (wiredPos - offset + _alphabet.Length) % _alphabet.Length;
				return _alphabet[outputPos];
			}
			/*int offset = _alphabet.IndexOf(_position) - (_ringSetting - 1);

			if (forward)
			{
				int index = (_alphabet.IndexOf(letter) + offset) % _alphabet.Length;
				return _alphabet[(_alphabet.IndexOf(_conf[index]) - offset + _alphabet.Length) % _alphabet.Length];
			}
			else
			{
				int index = (_alphabet.IndexOf(letter) + offset) % _alphabet.Length;
				return _alphabet[(_conf.IndexOf(_alphabet[index]) - offset + _alphabet.Length) % _alphabet.Length];
			}*/
		}
	}
}