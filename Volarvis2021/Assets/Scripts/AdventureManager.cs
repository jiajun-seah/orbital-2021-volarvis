using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public void visitMeadows()
    {
        GoOnAdventure.instance.visitMeadows();
    }
    public void visitTangle()
    {
        GoOnAdventure.instance.visitTangle();
    }
    public void visitPeaks()
    {
        GoOnAdventure.instance.visitPeaks();
    }
    public void visitLava()
    {
        GoOnAdventure.instance.visitLava();
    }
    public void visitCorals()
    {
        GoOnAdventure.instance.visitCorals();
    }
    public void visitGrove()
    {
        GoOnAdventure.instance.visitGrove();
    }
    public void visitChateau()
    {
        GoOnAdventure.instance.visitChateau();
    }
    public void visitCave()
    {
        GoOnAdventure.instance.visitCave();
    }

    public void forceReturn()
    {
        GoOnAdventure.instance.forceReturnAdventure();
    }
}
