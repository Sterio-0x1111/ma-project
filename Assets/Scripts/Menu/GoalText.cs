using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalText : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = Goal.count + " / 2";
    }
}
