using System.Collections;
using UnityEngine;


public class MoveScenes : MonoBehaviour
{
    public string scene;
   public void Move()
    {
        Application.LoadLevel(scene);
    }
}
