using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [Range(0, 10)]
    public float duration;
    private void OnEnable() {
        Invoke("SetDisabled", duration);
    }
    private void SetDisabled() {
        gameObject.SetActive(false);
    }
}
