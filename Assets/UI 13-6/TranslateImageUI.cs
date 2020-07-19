using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TranslateImageUI : MonoBehaviour {

    public Image image;
    bool active =false;

    public void Update()
    {
       // image.rectTransform.position= this.GetComponent <RectTransform>().position;

    }
    public void OnMouseOver() {
        image.rectTransform.position = this.GetComponent<RectTransform>().position;

    }


}
