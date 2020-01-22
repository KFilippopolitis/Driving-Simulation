using UnityEngine;

public class ButtonOnClick : MonoBehaviour
{
    public GameObject crazyCar;
    public void onClickButton()
    {
        crazyCar.SetActive(true);
    }
}
