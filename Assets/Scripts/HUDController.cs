using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text txtHealth;

    public void UpdateHealthText(string text)
    {
        txtHealth.text = "Health: " + text;
    }
}
