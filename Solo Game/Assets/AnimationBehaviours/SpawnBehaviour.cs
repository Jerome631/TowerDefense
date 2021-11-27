using UnityEngine;
using System.Collections;

public class SpawnBehaviour : StateMachineBehaviour {
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Spawns a new wave
        GameManager.Instance.StartWave();
    }

}
