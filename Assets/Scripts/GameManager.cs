using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool activePapaGQuest1 = false;
    public GameObject PapaGQuest1Obj;
    public GameObject PapaGQuest1Obj2;
    public GameObject PapaGQuest1SL;
    void Start() {
        
    }

    void Update() {
        if (activePapaGQuest1 == false) {
            PapaGQuest1Obj.SetActive(true);
            PapaGQuest1SL.SetActive(false);
            PapaGQuest1Obj2.SetActive(false);

        } else {
            PapaGQuest1Obj.SetActive(false);
            PapaGQuest1SL.SetActive(true);
            PapaGQuest1Obj2.SetActive(true);
        }
    }

    public void PapaGQuest1() {
        activePapaGQuest1 = true;
    }

}
