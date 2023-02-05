using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject camera;

    public Sprite player;
    public float speed;
    public float health;
    public float strength;
    public float gravity;
    public int facing;

    int shootTimer = 20;

    public GameObject lAmmo;
    public GameObject rAmmo;

    public GameObject[] enemies;

    float xD;
    float yD;

    GameObject hm;

    bool crouching = false;

    bool canJump;
    bool gRequired;
    float pull;
    
    void Start()
    {
        facing = 1;

        hm = GameObject.Find("HM");

        camera = GameObject.Find("MainCamera");
        enemies = camera.GetComponent<LevelController>().enemies;

        canJump = true;
        gRequired = true;
        pull = 1f;
    }

    void Update()
    {
        // Checks

        shootTimer--;

        hm.GetComponent<Text>().text = "Health: " + health;

        if (health <= 0){
            die();
        }

        if (isVictory() && transform.position.x > 8.14){
            victory();
        }

        if (facing == 1){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }else{
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (crouching){
            
        }

        // Player movement control

        if (Input.GetKey(KeyCode.A)){
            xD = -speed;
            facing = 0;
        } else if (Input.GetKey(KeyCode.D)){
            xD = speed;
            facing = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            crouching = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            crouching = false;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            xD = 0;
        }

        if (Input.GetKey(KeyCode.Space) && canJump){
            canJump = false;
            gRequired = true;
            pull = 10f;
        }

        //Player combat

        //Shooting

        if (Input.GetKey(KeyCode.F) && shootTimer <= 0){
            shoot(facing);
            shootTimer = 20;
        }

        // Gravity

        if (gRequired && pull > -gravity){
            pull -= 0.2f;
        }

        transform.position += new Vector3(xD, pull, 0) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "ground"){
            grounded();
        }else if (col.gameObject.tag == "leftproj" || col.gameObject.tag == "rightproj"){
            Destroy(col.gameObject);
            health -= 10;
        }
    }

    void grounded(){
        pull = 0;
        canJump = true;
        gRequired = false;
    }

    bool isVictory(){
        for (int i = 0; i < enemies.Length; i++){
            if (enemies[i] != null){
                if (enemies[i].tag == "enemy"){
                    return false;
                }
            }
        }
        return true;
    }

    void die(){
        SceneManager.LoadScene("Dead", LoadSceneMode.Single);
    }

    void shoot(int dir){
        if (dir == 0){
            Instantiate(lAmmo, new Vector3(transform.position.x - 1f, transform.position.y, 0), Quaternion.identity);
        }else{
            Instantiate(rAmmo, new Vector3(transform.position.x + 1f, transform.position.y, 0), Quaternion.identity);
        }
    }

    void victory(){
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        int level = PlayerPrefs.GetInt("level");

        if (level < 5){
            SceneManager.LoadScene("Decision", LoadSceneMode.Single);
        }else if (level == 5){
            SceneManager.LoadScene("FinalSplash", LoadSceneMode.Single);
        }else{
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }

        
    }

}
