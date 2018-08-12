using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class NameGenerator{

	private static float charProbability = 0.3f;
	private static float numProbability = 0.5f;
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
		"Hell",
		"Heaven",
		"Basement",
		"Nobody"
	};

	private static string[] reports = {
		"support noob didnt heal",
		"FUCKING SHITHEAD REFUSES TO HEAL ME",
		"Report this fkin cleric, if you're not healing don't pick lol",
		"OMEGALUL picks cleric and doesn't heal",
		"Hey, healer: Alt+F4 heals, in case you don´t know",
		"try to heal your mom after I bang her",
		"lol wat a fkin noob",
		"such a good healer kappa",
		"report this useless healer",
		"healer is so easy and this guy still sucks lol",
		"ff, healer throwing the game",
		"BR?",
		"HIJO DE MIERDA",
		"fucking 9 year old"
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

	public static string GenerateChat(int amount)
	{
		System.Text.StringBuilder chat = new System.Text.StringBuilder();
		List<int> usedIndexes = new List<int>();
		int currentIndex = Random.Range(0, reports.Length);
		for(int i = 0; i < amount; i++)
		{
			while(usedIndexes.Contains(currentIndex))
				currentIndex = Random.Range(0, reports.Length);

			usedIndexes.Add(currentIndex);
			chat.Append("[" + GenerateUsername() + "]: ");
			chat.AppendLine(reports[currentIndex]);
		}
		return chat.ToString();
	}
}
