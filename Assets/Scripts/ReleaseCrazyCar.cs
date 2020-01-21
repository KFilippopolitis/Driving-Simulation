using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseCrazyCar : MonoBehaviour {

    public GameObject crazyCar;
	public void releaseCrazyCar ()
    {
        crazyCar.SetActive(true);
    }
}
