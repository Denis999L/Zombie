using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;

    void Start()
    {
        
    }
   
    public void UpdateAmmo(int count)
    {
        ammoText.text = "Ammo: " + count;
    }
}
