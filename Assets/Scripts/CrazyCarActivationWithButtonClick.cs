using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrazyCarActivationWithButtonClick : MonoBehaviour {

    public GameObject crazyCar;
	public void releaseCrazyCar ()
    {
        crazyCar.SetActive(true);
    }
}
