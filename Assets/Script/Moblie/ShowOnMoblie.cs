using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMoblie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            gameObject.SetActive(Application.isMobilePlatform);
    }

    // Update is called once per frame
   
}
