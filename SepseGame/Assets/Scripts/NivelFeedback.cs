using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NivelFeedback : MonoBehaviour
{
    [SerializeField]
    GameObject StarCount;
    public string nivel;
    
    // Start is called before the first frame update
    void Start()
    {
        getNivel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getNivel() { 
        nivel = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        nivel = nivel.Remove(0, 5);
        nivel = "caso" + nivel;
        nivel = nivel.Replace(" ", "");
        Debug.Log("caso" + nivel);

    }
}
