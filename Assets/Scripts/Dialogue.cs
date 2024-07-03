using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text textOB;
    public GameObject Activator;
    public float timer = 2f;
    public string dialogue = "Dialogue";

    void Start()
    {
        textOB.GetComponent<Text>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textOB.GetComponent<Text>().enabled = true;
            textOB.text = dialogue;
            StopAllCoroutines();
            StartCoroutine(DisableText());
        }
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        textOB.GetComponent<Text>().enabled = false;
        Destroy(Activator);
    }
}
