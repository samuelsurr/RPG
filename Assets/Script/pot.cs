using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator anim; // making a reference to the animator


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  //this will complete the reference to animator
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()//this is public because we want to be able to access this function from something else
    {
        anim.SetBool("smash", true); //this says that if this function is conencted set smash bool to true which will activate the animation.
        StartCoroutine(breakCo());//this is the function to start BreakCo
    }

    IEnumerator breakCo() //this is the function for breakCo
    {
        yield return new WaitForSeconds(.3f); //Wait for .3 seconds
        this.gameObject.SetActive(false);//this makes the object inactive making it easier to load and unloading
    }    
}
