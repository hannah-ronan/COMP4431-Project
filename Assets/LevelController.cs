using System.Collections;
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
            Players.Where(player=>player.playerNum==1).ToList().ForEach(player=>{
                player.active = !player.active;
            });
        }
        if (Input.GetButtonDown("P2SwitchCharacter"))
        {
            Players.Where(player=>player.playerNum==2).ToList().ForEach(player=>{
                player.active = !player.active;
            });
        }
    }
}
