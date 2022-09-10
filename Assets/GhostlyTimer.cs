using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyTimer : MonoBehaviour
{
    public float timeLeft;
    public float rateOfAssention;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0f)
        {
            timeLeft -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + rateOfAssention, transform.position.z);
        }
    }
}
