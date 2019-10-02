using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Managre : MonoBehaviour
{
    public Text winTextscore;
    public Text winText;
    
    private Image imfault;
    private Image imfault2;
    private Image imfault3;
    private Image imfault4;
    private Text tex;
    private Image im;
    private Text tex1;
    private Image im1;
    private Text tex2;
    private Image im2;
    private string str = "Απαντήσατε σωστά! Στην προηγουμενη ερώτηση.";
    private string str1 = "Λάθος απάντηση! Δοκιμάστε ξανά.";
    public bool bol;
    private int i;
    private int y;
    public int score;
    public string SCENE;
    public int SCEN;
    // public string WINSCENE;
    public void Managers()

    {


        if (!bol)
        {
            y++;

            score += 5;

            winTextscore.text = "Score : " + score;


            GameObject[] gameObjectArraya = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject go in gameObjectArraya)
            {
                go.GetComponent<CarControl>().enabled = true;
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
            }

            GameObject[] gameObjectAnswer2 = GameObject.FindGameObjectsWithTag("Answer2");

            foreach (GameObject go in gameObjectAnswer2)
            {
                tex2 = go.GetComponent<Text>();
                tex2.enabled = !tex2.enabled;
            }


            GameObject[] gameObjectArray1 = GameObject.FindGameObjectsWithTag("Question1");

            foreach (GameObject go in gameObjectArray1)
            {
                im = go.GetComponent<Image>();
                im.enabled = !im.enabled;
            }


            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("Question2");

            foreach (GameObject go in gameObjectArray2)
            {
                im2 = go.GetComponent<Image>();
                im2.enabled = !im2.enabled;
            }


            winText.text = str;

        }
        else
        {

            score -= 5;

            winTextscore.text = "Score : " + score;

            i++;
            switch (i)
            {
                case 1:
                    GameObject[] gameObjectfault1 = GameObject.FindGameObjectsWithTag("fault1");

                    foreach (GameObject go in gameObjectfault1)
                    {
                        imfault = go.GetComponent<Image>();
                        imfault.enabled = false;
                    }
                    break;
                case 2:
                    GameObject[] gameObjectfault2 = GameObject.FindGameObjectsWithTag("fault2");

                    foreach (GameObject go in gameObjectfault2)
                    {
                        imfault2 = go.GetComponent<Image>();
                        imfault2.enabled = false;
                    }
                    break;
                case 3:
                    GameObject[] gameObjectfault3 = GameObject.FindGameObjectsWithTag("fault3");

                    foreach (GameObject go in gameObjectfault3)
                    {
                        imfault3 = go.GetComponent<Image>();
                        imfault3.enabled = false;
                    }
                    GameObject[] gameObjectfault4 = GameObject.FindGameObjectsWithTag("x");

                    foreach (GameObject go in gameObjectfault4)
                    {
                        imfault4 = go.GetComponent<Image>();
                        imfault4.enabled = true;
                    }
                    break;
                case 4:
                    Application.LoadLevel(SCENE);
                    break;
                default:

                    break;
            }
            winText.text = str1;
        }


    }

}