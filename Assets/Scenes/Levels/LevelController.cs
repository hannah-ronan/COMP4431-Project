using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PlayerController> Players;
    void Start()
    {
        var TwoPlayerModeOn = PlayerPrefs.GetInt("TwoPlayerModeOn", 0) != 0;
        if(TwoPlayerModeOn){
            Players[0].playerNum=1;
            Players[0].active = true;
            Players[1].playerNum=1;
            Players[1].active = false;
            Players[2].playerNum=2;
            Players[2].active = true;
            Players[3].playerNum=2;
            Players[3].active = false;
            foreach(var player in Players)
            {
                player.UpdateArrowSprite();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("P1SwitchCharacter"))
        {
            var characters = Players.Where(player=>player.playerNum==1).ToList();
            for (int i = 0;i<characters.Count;i++){
                if(characters[i].active){
                    characters[i].active = false;
                    var activateIndex = i == characters.Count-1 ? 0 : i + 1;
                    characters[activateIndex].active=true;
                    break;
                }
            }
        }
        if (Input.GetButtonDown("P2SwitchCharacter"))
        {
            var characters = Players.Where(player=>player.playerNum==2).ToList();
            for (int i = 0;i<characters.Count;i++){
                if(characters[i].active){
                    characters[i].active = false;
                    var activateIndex = i == characters.Count-1 ? 0 : i + 1;
                    characters[activateIndex].active=true;
                    break;
                }
            }
        }
    }
}
