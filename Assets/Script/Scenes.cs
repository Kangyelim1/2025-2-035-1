using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    public GameObject suspicious;
    public GameObject EXIT;

    public void Update()
    {
        if (suspicious == null)
        {
            EXIT.SetActive(true);
        }
    }
}
