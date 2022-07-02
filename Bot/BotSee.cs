using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BotSee : MonoBehaviour
{
    public float fov;

    private Transform Target { get; set; }


    public Transform GetTarget()
    {
        if (Target == null)
        {
            if (FindTarget() != null)
            {
                Target = FindTarget().transform;
            }
        }

        return Target;
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public bool DoISeeObject(Transform target)
    {
        var direction = target.position - transform.position;

        var angle = Mathf.Acos(Vector3.Dot(transform.forward.normalized, direction.normalized)) * Mathf.Rad2Deg;

        return angle <= fov;
    }

    public bool DistanseToObject(Transform target, float distanseToSee)
    {
        if (DoISeeObject(target))
        {
            float distanse = Vector3.Distance(transform.position, target.position);

            if (distanse <= distanseToSee)
            {
                return true;
            }
        }

        return false;
    }


    GameObject FindTarget()
    {
        foreach (GameObject obj in GetObjectThatISee())
        {
            if (obj.GetComponent<Health.IHealth>() != null)
            {
                if (obj != gameObject)
                {
                    if (obj.TryGetComponent(out WarSideManager warSideManager))
                    {
                        if (obj.GetComponent<WarSideManager>().GetWarSide() != GetComponent<WarSideManager>().GetWarSide())
                        {
                            return obj;
                        }
                    }
                }
            }
        }

        return null;
    }

    [SerializeField] 
    private float _seeRange;

    public Transform raycastStartPoint;
    
    [SerializeField] 
    private int _deviationRayFromCenter;

    [SerializeField]
    private List<GameObject> _objectsThatISee;

    public List<GameObject> GetObjectThatISee()
    {
        See();
        return _objectsThatISee;
    }

    public bool DoISeeObjectTwo(GameObject _objectToCheak)
    {
        See();
        
        foreach (GameObject obj in GetObjectThatISee())
        {
            if (obj == _objectToCheak)
            {
                return true;
            }
        }

        return false;
    }
    
    public bool DistanseToObjectTwo(GameObject _objectToCheak, float _distanseToAttack)
    {
        float oldDistanse = _seeRange;
        _seeRange = _distanseToAttack;
        See();
        foreach (GameObject obj in GetObjectThatISee())
        {
            if (obj == _objectToCheak)
            {
                _seeRange = oldDistanse;
                return true;
            }
        }
        _seeRange = oldDistanse;
        return false;
    }
    
    private void See()
    {
        _objectsThatISee = new List<GameObject>();
        
        for (float i = 0f; i < _deviationRayFromCenter;)
        {
            i += 0.1f;
            RayOfVision(Vector3.left, i);
            RayOfVision(Vector3.right, i);
        }
        for (float i = 0f; i < _deviationRayFromCenter / 2;)
        {
            i += 0.02f;
            RayOfVision(Vector3.left + Vector3.down, i);
            RayOfVision(Vector3.left + Vector3.up, i);
            RayOfVision(Vector3.right + Vector3.up, i);
            RayOfVision(Vector3.right + Vector3.down, i);
        }
    }

    private void RayOfVision(Vector3 addVector, float addToVector)
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastStartPoint.position, transform.forward + addVector * addToVector, out hit, _seeRange))
        {
            foreach (GameObject obj in _objectsThatISee)
            {
                if (hit.collider.gameObject == obj)
                {
                    return;
                }
                if (hit.collider.gameObject == gameObject)
                {
                    return;
                }
            }
            _objectsThatISee.Add(hit.collider.gameObject);
        }
    }
}
