using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

    public GameObject crazyCar;
	public void onClickButton ()
    {
        crazyCar.SetActive(true);
    }
}
