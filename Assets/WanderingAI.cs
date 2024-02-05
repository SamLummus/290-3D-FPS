using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool isAlive;

    void Start() {
        isAlive = true;
    }
    void Update()
    {
        if (isAlive) {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            
            if (hitObject.GetComponent<PlayerCharacter>()) {

                if (fireball == null) {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }

            else if (hit.distance < obstacleRange) {

                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void setAlive(bool alive) {

        isAlive = alive;
    }
}
