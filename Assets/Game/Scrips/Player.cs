using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public bool canTripleShot = false;
    public bool canSpeed = false;//boots
    public bool canShieldTwo = false;
    [SerializeField]
    private bool isPlayerOne = false;
    [SerializeField]
    private bool isPlayerTwo = false;

    [SerializeField]
    private GameObject Shield;

    private float horizontalInput;
    private float horizontalInput2;
    private float verticalInput;
    private float verticalInput2;
    [SerializeField]
    private float speed = 5.0f;
    //private Vector3 targetPosition;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float fireRate = 0.25f; // time laser * 0.25 seconds
    private float canFire = 0.0f;
    [SerializeField]
    public int live = 3;
    [SerializeField]
    private GameObject explosionPrefab;
    
    private UIManager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject[] _engines;
    private int hitCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {

        Shield.SetActive(false);

        //_uiManager = GameObject.FInd("Canvas").GetComponent<UIManager>();
        _gameManager = Component.FindObjectOfType<GameManager>();

        if(_gameManager.isCoopMode == false){

            transform.position = new Vector3(0, 0, 0);
        }


        _uiManager = Component.FindObjectOfType<UIManager>();

        if(_uiManager != null)
        {
            _uiManager.UpdateLives(live);
        }

        _audioSource = GetComponent<AudioSource>();

        //hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(isPlayerOne){

            Move();
            shoot();
        }

        if(isPlayerTwo){

            MovePlayerTwo();
            shootPlayerTwo();
        }

    }


    void shoot()
    {
        // Button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && isPlayerOne)
        {

            if (Time.time > canFire) // config laser 
            {
                _audioSource.Play();    // Add Audio

                canFire = Time.time + fireRate;
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

                if (canTripleShot){ // power up triple laser 
                    
                    Instantiate(laserPrefab, transform.position + new Vector3(0.52f, -0.08f, 0), Quaternion.identity);
                    Instantiate(laserPrefab, transform.position + new Vector3(-0.52f, -0.08f, 0), Quaternion.identity);
                }

            }

        }
    }

    void shootPlayerTwo()
    {
        // Button
        if (Input.GetKeyDown(KeyCode.X) && isPlayerTwo)
        {

            if (Time.time > canFire) // config laser 
            {
                _audioSource.Play();    // Add Audio

                canFire = Time.time + fireRate;
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

                if (canTripleShot){ // power up triple laser 
                    
                    Instantiate(laserPrefab, transform.position + new Vector3(0.52f, -0.08f, 0), Quaternion.identity);
                    Instantiate(laserPrefab, transform.position + new Vector3(-0.52f, -0.08f, 0), Quaternion.identity);
                }

            }

        }
    }

    void Move(){

        if (canSpeed)   //  power up +1.5 speed
        {
            speed = 6.5f;

        }

        if(Input.GetKey(KeyCode.RightArrow)){

            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.LeftArrow)){

            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.UpArrow)){

            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.DownArrow)){

            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

       limit();

    }

     void MovePlayerTwo(){

        if (canSpeed)   //  power up +1.5 speed
        {
            speed = 6.5f;

        }

        if(Input.GetKey(KeyCode.D)){

            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.A)){

            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.W)){

            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.S)){

            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

       limit();

    }

    public void limit(){

         // Limits
        if (transform.position.y < -4.150984)
        {

            transform.position = new Vector3(transform.position.x, -4.150984f, 0);
        }
        else if (transform.position.y > 4.171737)
        {

            transform.position = new Vector3(transform.position.x, 4.171737f, 0);
        }
        else if (transform.position.x < -8.31915)
        {

            transform.position = new Vector3(-8.31915f, transform.position.y, 0);
        }
        else if (transform.position.x > 8.312319)
        {

            transform.position = new Vector3(8.312319f, transform.position.y, 0);
        }

    }

    public void TripleShotPowerupOn() // active funcion for TripleShotPowerDownRoutine()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine() // power up  * 5 seconds
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;

    }

    public void SpeedPowerupOn()
    {
        canSpeed = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public void ShieldPowerupOn()
    {
        //canShield = true;
        Shield.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }

    public IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeed = false;
        speed = 5.0f;
    }

    public IEnumerator ShieldPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        //canShield = false;
        Shield.SetActive(false);
    }

    public void EnableShields()
    {
        canShieldTwo = true;
        Shield.SetActive(true);
    }

    public void Damage()
    {

        if (canShieldTwo)
        {

            canShieldTwo = false;
            Shield.SetActive(false);
            return;
            
        }

        hitCount++;

        if (hitCount == 1)
        {
            _engines[0].SetActive(true);


        }
        else if (hitCount == 2)
        {
            _engines[1].SetActive(true);
        }


        live--;
        _uiManager.UpdateLives(live);

        if (live < 1)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            _uiManager.ShowTitleScreen();
            Destroy(this.gameObject);

        }

    }


}
