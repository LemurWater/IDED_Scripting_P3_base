using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    RefactoredGameController rGameController;

    public static RefactoredPlayerController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   new  private void Start()
    {
        rGameController = GameObject.FindAnyObjectByType<RefactoredGameController>();
        if(rGameController != null)
        {
            ArrowCount = rGameController.Arrows;
        }
        base.Start();
    }

    protected override void ProcessShot(Vector3 point)
    {
        rGameController?.ProcessShot(point);
    }
}