using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClubHandler : MonoBehaviour {
    public GameObject golfclub;
    public FloatValue dissapearWaitTime;
    public FloatValue appearWaitTime;
    private IEnumerator coroutineBuffer = default(IEnumerator);
    public void OnEnable() {
        EventManager.onBallDragged += AppearGolfClub;
        EventManager.onBallHit += DissapearGolfClub;
    }

    public void OnDisable() {
        EventManager.onBallDragged -= AppearGolfClub;
        EventManager.onBallHit -= DissapearGolfClub;
    }

    private void DissapearGolfClub() {
        //ballDragged = false;
        coroutineBuffer = WaitForAnimation(false, dissapearWaitTime.value);
        StartCoroutine(coroutineBuffer);
    }
    
    private void AppearGolfClub() {
        if(coroutineBuffer != null)
            StopCoroutine(coroutineBuffer);
        StartCoroutine(WaitForAnimation(true, appearWaitTime.value));
    }

    private IEnumerator WaitForAnimation(bool golfClubState, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        //uso esto para que si la corutina de desaparecer no termino, no me desaparesca en medio de un tiro nuevo
        golfclub.SetActive(golfClubState);
    }
}
