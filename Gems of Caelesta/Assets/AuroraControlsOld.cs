using System.Collections;
using Prime31;
using System.Collections.Generic;
using UnityEngine;
public class AuroraControlsOld : MonoBehaviour
{
   public CharacterController2D cc2d;

   float xaxismove = 0f;
   float auroraSpeed = 3f;
   Rigidbody2D rbd;
   
   public void Start()
   {
      rbd = GetComponent<Rigidbody2D> ();
      //pc2d = GetComponent<PolygonCollider2D> ();
   }
   
   /*void control()
   {
      if(Input.GetKeyDown(KeyCode.RightArrow))
      {
         //transform.position = Vector2.right * (float)(auroraSpeed) * Time.deltaTime;
         rbd.velocity = new Vector2(-(rbd.velocity.y), auroraSpeed);
      }

      if(Input.GetKeyDown(KeyCode.LeftArrow))
      {
         //transform.position = Vector2.left * (float)(auroraSpeed) * Time.deltaTime;
         rbd.velocity = new Vector2(rbd.velocity.y, auroraSpeed);
      }

      if(Input.GetKeyDown(KeyCode.UpArrow))
      {
         rbd.velocity = new Vector2(rbd.velocity.x, auroraJump);
         //rbd.velocity = rbd.AddForce(Vector2.up * (auroraJump) * Time.deltaTime); //why cant i jump?
      }
   }*/
   void Update()
   {
      xaxismove = Input.GetAxisRaw("Horizontal") * auroraSpeed;
   }

   void FixedUpdate() 
   {
      //cc2d.move((new Vector2((xaxismove * Time.fixedDeltaTime), 0)));
      return;
   }

   /*private void OnTriggerEnter2D(Collider2D col)
   {
      /*if(col.gameObject.CompareTag("RedGem"))
      {
         Debug.Log(col.gameObject.name + " detected. It has the tag " + col.tag);
         Destroy(col.gameObject);
      }
      if(col.gameObject.CompareTag("RedGem"))
      {
         rgs.RedGemsCollected();
         Destroy(col.gameObject);
         rg++;
      }
   }*/
}
