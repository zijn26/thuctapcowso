using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   void Update()
{
    float radius = 5f;  // Bán kính 0.5 đơn vị
    RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.right, 10f);
    
    // Vẽ tia (vẫn dùng Debug.DrawRay để hình dung đường đi)
    Debug.DrawRay(transform.position, Vector2.right * 10f, Color.green);
    Debug.DrawRay(transform.position, Vector2.up * 10f, Color.green);
    Debug.DrawRay(transform.position, Vector2.down * 10f, Color.green);
    Debug.DrawRay(transform.position, Vector2.left * 10f, Color.green);
    Debug.DrawRay(transform.position, Vector2.right * 15f, Color.red);
    if (hit.collider != null)
    {
        Debug.Log("CircleCast trúng: " + hit.collider.gameObject.name);
    }
}

}
