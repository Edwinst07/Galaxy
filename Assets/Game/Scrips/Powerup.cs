using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    private float speed = 3.0f;
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        Debug.Log("Collision with: " + other.name);

        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if(player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotPowerupOn();
                        break;
                    case 1:
                        player.SpeedPowerupOn();
                        break;
                /*    case 2:
                        player.ShieldPowerupOn();
                        break; */
                    case 3:
                        player.EnableShields();
                        break;
                    default:
                        break;
                }
                    
                
            }


            Destroy(this.gameObject);
        }
            

    }
}
