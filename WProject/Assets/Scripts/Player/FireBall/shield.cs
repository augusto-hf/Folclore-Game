using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    [SerializeField] GameObject _shield;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            _shield.SetActive(true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            _shield.SetActive(false);
        }
    }
}
