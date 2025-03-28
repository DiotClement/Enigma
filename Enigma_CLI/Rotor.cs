using System;

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
		private char _ringSetting;

		private static readonly Dictionary<string, (string conf, char notch)> _rotorConfigurations = new Dictionary<string, (string conf, char notch)>()
		{
			["I"] = ("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q'), // Rotor I Model Enigma I
			["II"] = ("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E'), // Rotor II Model Enigma I
			["III"] = ("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V') // Rotor III Model Enigma I
		};

		public Rotor(string key, char ringSetting, char position)
		{
			this._conf = _rotorConfigurations[key].conf;
			this._notch = _rotorConfigurations[key].notch;
			this._ringSetting = ringSetting;
			this._position = position;
		}

		public bool Rotate()
		{
			_position = _alphabet[(_alphabet.IndexOf(_position) + 1) % _alphabet.Length];
			return _position == _notch;
		}

		public char Process(char letter, bool forward)
		{
			int indexPosition = _alphabet.IndexOf(_position);
			int indexRing = _alphabet.IndexOf(_ringSetting);
			int effectiveShift = indexPosition - indexRing;

			if (forward)
			{
				int inputIndex = (_alphabet.IndexOf(letter) + effectiveShift + _alphabet.Length) % _alphabet.Length;
				char outputChar = _conf[inputIndex];
				int outputIndex = (_alphabet.IndexOf(outputChar) - effectiveShift + _alphabet.Length) % _alphabet.Length;
				return _alphabet[outputIndex];
			}
			else
			{
				int inputIndex = (_alphabet.IndexOf(letter) + effectiveShift + _alphabet.Length) % _alphabet.Length;
				int outputIndex = (_conf.IndexOf(_alphabet[inputIndex]) - effectiveShift + _alphabet.Length) % _alphabet.Length;
				return _alphabet[outputIndex];
			}
		}
	}
}