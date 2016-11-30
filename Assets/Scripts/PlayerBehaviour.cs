using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour {
    public int stepInterval = 15; //Time between steps
    private GridManager gm;
    private bool isActive = true;
    private int tileIndex = 0; //Index of target tile in 
    private GameObject currentTile; //Current tile
    private List<GameObject> targetTiles;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GridManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTile != null) {
            targetTiles = gm.getConnections(currentTile);
            //Move to tile subroutine
            //Update possible tiles (?)
            currentTile.GetComponent<TileBehaviour>().setCurrent(true);
            if (targetTiles != null && targetTiles.Count > 0) {
                foreach (GameObject tile in targetTiles) { //Reset all selected
                    tile.GetComponent<TileBehaviour>().setSelected(false);
                }
                targetTiles[tileIndex].GetComponent<TileBehaviour>().setSelected(true); //Set current selected
            }

            //Increment tileIndex on tap (% possible tiles count)
            if (Input.GetMouseButtonDown(0)) //Mouse click
            {
                toggleTarget();
            }

            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) //Touch
                {
                    toggleTarget();
                }
            }
        }
    }

    public IEnumerator tileCountdown() {
        Debug.Log("Countdown started");
        while (isActive) {
            yield return new WaitForSeconds(stepInterval);
            if (!movePlayer()) {
                isActive = false;
                Debug.Log("Game over");
                //Game over (end game)
            }
        }
    }

    public void toggleTarget() {
        //TODO: update selected
        if (targetTiles != null) {
            int tileCount = targetTiles.Count;
            if (tileCount > 0) {
                tileIndex = (tileIndex + 1) % tileCount;
                targetTiles[tileIndex].GetComponent<TileBehaviour>().setSelected(true);
            }
        }
        
        Debug.Log("Tile index: " + tileIndex);
    }

    public void startMovement(GameObject initialTile) {
        Debug.Log("Game started");
        currentTile = initialTile;
        StartCoroutine(tileCountdown());
    }

    private bool movePlayer() {
        if (targetTiles != null && targetTiles.Count > 0) {
            currentTile.GetComponent<TileBehaviour>().setCurrent(false);
            currentTile = targetTiles[tileIndex];
            currentTile.GetComponent<TileBehaviour>().setCurrent(true);
            return true;
        }
        return false;
    }
}
