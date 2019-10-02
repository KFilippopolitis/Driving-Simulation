using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {
    private Text tex;
    private Text texinfo;
    private Text tex1;
    private Text tex2;
    private Image im;
    private Image im2;
    private Image im3;
    public string id;
    public string str;
    public string str1;
    public string stra;
    public bool right;
    public bool end;
    private Text texright;
    public Image FinBUTTON;
    private Image FinBUTTON1;
    public Text FinTEXT;
    private Text FinTEXT1;
    public Text FinTEXT2;
    private Text FinTEXT12;
    public Image FinIMAGE;
    private Image FinIMAGE1;


    void OnTriggerEnter(Collider other)

    {


        GameObject Manager = GameObject.Find("Manager");
        Manager manager = Manager.GetComponent<Manager>();
        GameObject Managre = GameObject.Find("Managre");
        Managre managre = Managre.GetComponent<Managre>();

        manager.bol1 = right;
        managre.bol = right;

        if (!end)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameObject[] gameObjectright = GameObject.FindGameObjectsWithTag("b");

                foreach (GameObject go in gameObjectright)
                {
                    texright = go.GetComponent<Text>();
                    texright.enabled = true;
                }

                GameObject[] gameObjectrighta = GameObject.FindGameObjectsWithTag("a");

                foreach (GameObject go in gameObjectrighta)
                {
                    im3 = go.GetComponent<Image>();
                    im3.enabled = true;
                }

                GameObject[] gameObjectinfo = GameObject.FindGameObjectsWithTag("INFO");

                foreach (GameObject go in gameObjectinfo)
                {
                    texinfo = go.GetComponent<Text>();
                    texinfo.text = stra + " Εως Οτου φτάσετε τοn επόμενο κόμβο για περεταίρω πληροφορίες";
                }

                GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Question");

                foreach (GameObject go in gameObjectArray)
                {
                    tex = go.GetComponent<Text>();
                    tex.enabled = !tex.enabled;

                }

                GameObject[] gameObjectAnswer1 = GameObject.FindGameObjectsWithTag("Answer1");

                foreach (GameObject go in gameObjectAnswer1)
                {
                    tex1 = go.GetComponent<Text>();
                    tex1.enabled = !tex1.enabled;
                    tex1.text = str;
                }

                GameObject[] gameObjectAnswer2 = GameObject.FindGameObjectsWithTag("Answer2");

                foreach (GameObject go in gameObjectAnswer2)
                {
                    tex2 = go.GetComponent<Text>();
                    tex2.enabled = !tex2.enabled;
                    tex2.text = str1;
                }


                GameObject[] gameObjectArray1 = GameObject.FindGameObjectsWithTag("Question1");

                foreach (GameObject go in gameObjectArray1)
                {
                    im = go.GetComponent<Image>();
                    im.enabled = !im.enabled;
                }

                GameObject[] gameObjectArray3 = GameObject.FindGameObjectsWithTag("Question2");

                foreach (GameObject go in gameObjectArray3)
                {
                    im2 = go.GetComponent<Image>();
                    im2.enabled = !im2.enabled;
                }



                other.GetComponent<CarControl>().enabled = false;
                GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag(id);
                foreach (GameObject go in gameObjectArray2)
                {
                    go.SetActive(false);
                }


            }
        }

        else
        {
                other.GetComponent<CarControl>().enabled = false;
                FinIMAGE1 = FinIMAGE.GetComponent<Image>();
                FinIMAGE1.enabled = true;
                FinTEXT1 = FinTEXT.GetComponent<Text>();
                FinTEXT1.enabled = true;
                FinBUTTON1 = FinBUTTON.GetComponent<Image>();
                FinBUTTON1.enabled = true;
                FinTEXT12 = FinTEXT2.GetComponent<Text>();
                FinTEXT12.enabled = true;

        }
    }
}
