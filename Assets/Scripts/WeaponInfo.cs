using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public Text text;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string _string)
    {
        text.text = _string;
    }

    public void SetImage(Sprite _image)
    {
        image.sprite = _image;
    }
}
