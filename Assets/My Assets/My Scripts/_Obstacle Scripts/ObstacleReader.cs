using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace UnityStandardAssets._2D
{
    public class ObstacleReader : MonoBehaviour
    {
        public string filePath = Path.Combine(Application.streamingAssetsPath, "obstacles.txt");
        public string result = "";
        IEnumerator Example()
        {
            if (filePath.Contains("://"))
            {
                UnityWebRequest www = UnityWebRequest.Get(filePath);
                yield return www.SendWebRequest();
                result = www.downloadHandler.text;
                GetDictionary(result);
            }
            else
                result = File.ReadAllText(filePath);
        }

        public static Dictionary<String, String[]> GetDictionary(string obstacleFile)
		{
            string line;
            String[] tempKeyValuePair = new String[5];
            Dictionary<String, String[]> wordsDictionary = new Dictionary<String, String[]>();

            // the location of the "obstacles.txt" file
            //string fileLocation = Application.dataPath + @"/Data/obstacles.txt"; // only works on local

            // Read the file line-by-line
            StringReader file = new StringReader(obstacleFile);

            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    tempKeyValuePair = line.Split(':');
                    // add key (obstacle) and value (solution) to the dictionary.
                    // (WARNING: Will override value if duplicate key is used to add to dictionary)
                    wordsDictionary.Add(tempKeyValuePair[0], new String[] { tempKeyValuePair[1] });
                }
                catch (KeyNotFoundException)
                {
                    Debug.Log("KeyNotFoundException: Failed to add the key to the dictionary. (ObstacleReader)");
                    if (tempKeyValuePair.Length == 0)
                    {
                        Debug.Log("tempKeyValuePair is empty. (ObstacleReader)");
                    }
                }
            }

            file.Close();
			if(wordsDictionary == null)
			{
				Debug.Log("Returned null dictionary");
			}

			return wordsDictionary;
		}
	}
}
