using UnityEngine;

// A static class (never attached to an object). Holds the gem count and the saved record.
public static class RunState
{
    const string RecordKey = "TopChicken";

    public static int Chickens;

    public static int Record
    {
        get { return PlayerPrefs.GetInt(RecordKey, 0); }
    }

    public static void Reset()
    {
        Chickens = 0;
    }

    public static void StoreRecord()
    {
        if (Chickens > Record)
        {
            PlayerPrefs.SetInt(RecordKey, Chickens);
            PlayerPrefs.Save();
            Debug.Log("New record stored: " + Chickens);
        }
    }
}
