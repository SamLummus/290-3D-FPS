using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;

    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) {

            // int randomHeight = Random.Range(20, 50);

            enemy = Instantiate(enemyPrefab) as GameObject;
            //Changes the enemies height using localScale
            enemy.transform.localScale += new Vector3(0, Random.Range(-10,15), 0);
            enemy.transform.position = new Vector3(0, 64, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            //Grabs the renderer for the enemy instance
            MeshRenderer render= enemy.GetComponent<MeshRenderer>();

            if (render != null) {
            
            render.material.color = new Color(Random.value, Random.value, Random.value);
        }
        }

        
    }
}
