using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui_script : MonoBehaviour
{
    TextMeshProUGUI Enemy_value;

    
    void Start()
    {
        Enemy_value = transform.Find("Enemy_value").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_ui_Score(int new_value)
    {
        Enemy_value.text = new_value.ToString();
    }

    
}
