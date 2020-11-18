using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public FrameImageScript[] frameImages;

    public void CreateFilteredLists()
    {
        for (int i =0; i< frameImages.Length;i++)
        {
            frameImages[i].CreateFilteredList();
        }
    }
}
