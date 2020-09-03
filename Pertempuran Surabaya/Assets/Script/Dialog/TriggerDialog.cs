using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public Dialog dialog;
    
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        GameObject.Destroy(this);
    }
}
