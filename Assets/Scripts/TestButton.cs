using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    void Start()
    {
        Button myButton = btn.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(){
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null){
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            pm.triggerEvent = true;
        }
    }
}
