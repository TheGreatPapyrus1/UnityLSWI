using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] float xCoords;
    [SerializeField] float yCoords;

    [SerializeField] float distanceToDisplace;

    string label;
    public Clothes parentObject;

    public void Setup(Clothes parentObject, int xDisplacement, int yDisplacement, GameObject parent)
    {
        label = parentObject.GetDesignation();
        this.parentObject = parentObject;

        transform.SetParent(parent.transform);


        RectTransform rectCoords = GetComponent<RectTransform>();
        rectCoords.localScale = new Vector3(45f, 45f, 4.5f);

        float newXcoords = transform.parent.transform.position.x + xCoords +
            (xDisplacement * distanceToDisplace);

        float newYcoords = transform.parent.transform.position.y + yCoords -
            (yDisplacement * distanceToDisplace);


        rectCoords.anchoredPosition = new Vector2(newXcoords, newYcoords);

        GetComponentsInChildren<Image>()[1].sprite = parentObject.GetIcon();
        GetComponentInChildren<TextMeshProUGUI>().text = label;
    }

    public void PutOn()
    {
        FindObjectOfType<Inventory>().PutOnClothes(parentObject);
    }
}
