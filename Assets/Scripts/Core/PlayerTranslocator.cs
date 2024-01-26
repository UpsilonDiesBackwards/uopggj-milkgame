using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTranslocator : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = transform.position;
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
