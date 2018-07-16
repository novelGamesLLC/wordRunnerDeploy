using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class DictionaryReader : MonoBehaviour
	{
		// key is the obstacle (a string). The value(s) can be an array of strings
		public Dictionary<String, String> definitionDictionary;

		public Dictionary<String, String> getDictionary()
		{
            string line;
            String[] tempKeyValuePair;
            definitionDictionary = new Dictionary<String, String>();

            // the location of the "dictionary.txt" file
            TextAsset fileLocation = (TextAsset)Resources.Load("dictionary", typeof(TextAsset));

            // Read the file line-by-line
            StringReader file = new StringReader(fileLocation.text);
            while ((line = file.ReadLine()) != null)
            {
                tempKeyValuePair = line.Split(':');
                // add key (solution) and value (definition) to the dictionary.
                // (WARNING: Will override value if duplicate key is used to add to dictionary)
                definitionDictionary.Add(tempKeyValuePair[0], tempKeyValuePair[1]);
            }

            file.Close();
            
			if(definitionDictionary == null)
			{
				Debug.LogWarning("Returned null dictionary");
			}

			return definitionDictionary;
		}
	}
}
