using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuseDestroy : MonoBehaviour
{

    public Item wrench;

    public ParticleSystem particle1;
    public ParticleSystem particle2;

    public ParticleSystem particle3;

    public ParticleSystem particle4;
    public ParticleSystem particle5;
    public ParticleSystem particle6;

    public GameObject doorLeft;
    public GameObject doorRight;

    public GameObject biometric;
    
    public GameObject frame;

    public AudioClip secondBgm;

    public AudioSource bgmSource;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
        TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        if (InventoryManager.Instance.HasItem(wrench)) {
            buttonText.SetText("Destroy Fusebox");
            interactButton.onClick.AddListener(DestroyFuse);

        }
        else {
            buttonText.SetText(("Tool Needed"));
            DialogController.instance.DisplayMessage("I need something to destroy this fusebox.");
        }
        }
        
    }

    public void DestroyFuse() {
        // Spawn Sparks
        particle1.Play();
        particle2.Play();
        particle3.Play();
        particle4.Play();
        particle5.Play();
        particle6.Play();

        Debug.Log("done!");

        Destroy(doorLeft);
        Destroy(doorRight);
        Destroy(biometric);
        frame.GetComponent<BoxCollider>().enabled = (false);
        

        DialogController.instance.DisplayMessage("The alarm has been triggered as well. Better be quick.");
        this.GetComponent<AudioSource>().Play();

        bgmSource.GetComponent<AudioSource>().clip = secondBgm;
        


        

        // Trigger sirens etc
        StartCoroutine(ToggleEmergencyLighting());



    }

    IEnumerator ToggleEmergencyLighting() {
        
        for (int i = 0; i < 1000; i++) {
            GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
            foreach(GameObject light in lights) {
                Light lightComp = light.GetComponent<Light>();
                lightComp.intensity = 0.7f;
                lightComp.color = Color.red;
            }
            yield return new WaitForSeconds(4f);

            foreach(GameObject light in lights) {
                Light lightComp = light.GetComponent<Light>();
                lightComp.intensity = 0f;
                // lightComp.color = Color.red;
            }

            yield return new WaitForSeconds(4f);

            foreach(GameObject light in lights) {
                Light lightComp = light.GetComponent<Light>();
                lightComp.intensity = 1.5f;
                lightComp.color = Color.red;
            }

        }
        
    }
    


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
            TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            buttonText.SetText("");
            interactButton.onClick.RemoveListener(DestroyFuse);
        }
    }
}
