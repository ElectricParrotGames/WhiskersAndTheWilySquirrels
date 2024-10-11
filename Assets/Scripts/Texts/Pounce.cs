using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pounce : MonoBehaviour
{



    public TMP_Text message;
    private float displayDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            ShowText("First, I’ll sneak up like a shadow, then—BAM! One swift pounce, and I’ll have my catnip back!"); // Set your message
           
        }
    }

    private void ShowText(string shownMessage)
    {
        message.text = shownMessage; // Set the message
        message.gameObject.SetActive(true); // Show the text
        Invoke("HideText", displayDuration); // Call HideText after the duration
    }

    private void HideText()
    {
        message.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    
}
