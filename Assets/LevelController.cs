using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PlayerController> Players;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("P1SwitchCharacter"))
        {
            var characters = Players.Where(player=>player.playerNum==1).ToList();
            for (int i = 0;i<characters.Count();i++){
                if(characters[i].active){
                    characters[i].active = false;
                    var activateIndex = i == characters.Count()-1 ? 0 : i + 1;
                    characters[activateIndex].active=true;
                    break;
                }
            }
        }
        if (Input.GetButtonDown("P2SwitchCharacter"))
        {
            var characters = Players.Where(player=>player.playerNum==2).ToList();
            for (int i = 0;i<characters.Count();i++){
                if(characters[i].active){
                    characters[i].active = false;
                    var activateIndex = i == characters.Count()-1 ? 0 : i + 1;
                    characters[activateIndex].active=true;
                    break;
                }
            }
        }
    }
}
