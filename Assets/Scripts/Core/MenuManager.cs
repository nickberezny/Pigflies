using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public void LoadLevel(int level)
    {
        GameManager.Instance.LoadLevel("Level" + level.ToString());
    }
}
