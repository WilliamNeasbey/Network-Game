using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.Netcode;
using TMPro;

public class FinishLine : NetworkBehaviour
{
    [SerializeField] private TMP_Text positionTextPrefab;
    [SerializeField] private Transform positionTextSpawnPoint;
    [SerializeField] private int maxCharacters = 50;

    private int finishedCount = 0;
    private CharacterDatabase characterDatabase;
    private TMP_Text[] positionTexts;

    private void Start()
    {
        characterDatabase = Resources.Load<CharacterDatabase>("CharacterDatabase");

        positionTexts = new TMP_Text[maxCharacters];
        for (int i = 0; i < maxCharacters; i++)
        {
            var positionText = Instantiate(positionTextPrefab, positionTextSpawnPoint);
            positionText.gameObject.SetActive(false);
            positionTexts[i] = positionText;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var character = other.GetComponent<Network2DCharacter>();
        if (character == null || !character.IsLocalPlayer)
        {
            return;
        }

        finishedCount++;
        int position = characterDatabase.GetAllCharacters().Length - finishedCount + 1;
        if (position > maxCharacters)
        {
            return;
        }

        var positionText = positionTexts[0];
        positionText.text = $"You finished in position {position}";
        positionText.gameObject.SetActive(true);
    }
}