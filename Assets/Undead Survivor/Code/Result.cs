using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject[] titles;

    public void Dead()
    {
        titles[0].SetActive(true);
    }

    public void Servived()
    {
        titles[1].SetActive(true);
    }
}
