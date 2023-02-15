using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //use this for text
using TMPro;
public class AuroraControls : MonoBehaviour
{
   //public CharacterController2D cc2d;
   public HealthScript healthScript;
   public TextMeshProUGUI countText;
   public TextMeshProUGUI csuper;
   public TextMeshProUGUI countLives;
   public int countRedGems = 0;
   public int countSuperGems = 0;
   public int countLives2 = 3;
   public ForTheSword forTheSword;
   public SuperGemScript sssss;
   public SupergemScriptLevel2 sgsl2;
   public HiddenSuperGemScript h;
   public HiddenSuperGemScriptLevel2 hl2;
   public OptionsSounds o;
   
   //For attacking animation
   public Animator a;

   //Non-jumping variables
   [SerializeField] private float xaxismove = 0f;
   [SerializeField] public float aurorasSpeed = 2f;
   Rigidbody2D rbd;

   public bool isLeft, isRight, veryLeft;

   //Jump variables
   bool siJump = true;
   //float jumpingForce = 5f;

   //Time variables for touching enemy
   private bool touchEnemy;
   private float touchEnemyTime = 2.5f;

   public Sprite s1, s2;

   //Audio variables
   public AudioSource rgSource;
   public AudioClip redGemSound;
   public AudioClip hurtSound;

   public Vector3 respawn;
   public bool c = false;
   
   //Everything else
   public void Start()
   {
      rbd = GetComponent<Rigidbody2D>();
      a = GetComponent<Animator>();
      //animate = GetComponent<Animation>();
      countText.text = countRedGems.ToString();
      csuper.text = countSuperGems.ToString();
      countLives.text = countLives2.ToString();
      rgSource = GetComponent<AudioSource>();
      respawn = transform.position;
      healthScript = GetComponent<HealthScript>();
      countSuperGems = PlayerPrefs.GetInt("supergems");
      sssss.sgshow1 = PlayerPrefs.GetInt("supergembool");
      sgsl2.sgshowlvl2_1 = PlayerPrefs.GetInt("supergemlevel2bool");
      //h.showMe = PlayerPrefs.GetInt("supergemHidingBool");
      o.soundEffectVolume = PlayerPrefs.GetFloat("v1");
   }
   
   void Update()
   {
      xaxismove = Input.GetAxisRaw("Horizontal") * aurorasSpeed;
      rbd.velocity = new Vector2(aurorasSpeed * xaxismove, rbd.velocity.y);
      countText.text = countRedGems.ToString();
      csuper.text = countSuperGems.ToString();
      countLives.text = countLives2.ToString();
      a.SetFloat("auroraSpeed", Mathf.Abs(xaxismove));

      //Moving right
      if(Time.timeScale == 1)
      {
      if(Input.GetKeyDown(KeyCode.RightArrow) && isRight == false)
      {
         isRight = true;
         transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
         a.Play("AuroraWalk");
         if(isLeft == true)
         {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isLeft = false;
         }
      }
      if(Input.GetKey(KeyCode.RightArrow) && isLeft == true && isRight == false && !(Input.GetKey(KeyCode.LeftArrow)))
      {
         Debug.Log("Moon1");
         isLeft = false;
         isRight = true;
         transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
      }
      //Moving left
      if(Input.GetKeyDown(KeyCode.LeftArrow) && isLeft == false)
      {
         isLeft = true;
         transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
         a.Play("AuroraWalk");
         veryLeft = true;
         if(isRight == true)
         {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            isRight = false;
         }
      }
      if(Input.GetKey(KeyCode.LeftArrow) && isRight == true && isLeft == false && !(Input.GetKey(KeyCode.RightArrow)))
      {
         Debug.Log("Moon2");
         isLeft = true;
         veryLeft = true;
         isRight = false;
         transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
      }
      }

      Debug.Log(c);
      Debug.Log(healthScript.clicked);
      Debug.Log("O.Soundeffectvolume: " + o.soundEffectVolume);
      PlayerPrefs.SetInt("supergems", countSuperGems);
      PlayerPrefs.Save();
      PlayerPrefs.SetInt("supergembool", sssss.sgshow1);
      PlayerPrefs.Save();
      PlayerPrefs.SetInt("supergemlevel2bool", sgsl2.sgshowlvl2_1);
      PlayerPrefs.Save();
      PlayerPrefs.SetFloat("v1", o.soundEffectVolume);
      PlayerPrefs.Save();
      //PlayerPrefs.SetInt("supergemHidingBool", h.showMe);
      //PlayerPrefs.Save();
   }

   IEnumerator ChangeToNormal()
   {
      yield return new WaitForSeconds(2.5f); //WaitForSeconds = you wait for a certain amount of time
      //Debug.Log("This works");
      GetComponent<SpriteRenderer>().color = Color.white; //After 2.5 seconds, Aurora should turn white.
   }

   void OnCollisionEnter2D(Collision2D c2d)
   {
      //What to do when hitting the ground
      if(c2d.gameObject.CompareTag("Grass"))
      {
         siJump = false;
      }

      if(c2d.gameObject.CompareTag("DisappearingPlatform"))
      {
         siJump = false;
      }

      if(c2d.gameObject.CompareTag("Checkpoint"))
      {
         siJump = false;
      }

      if(c2d.gameObject.CompareTag("MovingPlatform"))
      {
         siJump = false;
         this.transform.parent = c2d.transform;
         Debug.Log("You're on the moving platform");
      }

      if(c2d.gameObject.CompareTag("UpDownLilac"))
      {
         siJump = false;
         this.transform.parent = c2d.transform;
         Debug.Log("This goes up and down");
      }

      if(c2d.gameObject.CompareTag("Barrel"))
      {
         siJump = false;
      }

      if(c2d.gameObject.CompareTag("Ice"))
      {
         siJump = false;
      }

      if(c2d.gameObject.CompareTag("Log"))
      {
         siJump = false;
      }

      if(c2d.gameObject.CompareTag("DeadlyCrystal"))
      {
         siJump = false;
      }

      //For touching enemies, and getting hurt by them
      if(c2d.gameObject.CompareTag("LarinianSoldier") || c2d.gameObject.CompareTag("LarinianSoldier2"))
      {
         if(forTheSword.forSword == false)
         {
            touchEnemy = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine("ChangeToNormal"); //StartCoroutine runs code simultaneously with your current loop. The rest of the code will continue running but it will also wait.
            //rgSource.clip = hurtSound;
            //rgSource.Play();
            //Debug.Log("Touch");
         }
         if(forTheSword.forSword)
         {
            touchEnemy = false;
            GetComponent<SpriteRenderer>().color = Color.white;
            //Debug.Log("Attack");
         }
      }
   }

   void FixedUpdate() 
   {
      return;
   }

   //FOR COLLECTING RED GEMS
   private void OnTriggerEnter2D(Collider2D c2d)
   {
      //Collecting red gems after the very first one
     /* if(c2d.gameObject.CompareTag("RedGem") || c2d.gameObject.CompareTag("RedGem2"))
      {
         c2d.gameObject.SetActive(false);
         countRedGems++;
         rgSource.clip = redGemSound;
         rgSource.Play();
      }

      //Code for the very first red gem
      if(c2d.gameObject.CompareTag("FirstRedGem"))
      {
         rgSource.clip = redGemSound;
         rgSource.Play();
         c2d.gameObject.SetActive(false);
         countRedGems++;
         //Debug.Log("You collected the game's first red gem");
      }*/

      if(c2d.gameObject.CompareTag("SuperGem"))
      {
         c2d.gameObject.SetActive(false);
         countSuperGems++;
      }

      //111020
      if(c2d.gameObject.CompareTag("Checkpoint"))
      {
         Debug.Log("Checked");
         respawn = c2d.transform.position;
         c = true;
      }

      if(c2d.gameObject.CompareTag("LevelPad1"))
      {
         Debug.Log("Ja!");
      }
   }

   //Do this for collision bugs
   void OnCollisionExit2D(Collision2D collisionInfo)
   {
      if(collisionInfo.gameObject.CompareTag("MovingPlatform"))
      {
         this.transform.parent = null;
         //siJump = true;
      }

      if(collisionInfo.gameObject.CompareTag("UpDownLilac"))
      {
         this.transform.parent = null;
      }
   }

}