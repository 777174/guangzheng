using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class elevator : MonoBehaviour
{
    private Transform elevata;
    [HideInInspector]
    public bool isUp;
    [HideInInspector]
    public bool isDown;
    public Transform target1;
    public Transform target2;
    public Warning warning;
    

    public Key key;

    private void Start()
    {
        elevata = this.transform;
    }
    // Start is called before the first frame update

    public virtual void Up()
    {
        if (!key.LockUp || key.istaken)
        {
            if (!isUp)
            {

                transform.DOMove(target1.position, 3f);

                isUp = true;
                isDown = false;
            }
        }
        else
        {
            warning.ShowPanel();
        }

    }

    public virtual void Down()
    {
        if (key.LockUp || key.istaken)
        {
            if (!isDown)
            {
                transform.DOMove(target2.position, 3f);
                isDown = true;
                isUp = false;
            }
        }
        else
        {

            warning.ShowPanel();
        }
    
    }
    

    

}
