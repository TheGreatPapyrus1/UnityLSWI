using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButton : MonoBehaviour
{
    [SerializeField] float xCoords;
    [SerializeField] float yCoords;

    [SerializeField] float distanceToDisplace;

    [SerializeField] float alphaAmount = 0.5f;

    string label;
    Clothes parentObject;

    bool clicked = false;

    public void Setup(Clothes parentObject, int xDisplacement, int yDisplacement, GameObject parent)
    {
        label = parentObject.GetDesignation();
        this.parentObject = parentObject;

        transform.SetParent(parent.gameObject.transform);


        RectTransform rectCoords = GetComponent<RectTransform>();
        rectCoords.localScale = new Vector3(45f, 45f, 4.5f);

        float newXcoords = transform.parent.transform.position.x + xCoords +
            (xDisplacement * distanceToDisplace);

        float newYcoords = transform.parent.transform.position.y + yCoords -
            (yDisplacement * distanceToDisplace);
            

        rectCoords.anchoredPosition = new Vector2(newXcoords, newYcoords);

        GetComponentsInChildren<Image>()[1].sprite = parentObject.GetIcon();
        GetComponentInChildren<TextMeshProUGUI>().text =
            label + "\n$" + parentObject.GetPrice().ToString();

    }

    public void Sell()
    {
        if (!clicked)
        {
            if (parentObject.GetPrice() <= FindObjectOfType<Player>().GetDollars())
            {
                FindObjectOfType<Shop>().SellClothes(parentObject);

                Color currentColor = GetComponent<Image>().color;
                GetComponent<Image>().color =
                    new Color(currentColor.r, currentColor.g, currentColor.b, alphaAmount);

                clicked = true;
            }
        }
    }
}
