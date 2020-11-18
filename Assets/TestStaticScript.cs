using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dicom;
using Dicom.Imaging;
using System.IO;

public static class TestStaticScript
{
    

    static int datasetLength;
    /*public static int ImportData(string path, Slider slider)
    {
        
        slider.maxValue = 0;
        if (Directory.Exists(path))
        {
            foreach (string file in Directory.GetFiles(path))
            {
                DicomFile dFile = DicomFile.Open(file);
                DicomImage dicomImage = new DicomImage(file);
                string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                Texture2D texture = dicomImage.RenderImage().AsTexture2D();

                DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                dicomImageFrameList.Add(dicomImageFrame);

                datasetLength++;
                slider.maxValue++;
            }
        }
        else
        {
            Debug.LogError("Directory is not Exist");
        }
    }
    /*public static List<Texture2D> ChangeImageList()
    {
        Texture2D texture = null;
        for (int i = 0; i < datasetLength; i++)
        {
            switch (value)
            {
                case 0:
                    texture = dicomImageFrameList[i].GetTexture("Coronal");
                    break;
                case 1:
                    texture = dicomImageFrameList[i].GetTexture("Sagittal");
                    break;
                case 2:
                    texture = dicomImageFrameList[i].GetTexture("Axial");
                    break;
                default:
                    break;
            }

            if (texture != null)
            {
                textureList.Add(texture);
            }
        }
        if (textureList != null)
        {
            return textureList;
        }
        else
            return null;
    }*/
}
