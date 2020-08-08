using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesHandler : MonoBehaviour
{
    public static int livesValue = 3;
    TextMeshProUGUI lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = livesValue.ToString();
    }
}
