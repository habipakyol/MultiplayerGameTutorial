using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class GameUI : MonoBehaviour
{
   public PlayerUIContainer[] playerContainers;
   public TextMeshProUGUI winText;

   public static GameUI instance;

   private void Awake()
   {
      instance = this;
   }

   private void Start()
   {
      InitalizePlayerUI();
   }

   void InitalizePlayerUI()
   {
      for (int x = 0; x < playerContainers.Length; ++x)
      {
         PlayerUIContainer container = playerContainers[x];
         if (x<PhotonNetwork.PlayerList.Length)
         {
            container._obj.SetActive(true);
            container.nameText.text = PhotonNetwork.PlayerList[x].NickName;
            container.hatTimeSlider.maxValue = GameManager.instance.timeToWin;
            
         }
         else
         {
            container._obj.SetActive(false);
            
         }
      }
   }

   private void Update()
   {
      UpdatePlayerUI();
   }

   void UpdatePlayerUI()
   {
      for (int x = 0; x < GameManager.instance.players.Length; ++x) 
      {
         if (GameManager.instance.players[x]!=null)
         {
            playerContainers[x].hatTimeSlider.value = GameManager.instance.players[x].curHatTime;
         }
      }
   }

   public void SetWinText(string winnerName)
   {
      winText.gameObject.SetActive(true);
      winText.text = winnerName + "wins";
   }
}


[System.Serializable]
public class PlayerUIContainer
{
   public GameObject _obj;
   public TextMeshProUGUI nameText;
   public Slider hatTimeSlider;
}
