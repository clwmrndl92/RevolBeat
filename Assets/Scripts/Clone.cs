using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public static GameObject perfectNote = null;
    public static GameObject greatNote = null;
    public static GameObject goodNote = null;
    public static GameObject touchNote = null;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Perfect")
        {

            if (perfectNote == null)
            {
                perfectNote = Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            }
            else if (perfectNote != this)
                Destroy(this.gameObject);
        }
        else if (gameObject.tag == "Great")
        {

            if (greatNote == null)
            {
                greatNote = Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            }
            else if (greatNote != this)
                Destroy(this.gameObject);
        }
        else if (gameObject.tag == "Good")
        {

            if (goodNote == null)
            {
                goodNote = Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            }
            else if (goodNote != this)
                Destroy(this.gameObject);
        }
        else
        {

            if (touchNote == null)
            {
                touchNote = Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity) as GameObject;
            }
            else if (touchNote != this)
                Destroy(this.gameObject);
        }
        
    }
}
