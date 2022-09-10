using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    Camera camera;

    [SerializeField]
    private Transform snapToPoint;

    public GameObject organ;

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (organ == null)
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    Debug.Log("Something Hit " + raycastHit.collider.name);
                    if (raycastHit.collider.gameObject.tag == "Interactable")
                    {
                        organ = raycastHit.collider.gameObject;
                        organ.transform.parent = snapToPoint;
                        organ.transform.localPosition = Vector3.zero;
                        organ.transform.localEulerAngles = Vector3.zero;
                        organ.GetComponent<Rigidbody>().useGravity = false;
                        organ.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
            else
            {
                organ.GetComponent<Rigidbody>().useGravity = true;
                organ.GetComponent<Rigidbody>().isKinematic = false;
                organ.transform.parent = null;
                organ = null;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }
}
