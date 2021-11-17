using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FBPPConfig 
{
    private const string DEFAULT_SAVE_FILE_NAME = "saveData.txt";
    private const string DEFAULT_ENCRYPTION_SECRET = "encryption-secret-default";

    public string SaveFileName = DEFAULT_SAVE_FILE_NAME;

    public bool AutoSaveData = true;

    public bool ScrambleSaveData = true;

    public string EncryptionSecret = DEFAULT_ENCRYPTION_SECRET;

    public string SaveFilePath = null;

    public UnityEvent OnLoadError = new UnityEvent();

    internal string GetSaveFilePath()
    {
        return string.IsNullOrEmpty(SaveFilePath) ? Application.persistentDataPath : SaveFilePath;
    }

}
