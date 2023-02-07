using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Scene", fileName = "New Scene")]
public class SceneData : ScriptableObject {

    public string Description;
    public List<ChoiceData> ChoiceDatas;
    public Sprite LeftCharacter;
    public Sprite RightCharacter;
    public Sprite Background;
    public AudioClip Music;

}