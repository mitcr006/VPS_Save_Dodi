using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignOrgan : MonoBehaviour
{
    public bool heart;
    public bool liver;
    public bool brain;

    public AudioClip inPlace;

    public RaycastManager rayManager;

    public void Start()
    {
        rayManager = FindObjectOfType<RaycastManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (heart)
        {
            if (other.gameObject.tag == "HeartHole")
            {
                transform.parent = null;
                transform.position = other.gameObject.transform.GetChild(0).position;
                transform.eulerAngles = other.gameObject.transform.GetChild(0).eulerAngles;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                rayManager.organ = null;
                GetComponent<AudioSource>().clip = inPlace;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (liver)
        {
            if (other.gameObject.tag == "LiverHole")
            {
                transform.parent = null;
                transform.position = other.gameObject.transform.GetChild(0).position;
                transform.eulerAngles = other.gameObject.transform.GetChild(0).eulerAngles;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                rayManager.organ = null;
                GetComponent<AudioSource>().clip = inPlace;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (brain)
        {
            if (other.gameObject.tag == "BrainHole")
            {
                transform.parent = null;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90f, transform.eulerAngles.y, transform.eulerAngles.z);
                rayManager.organ = null;
                GetComponent<AudioSource>().clip = inPlace;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
