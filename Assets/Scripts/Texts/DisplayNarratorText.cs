using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayNarratorText : MonoBehaviour
{

    public TMP_Text message;

    public TextNarrator textNarrator;

    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            ShowText(textNarrator.text);
        }
    }

    private void ShowText(string shownMessage)
    {
        message.text = shownMessage; // Set the message
        message.gameObject.SetActive(true); // Show the text
        Invoke("HideText", textNarrator.displayDuration); // Call HideText after the duration
    }

    private void HideText()
    {
        message.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}

