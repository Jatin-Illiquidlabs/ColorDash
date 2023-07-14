using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMechanic : MonoBehaviour
{
    [SerializeField] List<GameObject> slabs = new List<GameObject>();

    [SerializeField] Vector3 initialPos;
    [SerializeField] Transform point;

    [SerializeField] float moveSpeed;
    [SerializeField] float inbetweenTime;

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            RemoveAllObjects();
        }
    }


    void RemoveAllObjects()
    {
        StartCoroutine(nameof(removeAll));
    }

    IEnumerator removeAll()
    {
        slabs.Reverse();
        foreach (GameObject obj in slabs)
        {
            MoveOBject(obj);
            yield return new WaitForSeconds(inbetweenTime);
        }
    }

    void MoveOBject(GameObject obj)
    {
        obj.transform.parent = null;
        obj.transform.DOLocalMove(point.position, moveSpeed);
        Destroy(obj, moveSpeed + .15f);
    }
}
