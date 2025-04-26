using UnityEngine;

public class PickupGun : MonoBehaviour
{
    public GameObject inttext,gun_table,gun_hand;
    public AudioSource pickup;
    public bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
                {
                inttext.SetActive(false);
                interactable = false;
                //pickup.Play();
                gun_hand.SetActive(true);
                gun_table.SetActive(false);

            }
        }
    }

}
