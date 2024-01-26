using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassChecker : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalGameplayVariables.Instance.hasMilkGlass)
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
