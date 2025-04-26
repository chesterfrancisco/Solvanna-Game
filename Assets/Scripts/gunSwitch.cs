using UnityEngine;

public class gunSwitch : MonoBehaviour
{
    public GameObject inttext, lights;
    public AudioSource pickup;
    public bool toggle, interactable;
    //public Animator switchAnim;

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

    private void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;

                //switchAnim.SetTrigger("press");
            }
        }
    }
}
