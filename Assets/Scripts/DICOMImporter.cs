 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dicom;
using Dicom.Imaging;
using System.IO;
using TMPro;
using System.Linq;
//using System.Diagnostics;

public class DICOMImporter : MonoBehaviour
{
    public struct DicomImageFrame
    {
        string patientName;
        string anatomicalPlane;
        Texture2D imageFrame;

        public DicomImageFrame(string name, string plane, Texture2D image)
        {
            patientName = name;
            anatomicalPlane = plane;
            imageFrame = image;
        }

        public Texture2D GetTexture(string plane)
        {
            if (anatomicalPlane == plane)
            {
                return imageFrame;
            }
            else
                return null;
        }

        public string GetName()
        {
            return patientName;
        }

    }

    private int datasetLength = 0;
    private string path;


    public Toggle toggle;
    public ImportPanelScript importPanel;
    public UIManager uiManager;
    public TextMeshProUGUI descriptionTMP;

    public List<DicomImageFrame> dicomImageFrameList = new List<DicomImageFrame>();

    private void Awake()
    {
        ImportData(true);
    }

    public void ImportData(bool isUsingAssets)
    {
        if (isUsingAssets)
        {
            path = Application.streamingAssetsPath;
            
            Debug.Log("StreamingAssets path is: " + path);
        }
        ImportData(path, false);
        uiManager.CreateFilteredLists();
        descriptionTMP.text = dicomImageFrameList[0].GetName();
    }

    DicomFile dFile;
    //Import Dicom Data
    int ImportData(string path, bool isDivided)
    {
        dicomImageFrameList.Clear();
        if (Directory.Exists(path))
        {
            Debug.Log(path);

            if (!isDivided)
            {
                datasetLength = 0;//bug 1
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    if (Path.GetExtension(file) == ".dcm")
                    {
                        if (file != null)
                        {
                            Debug.Log(file);
                            dFile = DicomFile.Open(file.Replace('/', '\\'));//null Reference
                        }
                        DicomImage dicomImage = new DicomImage(file);
                        string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                        string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                        Texture2D texture = dicomImage.RenderImage().AsTexture2D();
                        DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                        dicomImageFrameList.Add(dicomImageFrame);
                        datasetLength++;
                    }
                }
            }
            else
            {
                datasetLength = 0;
                foreach (string file in Directory.EnumerateFiles(path+"//Axial"))
                {
                    if (Path.GetExtension(file) == ".dcm")
                    {
                        Debug.Log(path);
                        if (file != null)
                        {
                            Debug.Log(file);
                            dFile = DicomFile.Open(file.Replace('/', '\\'));//null Reference
                        }
                        DicomImage dicomImage = new DicomImage(file);
                        string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                        string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                        Texture2D texture = dicomImage.RenderImage().AsTexture2D();
                        DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                        dicomImageFrameList.Add(dicomImageFrame);
                        datasetLength++;
                    }
                }
                foreach (string file in Directory.EnumerateFiles(path + "//Axial"))
                {
                    if (Path.GetExtension(file) == ".dcm")
                    {
                        if (file != null)
                        {
                            dFile = DicomFile.Open(file.Replace('/', '\\'));//null Reference
                        }
                        DicomImage dicomImage = new DicomImage(file);
                        string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                        string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                        Texture2D texture = dicomImage.RenderImage().AsTexture2D();
                        DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                        dicomImageFrameList.Add(dicomImageFrame);
                        datasetLength++;
                    }
                }
                foreach (string file in Directory.EnumerateFiles(path + "//Coronal"))
                {
                    if (Path.GetExtension(file) == ".dcm")
                    {
                        if (file != null)
                        {
                            dFile = DicomFile.Open(file.Replace('/', '\\'));//null Reference
                        }
                        DicomImage dicomImage = new DicomImage(file);
                        string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                        string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                        Texture2D texture = dicomImage.RenderImage().AsTexture2D();
                        DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                        dicomImageFrameList.Add(dicomImageFrame);
                        datasetLength++;
                    }
                }
                foreach (string file in Directory.EnumerateFiles(path + "//Sagittal"))
                {
                    if (Path.GetExtension(file) == ".dcm")
                    {
                        if (file != null)
                        {
                            dFile = DicomFile.Open(file.Replace('/', '\\'));//null Reference
                        }
                        DicomImage dicomImage = new DicomImage(file);
                        string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                        string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                        Texture2D texture = dicomImage.RenderImage().AsTexture2D();
                        DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                        dicomImageFrameList.Add(dicomImageFrame);
                        datasetLength++;
                    }
                }
                foreach (string file in Directory.EnumerateFiles(path + "//NoTag"))
                {
                    if (Path.GetExtension(file) == ".dcm")
                    {
                        if (file != null)
                        {
                            dFile = DicomFile.Open(file.Replace('/', '\\'));//null Reference
                        }
                        DicomImage dicomImage = new DicomImage(file);
                        string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                        string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                        Texture2D texture = dicomImage.RenderImage().AsTexture2D();
                        DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                        dicomImageFrameList.Add(dicomImageFrame);
                        datasetLength++;
                    }
                }
            }
        }
        else 
        {
            Debug.LogError("Directory is not Exist");
        }
        return datasetLength;
    }

    public void getPath(TMP_InputField inputField)
    {
        path = inputField.text;
        Debug.Log("Path: " + path);
    }

    //horrible looking cuz not using linq
    public List<Texture2D> ChangeList(TMP_Dropdown dropdownComponent)
    {
        Texture2D texture = null;
        List<Texture2D> textureList = new List<Texture2D>();
        for (int i = 0; i < datasetLength; i++)
        {
            switch (dropdownComponent.value)
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
                case 3:
                    texture = dicomImageFrameList[i].GetTexture("Obliquo");
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
            Debug.Log("Count: " + textureList.Count);
            return textureList;
        }
        else
        {
            Debug.LogError("TextureList is null");
            return null;
        }
    }

    //calculate image orientation by vector value
    private string CalculateOrientation(int[] imageOrientation)
    {
        if (imageOrientation!=null)
        {
            var vector1 = new Vector3(imageOrientation[0], imageOrientation[1], imageOrientation[2]);
            var vector2 = new Vector3(imageOrientation[3], imageOrientation[4], imageOrientation[5]);
            if ((vector1 == Vector3.up || vector1 == Vector3.down) && (vector2 == Vector3.back || vector2 == Vector3.forward))
                return "Sagittal";
            if ((vector1 == Vector3.right || vector1 == Vector3.left) && (vector2 == Vector3.back || vector2 == Vector3.forward))
            {
                return "Coronal";
            }

            if ((vector1 == Vector3.right || vector1 == Vector3.left) && (vector2 == Vector3.up || vector2 == Vector3.down))
            {
                return "Axial";
            }

            else
                return "Obliquo";
        }
        else
            return "Obliquo";
    }
}
