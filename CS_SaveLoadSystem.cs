using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class sSystem
{
	public static CS_DataManager dManager = GameObject.FindWithTag("dManager").GetComponent<CS_DataManager>();

	public static void SaveGame (CS_DataManager dManager)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/UnitySoldiers.sav";

		FileStream stream = new FileStream(path, FileMode.Create);

		CS_GameData data = new CS_GameData(dManager);
		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static CS_GameData LoadGame ()
	{
		string path = Application.persistentDataPath + "/UnitySoldiers.sav";
		if(File.Exists(path))
		{
			dManager.saved = true;
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			CS_GameData data = formatter.Deserialize(stream) as CS_GameData;
			stream.Close();

			return data;
		} else {
			Debug.Log("ERROR: No Save File Found");
			return null;
		}
	}
}
