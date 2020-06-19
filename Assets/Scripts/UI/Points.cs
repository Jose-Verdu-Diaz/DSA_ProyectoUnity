using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI healthbarText;

    // Start is called before the first frame update
    void Start()
    {
        healthbarText.text = "0 pts.";
    }

    public void addPoints(int points)
    {
        healthbarText.text = (int.Parse(healthbarText.text.Replace(" pts.","")) + points).ToString() + " pts.";
    }
}
