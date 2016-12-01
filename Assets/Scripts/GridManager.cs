using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {
    private Dictionary<GameObject, List<GameObject>> connections = new Dictionary<GameObject, List<GameObject>>();
    private PlayerBehaviour pb;

	// Use this for initialization
	void Start () {
        pb = GameObject.Find("GameManager").GetComponent<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        //foreach (KeyValuePair<GameObject, List<GameObject>> source in connections) {
        //    foreach (GameObject gameObject in source.Value) {
        //        //TODO: update card connections visuals
        //        Debug.Log("Key: " + source.Key.transform.position + " / Value: " + gameObject.transform.position);
        //    }
        //}
	}

    public void addConnection(GameObject source, GameObject target) {
        Debug.Log("Connection added");

        if (!connections.ContainsKey(source)) {
            connections.Add(source, new List<GameObject>() {target});
        }
        else if(!connections[source].Contains(target)) {
            connections[source].Add(target);
        }
    }

    public List<GameObject> getConnections(GameObject source) {
        if (connections.ContainsKey(source)) {
            return connections[source];
        }
        return null;
    }

    public void removeConnection(GameObject source, GameObject target) {
        if (connections.ContainsKey(source)) {
            target.GetComponent<TileBehaviour>().setSelected(false);
            connections[source].Remove(target);
        }
    }
}
