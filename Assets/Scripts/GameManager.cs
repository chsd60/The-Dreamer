using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool activePapaGQuest1 = false;
    public bool dreamcatcher = true;
    public GameObject papaGQuest1Obj;
    public GameObject papaGQuest1Obj2;
    public GameObject papaGQuest1SceneL;

    public GameObject dreamcatcherObj;
    public GameObject dreamcatcherDial1;

    void Update() {
        if (activePapaGQuest1 == false) {
            papaGQuest1Obj.SetActive(true);
            papaGQuest1SceneL.SetActive(false);
            papaGQuest1Obj2.SetActive(false);

        } else {
            papaGQuest1Obj.SetActive(false);
            papaGQuest1SceneL.SetActive(true);
            papaGQuest1Obj2.SetActive(true);
        }

        if (dreamcatcher == true) {
            dreamcatcherObj.SetActive(true);
        } else {
            dreamcatcherObj.SetActive(false);
            dreamcatcherDial1.SetActive(true);
        }
    }

    public void PapaGQuest1() {
        activePapaGQuest1 = true;
    }

}
