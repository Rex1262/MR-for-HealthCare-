using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RenderManager
{
    //получение смердженной текстуры
    public static Texture2D GetTexture(int imageSliderValue, int renderSliderValue, List<Texture2D> listOfImages, int renderType)
    {
        int renderValueReduced = renderSliderValue;
        List<Texture2D> textureList = new List<Texture2D>();
        if (imageSliderValue+renderSliderValue >= listOfImages.Count )
        {
            renderValueReduced = listOfImages.Count-imageSliderValue;
        }
        for (int i = imageSliderValue; i<imageSliderValue+renderValueReduced; i++)
        {
            Texture2D texture = listOfImages[i];
            textureList.Add(texture);
        }

        Debug.Log("Texture Render Characteristics: \nNumber of images to render: " + 
            textureList.Count + ", Render type: " + renderType + ", Image Slider Value: " + imageSliderValue + 
            ", Render Slider Value" + renderSliderValue);
        return GetRenderedTexture(textureList, renderType);
    }

    //Мерджит лист текстур в одну текстуру
    private static Texture2D GetRenderedTexture(List<Texture2D> imagesToRender, int renderType)
    {
        int minLength = imagesToRender[0].GetPixels().Length;
        int imagesCount = imagesToRender.Count;
        
        Texture2D result = new Texture2D(imagesToRender[0].width,imagesToRender[0].height);
        //Color[] resultColorList = new Color[minLength];
        Color[] resultColorList = imagesToRender[0].GetPixels();//итоговый лист пикселей
        Color[,] color = new Color[imagesToRender.Count, minLength];//массив всех изображений и их пикселей
        //color = new Color[imagesToRender.Count, minLength];
        for (int i =0; i < minLength; i++)//lowest 
        {
            switch(renderType)
            {
                case 1:
                    resultColorList[i] = Color.black;//обнуление цвета до 0 0 0 
                    break;
                case 2:
                    resultColorList[i] = Color.white;//обнуление цвета до 1 1 1  
                    break;
                case 3:
                    resultColorList[i] = Color.black;
                    break;
            }
            
        }

        for (int j=0;j<imagesCount;j++)
        {
            Color[] pixels = new Color[minLength];
            pixels = imagesToRender[j].GetPixels();
            for (int i = 0; i < minLength; i++)
            {
                color[j, i] = pixels[i];//запись массива пикселей в массив пикселей и изображений
                switch (renderType)
                {
                    case 1:
                        if (color[j, i].grayscale > resultColorList[i].grayscale)
                        {

                            resultColorList[i] = color[j, i];
                        }
                        break;
                    case 2:
                        if (color[j,i].grayscale < resultColorList[i].grayscale)
                        {
                            resultColorList[i] = color[j, i];
                        }
                        break;
                    case 3:
                        {
                            resultColorList[i] += color[j, i];
                        }
                        break;
                } 
                
            }

        }

        if (renderType==3)
        {
            for (int i = 0; i<minLength;i++)
            {
                resultColorList[i] = resultColorList[i] / imagesCount;
            }
        }

        result.SetPixels(resultColorList);
        result.Apply();
        return result;
    }
}
