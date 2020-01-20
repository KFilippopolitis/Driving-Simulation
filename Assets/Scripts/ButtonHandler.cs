using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickButton : MonoBehaviour {

    public GameObject crazyCar;
	public void onClickButton ()
    {
        crazyCar.SetActive(true);
    }
}
