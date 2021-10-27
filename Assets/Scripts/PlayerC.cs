using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerC : MonoBehaviour
{
    public TextMeshProUGUI gameStart;
    private BlacksmithCraft blacksmithSc;
    public TextMeshProUGUI pickedupMessage;
    public GameObject bagPlayer; // invetory of player
    public List<GameObject> PlayerItems; // resources need for creating items
    public int index = 0;
    private Rigidbody playerRb;
    [SerializeField] float speed=5;
    public Vector3 BagPosition;
    private AudioSource pickupSound;
    public AudioClip pick;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        BagPosition = bagPlayer.transform.position;
        pickupSound = GetComponent<AudioSource>();

        GameObject blacksmith = GameObject.Find("Blacksmith");
        blacksmithSc = blacksmith.GetComponent<BlacksmithCraft>();




    }

    // Update is called once per frame
    void Update()
    {
        movement();
      
     

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            gameStart.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Egg"))
        {
            PlayerItems.Add(Instantiate(Resources.Load("Egg", typeof(GameObject)) as GameObject)); // pick up item when triggered
            pickupSound.Play();
           pickedupMessage.text = "Picked Up an Egg.";
           pickedupMessage.gameObject.SetActive(true);
           blacksmithSc.blacksmithTalk.gameObject.SetActive(false);
            PlayerItems[index].transform.position = BagPosition; // send the items that picked up to bag
            PlayerItems[index].transform.parent = bagPlayer.transform; // set the child of bags that pickedup objects
            index++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("UndeadBone"))
        {
            PlayerItems.Add(Instantiate(Resources.Load("Bone", typeof(GameObject)) as GameObject));
            pickupSound.Play();
         pickedupMessage.text = "Picked Up an Bone.";
            pickedupMessage.gameObject.SetActive(true);
            blacksmithSc.blacksmithTalk.gameObject.SetActive(false);
            PlayerItems[index].transform.position = BagPosition;
            PlayerItems[index].transform.parent = bagPlayer.transform;
            index++;
            Destroy(other.gameObject);      
        }
        if (other.gameObject.CompareTag("Tooth"))
        {
            PlayerItems.Add(Instantiate(Resources.Load("Tooth", typeof(GameObject)) as GameObject));
            pickupSound.Play();
           pickedupMessage.text = "Picked Up an Tooth.";
            pickedupMessage.gameObject.SetActive(true);
            blacksmithSc.blacksmithTalk.gameObject.SetActive(false);
            PlayerItems[index].transform.position = BagPosition;
            PlayerItems[index].transform.parent = bagPlayer.transform;
            index++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Ash"))
        {
            PlayerItems.Add(Instantiate(Resources.Load("WitchsAsh", typeof(GameObject)) as GameObject));
            pickupSound.Play();
           pickedupMessage.text = "Picked Up Ash.";
            pickedupMessage.gameObject.SetActive(true);
            blacksmithSc.blacksmithTalk.gameObject.SetActive(false);
            PlayerItems[index].transform.position = BagPosition;
            PlayerItems[index].transform.parent = bagPlayer.transform;
            index++;
            Destroy(other.gameObject);
        }

    }
   

    void  movement()
    {
        float VI = Input.GetAxis("Vertical");
        float HI = Input.GetAxis("Horizontal");
        Vector3 mov = new Vector3(HI, 0.0f, VI);
        playerRb.AddForce(mov * speed); 
  
       
    }
}
