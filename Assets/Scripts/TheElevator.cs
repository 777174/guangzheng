using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TheElevator:elevator
{
    
    
    public Transform origin;

   


    
    // Start is called before the first frame update

    public override void Up()
    {
        if (!key.LockUp || key.istaken)
        {
            

                transform.DOMove(target1.position, 3f).OnComplete(() =>
                {
                    StartCoroutine(WaitAndReturn());
                });

                
        }
        else
        {
            warning.ShowPanel();
        }

    }

    public override void Down()
    {
        if (key.LockUp || key.istaken)
        {
            
                transform.DOMove(target2.position, 3f);
                isDown = true;
                isUp = false;
            
        }
        else { warning.ShowPanel(); }
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(3f);
        transform.DOMove(origin.position, 3f);
    }

}
