using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    private UIManager _uiManager;
    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-7.94f, 7.99f), 8.0f, 0);

        //_uiManager = GameObject.FInd("Canvas").GetComponent<UIManager>();
        _uiManager = Component.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        transform.Translate(speed * Vector3.down * Time.deltaTime);

        if (transform.position.y < -7)
        {
            transform.position = new Vector3(Random.Range(-8.31915f, 4.171737f), 8.0f, 0);
        }

        if (transform.position.x < -8.31915)
        {

            transform.position = new Vector3(-8.31915f, transform.position.y, 0);
        }
        else if (transform.position.x > 8.312319)
        {

            transform.position = new Vector3(8.312319f, transform.position.y, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with: " + other.name);

        if(other.tag == "Player")
        {

            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            //Destroy(enemyExplosionPrefab);
            

        }else if(other.tag == "Laser")
        {
            //_uiManager.UpdateScore();
            Destroy(other.gameObject);
            
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
            Destroy(this.gameObject);
            
        }

    }
}
