using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetection : MonoBehaviour
{
    [SerializeField] private GameObject DoorCenter = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Key")
        {
            DoorCenter.GetComponent<Door>().Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            DoorCenter.GetComponent<Door>().Close();
        }
    }

}
