# Enigma Model 1 Machine Simulator - CLI Version

[![C#](https://img.shields.io/badge/c%23-net8.0-8A2BE2)](https://dotnet.microsoft.com/fr-fr/download/dotnet/8.0/)

## Description 

A faithful C# implementation of the famous Enigma Model I encryption machine used during the Second World War.

## Installation

1. Clone the repository:

```bash
git clone https://github.com/DiotClement/Enigma.git
cd Enigma_CLI
```

2. Build the project:

```bash
dotnet build
```

## Usage

```bash
dotnet run
```
Follow the interactive prompts to:
1. Select rotor order (I, II, III)
2. Configure each rotor's ring setting and initial position
3. Set up plugboard connections
4. Enter text to encrypt

Example session: 
```bash
---Enigma machine configuration---
Choose rotor order (rotors available from the Enigma I model: I, II, III)
Rotor 1 (the fastest): II
Rotor 2 (the intermediary): III
Rotor 3 (the slowest): I

Rotor 1 (the fastest)
Ring setting (A-Z): E
Initial position (A-Z): E

Rotor 2 (the intermediary)
Ring setting (A-Z): B
Initial position (A-Z): A

Rotor 3 (the slowest)
Ring setting (A-Z): E
Initial position (A-Z): D

Plugboard configuration (max 10 pairs, e.g. AB CD EF):
AE OP

Enter text to be encrypted (A to Z only):
HELLO

Encrypted text: BODXP
Press Enter to exit...
```

## Documentation

For more information on how the enigma machine works, watch this video : [Enigma Machine](https://youtu.be/ybkkiGtJmkM?t=496)