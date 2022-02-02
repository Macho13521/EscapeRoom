using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickHandler : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        PlayerController playerC = other.gameObject.GetComponent<PlayerController>();
        if (playerC != null)
        {
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlaySound("otwarcieZamka");
                GameManager.Instance.lockpick = true;
                Destroy(gameObject);
            }

        }
    }
}
