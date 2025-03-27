using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class item : MonoBehaviour
{

    private int points = 0;
    [SerializeField] private TextMeshProUGUI bananasText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            points++;
            Destroy(collision.gameObject);
            bananasText.text = "Banana: "  + points;
        }
    }

}
