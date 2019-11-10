using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundTileManager : MonoBehaviour {

    static public GroundTileManager S;
    List<GroundTile> groundTiles = new List<GroundTile>();
    public Mesh sharedMesh;
    public GameObject groundTilePrefab;

    private void Awake()
    {
        if (S != null)
            Destroy(gameObject);
        S = this;
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SpawnTiles(30);
    }

    public void SpawnTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(groundTilePrefab);
            GroundTile gt = go.GetComponent<GroundTile>();
            if (i < amount - 10)
                gt.Initialize(new Vector3(i - 10, -5, 0));
            else if (i < amount - 5)
                gt.Initialize(new Vector3(i - 15, -2, 0));
            else
                gt.Initialize(new Vector3(i - 25, 1, 0));
        }
        
    }


}
