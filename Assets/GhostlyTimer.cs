using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyTimer : MonoBehaviour
{
    public float timeLeft;
    public float rateOfAssention;
    public GameUIIntegration ui;
    public int organsPlaced = 0;


    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<GameUIIntegration>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0f && organsPlaced != 3)
        {
            ui.lifeLeft.value = timeLeft;
            ui.timeLeft.text = "TIME 00:" + Mathf.Round(timeLeft).ToString();
            ui.endTime.text = "TIME 00:" + Mathf.Round(timeLeft).ToString();
            timeLeft -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + rateOfAssention, transform.position.z);
        }
    }
}
