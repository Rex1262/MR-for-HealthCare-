using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FrameImageScript : MonoBehaviour

{
    private bool dropdownValueChanged = true;
    private List<Texture2D> textureList = new List<Texture2D>();

    public RawImage image;
    public TMP_Dropdown renderingDropdownComponent;
    public TMP_Dropdown dropdownComponent;
    public TMP_Text mergingImagesNumber;
    public GameObject dropdown;
    public DICOMImporter dicomImporter;
    public Slider imageSlider;
    public Slider renderSlider;
    public GridViewScript gridObject;

    // Start is called before the first frame update
    private void Start()
    {
        renderingDropdownComponent = GameObject.Find("RendererDropdown").GetComponent<TMP_Dropdown>();
        dropdownComponent = GetComponentInChildren<TMP_Dropdown>();
        image = GetComponent<RawImage>();
        

        if (dropdownComponent == null)
        {
            Debug.LogError("Dropdown is null");
        }
        if (image==null)
        {
            Debug.LogError("Image is null");
        }
        if (renderingDropdownComponent == null)
        {
            Debug.LogError("Rendering Dropdown is null");
        }
        if (imageSlider==null)
        {
            Debug.LogError("Image Slider is null");
        }

    }

    public void ChangeImageRender()
    {
        if (imageSlider.value!=0)
        {
            if (renderingDropdownComponent.value!=0 && renderSlider.value != 0)
            {
                if (mergingImagesNumber!=null)
                    mergingImagesNumber.text = renderSlider.value.ToString();
                
                image.texture = RenderManager.GetTexture((int)imageSlider.value-1, (int)renderSlider.value, textureList, renderingDropdownComponent.value);
            }
            else
            {
                image.texture = textureList[(int)imageSlider.value - 1];
            }
        }
    }

    

    public void FilterChange() //Смена фильтра
    {
        if (dropdownComponent == null)
        {
            Debug.LogError("DropdownComponent is null");
        }
        if (dropdownValueChanged)
        {
            CreateFilteredList();
            ChangeImageRender();
            imageSlider.value = 1;
        }
    }

    public void OnValueChangedImageDropdown()//Функция для Image Slider
    {
        if (!dropdownValueChanged)
        {
            dropdownValueChanged = true;
        }
        FilterChange();
    }

    public void OnValueChangedRenderSlider()//функция для RenderSlider
    {
        if (imageSlider.value != 0)
        {
            if (renderingDropdownComponent.value != 0 && renderSlider.value != 0)
            {
                image.texture = RenderManager.GetTexture((int)imageSlider.value-1, (int)renderSlider.value-1, textureList, renderingDropdownComponent.value);
            }
        }
    }

    public void CreateFilteredList()// Перезапись листа 
    {
        textureList.Clear();
        var newTextureList = new List<Texture2D>();
        newTextureList = dicomImporter.ChangeList(dropdownComponent);
        textureList = newTextureList;
        imageSlider.maxValue = textureList.Count;
        renderSlider.maxValue = textureList.Count;
        imageSlider.minValue = 1;
        renderSlider.minValue = 1;
        if (gridObject!=null)
        {
            gridObject.CreateImagesGrid(textureList);
        }
        else
        {
            Debug.LogError("GridObject is null");
        }
        dropdownValueChanged = false;
    }

    private void ChangeTexture()
    {
            image.texture = RenderManager.GetTexture((int)imageSlider.value - 1, (int)renderSlider.value - 1, textureList, renderingDropdownComponent.value);  
    }

}
