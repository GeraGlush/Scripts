using UnityEngine;

public class RandomMoveTerritory : MonoBehaviour
{
   public Transform[] randomMovePoints;

   void Start()
   {
       randomMovePoints = GetComponentsInChildren<Transform>();
   }
}
