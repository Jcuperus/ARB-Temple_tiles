using UnityEngine;
using System.Collections;

public class TileTimer : MonoBehaviour {
    private int timerLimit = 5;
    private int timer;
    private TextMesh tm;

	// Use this for initialization
	void Awake () {
        timer = timerLimit;
        tm = GetComponent<TextMesh>();
        timerLimit = GameObject.Find("GameManager").GetComponent<PlayerBehaviour>().stepInterval;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startTimer() {
        timer = timerLimit;
        StartCoroutine(timerUpdate());
    }

    private IEnumerator timerUpdate() {
        while (timer > 0) { 
            tm.text = timer.ToString();
            yield return new WaitForSeconds(1);
            timer--;
        }
        tm.text = "";
    }
}
