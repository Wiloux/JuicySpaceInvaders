using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemy
{

    void Start()
    {
        player = FindObjectOfType<Player>();

        projectileCD = Random.Range(3, projectileCDDurMinMax.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfObstruction())
        {
            return;
        };
        if (projectileCD >= 0)
        {
            projectileCD -= Time.deltaTime;
        }
        else
        {
            Shoot();
        }
        //   SetSprite(CheckIfSeen(player.transform) ? sprite : ghostSprite);

    }

}
