using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public void loadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
