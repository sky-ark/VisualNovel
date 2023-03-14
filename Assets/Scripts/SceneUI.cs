using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour {

    [Header("Parameters")]
    public SceneData StartingScene;
    public GameObject ButtonPrefab;
    
    [Header("References UI")]
    public TMP_Text SpeakerName;
    public TMP_Text DescriptionText;
    public Transform ChoicesContent;
    public Image LeftCharacterImage;
    public Image RightCharacterImage;
    public Image BackgroundImage;
    public Image CollectibleBox;
    public AudioSource MusicAudioSource;

    private void Awake() {
        Apply(StartingScene);
    }

    public void Apply(SceneData data) {
        if (string.IsNullOrWhiteSpace(data.SpeakerName) || data.SpeakerName == "") {
            SpeakerName.transform.parent.gameObject.SetActive(false);
        }
        else {
            SpeakerName.transform.parent.gameObject.SetActive(true);
            SpeakerName.text = data.SpeakerName;
        }
        DescriptionText.text = data.Description;
        
        // ChoicesContent
        foreach (Transform child in ChoicesContent) {
            Destroy(child.gameObject);
        }
        foreach (ChoiceData choiceData in data.ChoiceDatas) {
            GameObject instantiate = Instantiate(ButtonPrefab, ChoicesContent);
            instantiate.GetComponentInChildren<TMP_Text>().text = choiceData.ChoiceText;
            instantiate.GetComponent<Button>().onClick.AddListener(delegate {
                if (choiceData.haveTheCollectible)
                {
                    CollectibleBox.transform.parent.gameObject.SetActive(true);
                    CollectibleBox.sprite = choiceData.Collectible;
                }

                if (choiceData.useTheCollectible)
                {
                    CollectibleBox.transform.parent.gameObject.SetActive(false);
                    choiceData.haveTheCollectible = false;
                }
                    Apply(choiceData.ChoiceSceneData);
                
            });
        }
        
        
        
        // Characters
        if (data.LeftCharacter == null) {
            LeftCharacterImage.gameObject.SetActive(false);
        }
        else {
            LeftCharacterImage.gameObject.SetActive(true);
            LeftCharacterImage.sprite = data.LeftCharacter;
        }
        if (data.RightCharacter == null) {
            RightCharacterImage.gameObject.SetActive(false);
        }
        else {
            RightCharacterImage.gameObject.SetActive(true);
            RightCharacterImage.sprite = data.RightCharacter;
        }

        // Background
        BackgroundImage.sprite = data.Background;
        // Music
        if(data.Music != null) 
            MusicAudioSource.clip = data.Music;
    }
    
}