using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private TextMeshProUGUI hitPointUI;
    //public GameObject bulletIndicator;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI() {

        // int size = 12;
        // float posX = cam.pixelWidth/4 - size/4;
        // float posY = cam.pixelHeight/4 - size/2;
        // GUI.Label(new Rect(posX, posY, size, size), "Enemy hit at: " );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            
            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            
            if (target != null) {
                target.ReactToHit(); 
                hitPointUI.text = "Enemy hit at: " + hitObject.transform.position;
                
            }
            else {
                StartCoroutine(SphereIndicator(hit.point));
            }
           
        }
    }
}

    private IEnumerator SphereIndicator(Vector3 pos) {
    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    sphere.transform.position = pos;
    yield return new WaitForSeconds(1);
    Destroy(sphere);
        
    }
}

