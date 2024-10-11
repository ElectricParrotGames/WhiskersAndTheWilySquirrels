using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Jumping : MonoBehaviour
{


    public TMP_Text message;
    private float displayDuration = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            ShowText("I’m awake and ready to leap! Press the space bar to make me jump."); // Set your message
            
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

    //I’ll show them who’s the king of this garden! First, I’ll sneak up like a shadow, then—BAM! One swift pounce, and I’ll have my catnip back!
}
