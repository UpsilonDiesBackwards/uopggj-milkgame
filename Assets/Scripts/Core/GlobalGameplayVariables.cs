using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameplayVariables : MonoBehaviour
{
    public static GlobalGameplayVariables Instance { get; private set; }

    public bool hasHouseKey = false;
    public int amountSpokenToo = 0;

    public bool hasMilkGlass = false;
   
    private void Awake() 
    {     
        if (Instance != null && Instance != this)  { 
            Destroy(this);  
        } else { 
            Instance = this; 
        } 
    }
}
