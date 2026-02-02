using UnityEngine;
using UnityEngine.UI;

public class KeynoteButtonScript : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event keynoteSFX;
    [SerializeField] private AK.Wwise.Switch keynoteD;
    [SerializeField] private Button thisButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisButton.onClick.AddListener(TaskOnClick);
        keynoteD.SetValue(gameObject); //Tämä vaihdetaan kun state vaihtuu. Voisi tehdä staten avullakin vaikka tulevaisuudessa
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void TaskOnClick()
    {
        Debug.Log("Perusääni");
        keynoteSFX.Post(gameObject);
    }
}
