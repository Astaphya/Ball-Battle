using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigid;
    private GameObject focalPoint;
    private float powerUpStrength = 15f;
 
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    private float outOfBounds = -10f;

    public float speed = 5f;
    public VariableJoystick variableJoystick;
    [SerializeField] GameObject pcGuide;

  
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        myRigid.AddForce(focalPoint.transform.forward * speed  * vertical ); // FocalPoint'in baktığı yönün playerın yönü haline getiriyoruz.

        #if UNITY_ANDROID

            variableJoystick.gameObject.SetActive(true);
             Vector3 direction = focalPoint.transform.forward * variableJoystick.Vertical ;
            myRigid.AddForce(direction * speed * Time.fixedDeltaTime , ForceMode.VelocityChange);
            pcGuide.gameObject.SetActive(false);
            
        #endif

        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0); // Powerup Indicator'u offset vererek player'ı takip etmesini sağlıyoruz.

        if(transform.position.y < outOfBounds) // Karakter alanın dışına çıkarsa leveli tekrarla.
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }


   


        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Powerup"))
            {
                hasPowerup = true;
                powerupIndicator.gameObject.SetActive(true);
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
                
            }
        
    }

     IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // Powerup 7sn boyunca player üzerinde olacak!
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength , ForceMode.Impulse); // Forcemode.Impulse tepkinin hemen gerçekleşmesini sağlıyor.
            }   
        
    }
}
