using System.Text;

namespace Enigma_CLI
{
	/// <summary>
	/// This class represents the utilisation of Enigma machine.
	/// </summary>
	public class EnigmaMachine
	{
		private readonly Plugboard _plugboard;
		private readonly Rotor[] _rotors;
		private readonly Reflector _reflector;

		public EnigmaMachine(Plugboard plugboard, Rotor[] rotors, Reflector reflector)
		{
			this._plugboard = plugboard;
			this._rotors = rotors;
			this._reflector = reflector;
		}

		public string Encrypt(string plainText)
		{
			StringBuilder result = new StringBuilder();

			foreach (char letter in plainText)
			{
				if (char.IsWhiteSpace(letter))
				{
					result.Append(letter);
					continue;
				}

				if (!char.IsLetter(letter))
					continue;

				RotateRotors();

				char output = _plugboard.Substitution(letter);
				output = ProcessWithRotors(output, true);
				output = _reflector.Reflect(output);
				output = ProcessWithRotors(output, false);
				output = _plugboard.Substitution(output);

				result.Append(output);
			}

			return result.ToString();
		}

		private void RotateRotors()
		{
			bool rotateNext = true;

			for (int i = _rotors.Length - 1; i >= 0; i--)
			{
				if (rotateNext)
				{
					rotateNext = _rotors[i].Rotate();
				}
				else
				{
					break;
				}
			}
		}

		private char ProcessWithRotors(char letter, bool forward)
		{
			char output = letter;

			if (forward)
			{
				for (int i = _rotors.Length - 1; i >= 0; i--)
				{
					output = _rotors[i].Process(output, forward);
				}
			}
			else
			{
				for (int i = 0; i < _rotors.Length; i++)
				{
					output = _rotors[i].Process(output, forward);
				}
			}

			return output;
		}
	}
}
