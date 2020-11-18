using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImportPanelScript : MonoBehaviour
{
    public TMP_InputField folderInputField;
    public TMP_Text currentFolderText;
    public GameObject applyButton;
    private string path = @"D:\Git Repository\CT Data";

    // Start is called before the first frame update
    void Start()
    {
        currentFolderText.text = "Current Data Folder: " + path;
    }

    public void ChooseDataFolder()
    {
        if (!applyButton.activeSelf)
        {
            applyButton.SetActive(true);
        }
        if (!folderInputField.gameObject.activeSelf)
        {
            folderInputField.gameObject.SetActive(true);
        }
    }

    public void ChangeDataFolder()
    {
        if (folderInputField.text != "")
        {
            path = folderInputField.text;
        }
        currentFolderText.text = "Current Data Folder: " + path;
        applyButton.SetActive(false);
        folderInputField.gameObject.SetActive(false);
    }

    public string GetPath()
    {
        if (path == null)
        {
            Debug.LogError("Path is null");
        }
        return path;
    }
}

