using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlacksmithCraft : MonoBehaviour
{
    public TextMeshProUGUI blacksmithTalk;
   
    public GameObject sword1;
    private PlayerC playerSc;
    private int index;
    bool[] SwordResources = new bool[4];
    [SerializeField] AudioSource BlacksmithSound;

    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        playerSc = thePlayer.GetComponent<PlayerC>();
        BlacksmithSound = GetComponent<AudioSource>();
        

}

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnMouseDown()
    {
        if (playerSc.PlayerItems.Count != 0)
        {
            CraftItems();
        }else if(playerSc.PlayerItems.Count == 0) // empty bag message
        { 
            blacksmithTalk.text = "Your Bag is Empty";
            blacksmithTalk.gameObject.SetActive(true);
            playerSc.pickedupMessage.gameObject.SetActive(false);
        }

    }

  void CraftItems()
    {
        if (CraftSword()) // create sword if resource is enough have player
        {
            BlacksmithSound.Play();
            InvokeRepeating("SwordCraftDelay", 7, 7);
            blacksmithTalk.text = "Succesfuly Your Sword is Preparing! in 7 seconds";
            blacksmithTalk.gameObject.SetActive(true);
            playerSc.pickedupMessage.gameObject.SetActive(false);
        }

        else
        {
            //  Debug.Log("You Dont Have Enough Metarial.");
            blacksmithTalk.text = "You Dont Have Enough Metarial.";
            blacksmithTalk.gameObject.SetActive(true);
            playerSc.pickedupMessage.gameObject.SetActive(false);
        }
    }
    bool CraftSword()
    {
        foreach (GameObject o in playerSc.PlayerItems)
        {
           
             
            if (o.CompareTag("Egg") && !SwordResources[0]) // check all reosurces need for sword in list 
            {

                SwordResources[0] = true;
            }
            else if (o.CompareTag("Ash") && !SwordResources[1])
            {

                SwordResources[1] = true;
            }
            else if (o.CompareTag("UndeadBone") && !SwordResources[2])
            {

                SwordResources[2] = true;
            }
            else if (o.CompareTag("Tooth") && !SwordResources[3])
            {
 SwordResources[3] = true;
            }

        }
        if (SwordResources[0] && SwordResources[1] && SwordResources[2] && SwordResources[3]) // check metarials
        {
            return true;
        }
        return false;

    }

    void SwordCraftDelay()
    {
        Instantiate(sword1, transform.position + new Vector3(1, 0, 0), transform.rotation);
    }
        
    }
