using System.Drawing;
using UnityEngine;

public class RefactoredGameController : GameControllerBase, Icommand
{
    RefactoredUIController rUIController;
    RefactoredPlayerController rPlayerController;

    private void Start()
    {
        rUIController = GameObject.FindAnyObjectByType<RefactoredUIController>();
        rPlayerController = GameObject.FindAnyObjectByType<RefactoredPlayerController>();
    }

    public override PlayerControllerBase PlayerController => rPlayerController;

    public virtual void Execute(Vector3 point)
    {
        if (rUIController != null)
        {
            rUIController.OnArrowShot();
        }
    }
    public void GameEnding()
    {
        if(rUIController != null)
        {
            //rUIController.GameOverOVerlay();
        }
    }
    public override void ProcessShot(Vector3 point)
    {
        base.ProcessShot(point);
        Execute(point);
    }
}