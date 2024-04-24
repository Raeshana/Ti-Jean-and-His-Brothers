using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private TMP_Text timer;
    [SerializeField] float remainingTime;
    [SerializeField] DevilController devilController;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Begin timer after talking to Devil
        if (devilController.hasTalked)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0){
                remainingTime = 0;
            }
            
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }
}
