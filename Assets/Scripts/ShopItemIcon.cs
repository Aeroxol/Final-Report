using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItemIcon : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    public Hero hero;
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
        Item new_item = GameObject.Instantiate<Item>(item);
        hero.SetItem(new_item);
    }
}
