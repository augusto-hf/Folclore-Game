using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    [SerializeField] GameObject _shield;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shield"))
        {
            _shield.SetActive(true);
        }
        if (Input.GetButtonUp("Shield"))
        {
            _shield.SetActive(false);
        }
    }
}
