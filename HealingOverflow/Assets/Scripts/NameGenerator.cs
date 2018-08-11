using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class NameGenerator{

	private static float charProbability = 0.3f;
	private static float numProbability = 0.7f;
	private static string[] words = {
		"Dark",
		"Master",
		"Mage",
		"YourMom",
		"Pony",
		"Sonic",
		"Soul",
		"Warrior",
		"Rogue",
		"Orc",
		"Chosen",
		"Pwner",
		"Killer",
		"Destroyer",
		"Overlord",
		"Boss",
		"Noob",
		"Loser",
		"Girl",
		"Gamer",
		"Super",
		"Mega",
		"Giga",
		"Hell",
		"Heaven",
		"Basement",
		"Nobody"
	};

	private static string[,] specialCharacters =  {
		{"Xx", "xX"},
		{"xX", "Xx"},
		{"_", "_"},	
		{"<", ">"}
	};

	private static Dictionary<char, char> letterToNumber = new Dictionary<char, char>() {
		{'a', '4'},
		{'e','3'},
		{'l', '1'},
		{'i', '1'},
		{'s', '5'},
		{'b', '8'},
		{'o', '0'},
		{'z', '2'}
	};

	public static string GenerateUsername()
	{
		bool specialChar;
		System.Text.StringBuilder username = new System.Text.StringBuilder();
		float rand = Random.Range(0,1.00f);
		int specialRand = Random.Range(0,3);

		if(rand <= charProbability)
			specialChar = true;
		else
			specialChar = false;

		username.Append(words[Random.Range(0, words.Length)]);
		username.Append(words[Random.Range(0, words.Length)]);

		char newChr;

		for(int i = 0; i < username.Length; i++)
		{
			if(letterToNumber.TryGetValue(System.Char.ToLower(username[i]), out newChr) && Random.Range(0f,1.00f) <= numProbability)
				username[i] = newChr;
		}

		if(specialChar)
		{
			username.Insert(0, specialCharacters[specialRand,0]);
			username.Append(specialCharacters[specialRand,1]);
		}

		return username.ToString();
	}
}
