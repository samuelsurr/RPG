using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public GameObject virtualCamera;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            other.transform.position += playerChange;
            virtualCamera.SetActive(false);
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
          
        }
    }

    private IEnumerator placeNameCo()
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);

    }



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCamera.SetActive(true);
        }
    }


}
