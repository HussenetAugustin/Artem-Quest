using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Etats
{
    etat1,
    etat2,
    etat3,
    etat4,
    etat5,
    etat6
}


public class Contexte
{

    Etats etat_courrant;

    void fonction1()
    {
        switch (etat_courrant)
        {
            case Etats.etat1:
                return;
            case Etats.etat2:
                return;
            case Etats.etat3:
                return;
            case Etats.etat4:
                return;
            case Etats.etat5:
                return;
            case Etats.etat6:
                return;
        }
    }
}
