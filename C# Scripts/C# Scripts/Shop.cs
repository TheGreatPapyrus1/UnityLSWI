using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Clothes> stock = new List<Clothes>();

    [SerializeField] GameObject buttonPreset;
    [SerializeField] GameObject shopUI;

    public List<GameObject> children = new List<GameObject>();

    public void ConstructShopMenu()
    {
        shopUI.SetActive(true);

        int indexReached = 0;
        foreach(Clothes currentClothes in stock)
        {
            int xDisplace = indexReached;
            int yDisplace = 0;
            if(indexReached > 4)
            {
                yDisplace = 1;
                xDisplace = indexReached - 5;

            }

            GameObject button = Instantiate(buttonPreset) as GameObject;
            button.transform.parent = shopUI.transform;
            

            button.GetComponent<MenuButton>().Setup(currentClothes, xDisplace, yDisplace, shopUI);

            children.Add(button);

            indexReached++;
        }
    }

    public void SellClothes(Clothes clothesToSell)
    {
        if (clothesToSell.GetPrice() <= FindObjectOfType<Player>().GetDollars())
        {
            GameObject clothesObject = Instantiate(clothesToSell.gameObject) as GameObject;
            clothesObject.transform.parent = FindObjectOfType<Player>().transform;
            stock.Remove(clothesToSell);
            FindObjectOfType<Inventory>().AddClothesToInventory(clothesObject);
            FindObjectOfType<Player>().RemoveDollars(clothesToSell.GetPrice());

        }
    }

    public void LeaveShop()
    {
        foreach(GameObject button in children)
        {
            Destroy(button);
        }

        shopUI.SetActive(false);
    }

}
