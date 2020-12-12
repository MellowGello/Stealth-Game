using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetec : MonoBehaviour
{
    public Transform target;
    public GameObject detectBar;
    public EnemyFOV FOVScript;
    Slider slider;
    float value;
    void Start()
    {
        slider = detectBar.GetComponent<Slider>();
        detectBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        value = FOVScript.playerSpottedTimer;
        slider.value = value;

        if(value == slider.minValue)
        {
            detectBar.SetActive(false);
        }
        else
        {
            detectBar.SetActive(true);
        }

        detectBar.transform.LookAt(target);
    }
}
