using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text;
    void Awake() {
        text = GetComponent<TMP_Text>();
    }

    void Update() {
        text.text = "Score: " + ScoreManager.instance.amount;
    }
}
