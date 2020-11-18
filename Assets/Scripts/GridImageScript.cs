using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//prefab script
public class GridImageScript : MonoBehaviour
{
    public int number;
    //public RawImage image;
    

    //on Image Click
    public void OnClickChange()
    {
        GetComponentInParent<GridViewScript>().ChangeTexture(number);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
