using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class QuickProjectInit : ScriptableWizard
{
    public bool UseProjectName = false;
    public bool IncludeSubFolders = false;
    public bool ImportQOLPackages = false;
    public List<string> customPackages;
    private string basePathName;
    public Dictionary<string, List<string>> folders = new Dictionary<string, List<string>>()
    {
        {"Assets", new List<string>() { } },
        {"Art", new List<string>() { "Models", "Materials", "Textures" } },
        {"Prefabs", new List<string>() { "UI" } },
        {"Scripts", new List<string>() { "UI" } },
        {"Audio", new List<string>() { "SFX", "Music" } },
    };
    [MenuItem("Tools/Quick Init Project")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Quick Initialize Project", typeof(QuickProjectInit), "Initialize");
    }

    void OnEnable()
    {

    }

    void OnWizardCreate()
    {
        //create the base folder with the project name if enabled
        if (UseProjectName) {
            if (!AssetDatabase.IsValidFolder($"Assets/{Application.dataPath}"))
            {
                string guid = AssetDatabase.CreateFolder("Assets", Application.productName);
                string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
                basePathName = Application.productName;
            }
            else return;
        } else
        {
            if (!AssetDatabase.IsValidFolder($"Assets/Game"))
            {
                string guid = AssetDatabase.CreateFolder("Assets", "Game");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
                basePathName = "Game";
            }
            else return;
        }

        // create folders for the project in the basepath
        foreach (string folder in folders.Keys)
        {
            string guid = AssetDatabase.CreateFolder($"Assets/{basePathName}", folder);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

            // if subfolders are enabled create them with the base and folder path 
            if (IncludeSubFolders)
            {
                foreach (string subfolder in folders[folder])
                {
                    string sguid = AssetDatabase.CreateFolder($"Assets/{basePathName}/{folder}", subfolder);
                    string newSubFolderPath = AssetDatabase.GUIDToAssetPath(guid);
                }
            }
        }

        AssetDatabase.Refresh();

        if (ImportQOLPackages)
            UpdateManifest();
    }

    // Update manifest.json file in the packages folder
    void UpdateManifest()
    {
        Console.Write(Application.dataPath);
    }
}
