using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text healthbarText;

    // Start is called before the first frame update
    void Start()
    {
        healthbarText.text = "0 pts.";
    }

    public void addPoints(int points)
    {
        healthbarText.text = (int.Parse(healthbarText.text.Replace(" pts.", "")) + points).ToString() + " pts.";
    }
}
