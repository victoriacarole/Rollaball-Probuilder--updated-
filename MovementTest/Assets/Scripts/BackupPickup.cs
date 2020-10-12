using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    // used for text
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count = 0;

    // used for material changed
    public Material[] material;
    Renderer rend;

    void Start()
    {
        //count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        // get material component for color change
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        // if onTrigger object is named PickUp1, change player's color to yellow
        if (other.gameObject.name == "PickUp1")
        {
            rend.sharedMaterial = material[1];
        }
        // if onTrigger object is named PickUp2, change player's color to green
        if (other.gameObject.name == "PickUp2")
        {
            rend.sharedMaterial = material[2];
        }
        // if onTrigger object is named PickUp3, change player's color to pink
        if (other.gameObject.name == "PickUp3")
        {
            rend.sharedMaterial = material[3];
        }
        // if onTrigger object is named PickUp4, change player's color to blue
        if (other.gameObject.name == "PickUp4")
        {
            rend.sharedMaterial = material[4];
        }
        // if onTrigger object is named PickUp5, change player's color to purple
        if (other.gameObject.name == "PickUp5")
        {
            rend.sharedMaterial = material[5];
        }
    }

    void SetCountText()
    {
        countText.text = " Count: " + count.ToString();

        if (count >= 1)
        {
            winTextObject.SetActive(true);
        }
    }
}
