using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera normalCam , scopeCam;
    public Camera cam;                        
   
    public GameObject bullet_prefab;
    public GameObject crosshair, redDot;
    GameObject bulletInstansiated;
    public Transform shootPoint;

    public Slider sensitivity_slider;
    float sensitivity = 0.1f;
    public float x_min, x_max;
    public float y_min, y_max;
    float xRot, yRot;
    public float shootForce = 50f;
    float xGet, yGet;
    float mouse_x;
    float mouse_y;

    private Vector3 firstpoint; //change type on Vector3
    private Vector3 secondpoint;
    private float xAngle = 0.0f; //angle for axes x for rotation
    private float yAngle = 0.0f;
    private float xAngTemp = 0.0f; //temp variable for angle
    private float yAngTemp = 0.0f;

    Vector2 input;
    Vector3 initCamRot , initGunRot;

    bool scopeIsOff = true;

   // public GameObject buttonUI;
        
    #region Windows Input
    void LookController()                                                       
    {
       // CursorLock();
        yRot += Input.GetAxis("Mouse X") * sensitivity;
        xRot += Input.GetAxis("Mouse Y") * sensitivity;
        if (xRot >= x_min && xRot <= x_max)
        {
            cam.transform.eulerAngles = new Vector3(-xRot, yRot, 0);
            //cam.eulerAngles = new Vector3(-xRot, yRot, 0);
            transform.eulerAngles = new Vector3(-xRot, yRot, 0);
        }
        if (xRot < x_min)
        {
            xRot = x_min;
        }

        if (xRot > x_max)
        {
            xRot = x_max;
        }

        if (yRot < y_min)
        {
            yRot = y_min;
        }

        if (yRot > y_max)
        {
            yRot = y_max;
        }
    }


    void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    #endregion                                       
   public  void BulletShooter()
    {    
           bulletInstansiated  = Instantiate(bullet_prefab ,shootPoint);
           bulletInstansiated.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
    }


    public void ScopeOn()
    {
        if(scopeIsOff)
        {
            normalCam.enabled = false;
            scopeCam.enabled = true;
            cam = scopeCam;
            crosshair.SetActive(false);
            redDot.SetActive(true);
            scopeIsOff = false;
        }

        else
        {
            normalCam.enabled = true;
            scopeCam.enabled = false;
            cam = normalCam;
            crosshair.SetActive(true);
            redDot.SetActive(false);
            scopeIsOff = true;
        }
     
    }


#region android input
    void AndroidLooker()
    {
        if (Input.touchCount > 0)
        {
            //Touch began, save position
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
            //Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width * sensitivity;
                yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height * sensitivity;
                //Rotate camera
                if (xAngle < x_min)
                {
                    xAngle = x_min;
                }

                if (xAngle > x_max)
                {
                    xAngle = x_max;
                }

                if (yAngle < y_min)
                {
                    yAngle = y_min;
                }

                if (yAngle > y_max)
                {
                    yAngle = y_max;
                }

                cam.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
            }
        }
    }
    #endregion

    void Start()
    {
        xAngle = 0.0f;
        yAngle = 0.0f;
        
        cam.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        scopeCam.enabled = false;
        normalCam.enabled = true;
        redDot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        sensitivity = sensitivity_slider.value;
        AndroidLooker();
        //  CursorLock();
     /*   if(Application.platform != RuntimePlatform.Android)
        {
          //  buttonUI.SetActive(false);
            LookController();
        }*/
        
    }
}
