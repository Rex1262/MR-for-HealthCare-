using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownScript : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void CreateOptions()
    {
        TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
        TMP_Dropdown.OptionData newData2 = new TMP_Dropdown.OptionData();
        TMP_Dropdown.OptionData newData3 = new TMP_Dropdown.OptionData();
        TMP_Dropdown.OptionData newData4 = new TMP_Dropdown.OptionData();

        newData.text = "Coronal";
        dropdown.options.Add(newData);
        newData2.text = "Sagittal";
        dropdown.options.Add(newData2);
        newData3.text = "Axial";
        dropdown.options.Add(newData3);
        newData4.text = "Other";
        dropdown.options.Add(newData4);
    }
}
