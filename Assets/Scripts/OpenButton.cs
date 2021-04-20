using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenButton : MonoBehaviour, IPointerDownHandler
{
    public bool isActive;
    public GameObject target;
    public List<OpenButton> others = new List<OpenButton>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isActive == false)
        {
            isActive = true;
            target.SetActive(true);
            foreach(OpenButton e in others)
            {
                e.isActive = false;
                e.target.SetActive(false);
            }
        }
    }
}
