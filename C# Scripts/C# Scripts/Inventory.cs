using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
    [SerializeField] List<GameObject> inventory;
    [SerializeField] GameObject buttonPreset;

    [SerializeField] GameObject inventoryUI;

    public List<GameObject> children;

    public void ConstructInventoryMenu()
    {
        inventoryUI.SetActive(true);

        int indexReached = 0;
        foreach (GameObject currentClothes in inventory)
        {
            int xDisplace = indexReached;
            int yDisplace = 0;
            if (indexReached > 4)
            {
                yDisplace = 1;
                xDisplace = indexReached - 5;

            }

            GameObject button = Instantiate(buttonPreset) as GameObject;
            button.transform.parent = inventoryUI.transform;
            
            button.GetComponent<InventoryButton>().Setup(currentClothes.GetComponent<Clothes>(), xDisplace, yDisplace, inventoryUI);

            children.Add(button);
            indexReached++;
        }
    }

    public void AddClothesToInventory(GameObject clothesToAdd)
    {
        inventory.Add(clothesToAdd);
    }

    public void LeaveInventory()
    {
        foreach(GameObject child in children)
        {
            Destroy(child);
        }
        inventoryUI.SetActive(false);
    }

    public void PutOnClothes(Clothes clothes)
    {
        clothes.gameObject.SetActive(true);
        
            
            if (clothes.GetClothesType() == "shirt")
            {
                FindObjectOfType<Player>().SetShirt(clothes);
            }
            if (clothes.GetClothesType() == "pants")
            {
                FindObjectOfType<Player>().SetPants(clothes);
            }
        
    }

    public void TakeOffClothes(Clothes clothes)
    {
        if (clothes)
        {
            clothes.gameObject.SetActive(false);
        }
    }
}
