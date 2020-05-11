using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    // Visisble Varaibles
    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float RotateAngle;
    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float MouseSensitivity;
    [SerializeField]
    private float CrystalHideDelay;
    [SerializeField]
    private GameObject Crystal;

    //Hidden Varaibles
    private GameObject Sphere;
    private SphereMovement SphereMovement;
    private float MousePosX;
    private Renderer CrystalRenderer;

    private void Awake()
    {
        CrystalRenderer = Crystal.GetComponent<Renderer>();
        Sphere = GameObject.FindGameObjectWithTag("Player");
        SphereMovement = Sphere.GetComponent<SphereMovement>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SphereMovement.SetVelocity(gameObject.transform.forward);
            StartCoroutine(HideCrystal(CrystalHideDelay));
        }

        if (Input.GetMouseButtonDown(0))
        {
            MousePosX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x >= MousePosX + MouseSensitivity)
            {
                MousePosX = Input.mousePosition.x;
                transform.Rotate(new Vector3(0.0f, RotateAngle, 0.0f));
            }
            if (Input.mousePosition.x <= MousePosX - MouseSensitivity)
            {
                MousePosX = Input.mousePosition.x;
                transform.Rotate(new Vector3(0.0f, -RotateAngle, 0.0f));
            }
        }

        if(SphereMovement.GetVelocity() == Vector3.zero && !CrystalRenderer.enabled)
        {
            transform.position = new Vector3(Sphere.transform.position.x, 0.0f, Sphere.transform.position.z);
            CrystalRenderer.enabled = true;
        }

        IEnumerator HideCrystal(float time)
        {
            yield return new WaitForSeconds(time);

            CrystalRenderer.enabled = false;
            // Code to execute after the delay
        }

    }
}
