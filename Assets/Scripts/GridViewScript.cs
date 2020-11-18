using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridViewScript : MonoBehaviour
{
    public TMP_Dropdown renderingDropdownComponent;
    public Slider renderSlider;
    public Slider imageSlider;
    private List<GridImageScript> prefabList = new List<GridImageScript>();
    private List<Texture2D> newTextureList = new List<Texture2D>();
    public GridImageScript imagePrefab;
    public RawImage image;

    public void Start()
    {
        renderingDropdownComponent = GameObject.Find("RendererDropdown").GetComponent<TMP_Dropdown>();
    }

    public void CreateImagesGrid(List<Texture2D> textureList)
    {
        if (prefabList.Count!=0)
        {
            foreach (GridImageScript obj in prefabList)
            {
                obj.DestroySelf();
            }
            prefabList.Clear();
            newTextureList.Clear();
        }

        for (int i =0; i<textureList.Count; i++)
        {
            prefabList.Add(Instantiate(imagePrefab, transform));
            prefabList[i].number = i;
            prefabList[i].GetComponent<RawImage>().texture = textureList[i];
            newTextureList.Add(textureList[i]);
        }
    }
    


    public void ChangeTexture(int number)
    {
        if (renderingDropdownComponent.value!=0)
        {
            //рендер
            if (renderSlider.value!=0)
            {
                image.texture = RenderManager.GetTexture(number, (int)renderSlider.value, newTextureList, renderingDropdownComponent.value);
            }
        }
        else
        {
            image.texture = newTextureList[number];
            //обычная текстура
        }
        imageSlider.value = number + 1;
        //image.texture = texture;
    }

    public void ChangeTexture(Texture texture)
    {
        image.texture = texture;
    }
}
