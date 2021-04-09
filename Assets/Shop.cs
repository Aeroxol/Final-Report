using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopPages;
    public GameObject Status;

    public bool shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
        if (shop)
        {
            shop = false;
            ShopPages.SetActive(true);
        }
        else
        {
            shop = true;
            ShopPages.SetActive(false);
        }
    }
}
