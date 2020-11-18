using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneImagesScript : MonoBehaviour
{
    private FrameImageScript[] children;

    void Start()
    {
        children = GetComponentsInChildren<FrameImageScript>();
    }

    //Меняет изображение у всех дочерних изображений
    public void OnValueChangedRenderDropdown()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].ChangeImageRender();
        }
    }
}
