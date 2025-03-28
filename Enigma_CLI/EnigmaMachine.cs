using System.Text;

namespace Enigma_CLI
{
	/// <summary>
	/// This class represents the utilisation of Enigma machine.
	/// </summary>
	public class EnigmaMachine
	{
		private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

			foreach (char letter in plainText.ToUpper())
			{
				if (_alphabet.Contains(letter))
				{
					bool rotateNext = true;
					for (int i = 0; i < _rotors.Length && rotateNext; i++)
					{
						rotateNext = _rotors[i].Rotate();
					}

					char output = _plugboard.Substitution(letter);
					
					for (int i = _rotors.Length - 1; i >= 0; i--)
					{
						output = _rotors[i].Encrypt(output, true);
					}

					output = _reflector.Reflect(output);

					for (int i = 0; i < _rotors.Length; i++)
					{
						output = _rotors[i].Encrypt(output, false);
					}

					output = _plugboard.Substitution(output);
					result.Append(output);
				}
				else
				{
					result.Append(letter);
				}
			}
			return result.ToString();
		}
	}
}
