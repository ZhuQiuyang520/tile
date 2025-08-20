using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMimetic : BeamNonliving<SpearMimetic>
{

    public void BlueSpear(string info)
    {
        UIMimetic.PenMonopoly().BlueUIBasin("Spear", info);
    }
}
