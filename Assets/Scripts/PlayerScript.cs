using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterMotor))]
public class PlayerScript : MonoBehaviour 
{
    public float maxVelocity = 20f;
    public float laneSpace = 7f;
    private CharacterMotor motor;
    private string debugMessage;
    private float lastVelocity;
    private Sword swordClass;
    private Bomb bombClass;
    private Acid acidClass;
    private GameObject camera;

    //GUI Icons
    public Texture2D swordOn;
    public Texture2D swordOff;
    public Texture2D bombOn;
    public Texture2D bombOff;
    public Texture2D acidOn;
    public Texture2D acidOff;

	//sounds
	public AudioClip swordSound;
	//public AudioClip acidSound;

	// Use this for initialization
	void Start () 
    {
        motor = GetComponent<CharacterMotor>();
        
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        
        //Add Sword
        this.gameObject.AddComponent<Sword>();
        swordClass = GetComponent<Sword>();
        //Add Bomb
        this.gameObject.AddComponent<Bomb>();
        bombClass = GetComponent<Bomb>();
        //Add Acid
        this.gameObject.AddComponent<Acid>();
        acidClass = GetComponent<Acid>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerSwitchLanes();
        if (Input.GetKeyDown(KeyCode.Mouse0))
		{
            if (swordClass.isReady)
				{
					AudioSource.PlayClipAtPoint(swordSound, transform.position);
                	swordClass.Attack();
				}
		}
        if (Input.GetKeyDown(KeyCode.Mouse1))
            bombClass.Attack(DetectForward());
        if(Input.GetKeyDown(KeyCode.Space))
			{
				//AudioSource.PlayClipAtPoint(acidSound, transform.position);
            	acidClass.Attack(DetectForward());
			}
	}

    void FixedUpdate()
    {
        PlayerMovement();
    }

    public float DetectForward()
    {
        return this.gameObject.transform.forward.z;
    }


    void OnGUI()
    {
        //Sword
        if (swordClass.isReady)
            GUI.Box(new Rect((Screen.width / 12f), (Screen.height - 50), 40, 40), swordOff);
        else
            GUI.Box(new Rect((Screen.width / 12f), (Screen.height - 50), 40, 40), swordOff);

        //Bomb
        if (bombClass.isReady)
            GUI.Box(new Rect(2*(Screen.width / 12f), (Screen.height - 50), 40, 40), bombOn);
        else
            GUI.Box(new Rect(2*(Screen.width / 12f), (Screen.height - 50), 40, 40), bombOff);

        
        //Acid
        if (acidClass.isReady)
            GUI.Box(new Rect(3*(Screen.width / 12f), (Screen.height - 50), 40, 40), acidOn);
        else
            GUI.Box(new Rect(3*(Screen.width / 12f), (Screen.height - 50), 40, 40), acidOff);

    }

    private void PlayerSwitchLanes()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (this.gameObject.transform.position.z >= 21)
            {
                gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 21);
                camera.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 21);
            }
            else
            {
                gameObject.transform.position += new Vector3(0, 0, laneSpace);
                camera.transform.position += new Vector3(0, 0, laneSpace);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (this.gameObject.transform.position.z <= -7)
            {
                gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -7);
                camera.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -7);
            }
            else
            {
                gameObject.transform.position += new Vector3(0, 0, -laneSpace);
                camera.transform.position += new Vector3(0, 0, -laneSpace);
            }
        }
    }

    private void PlayerMovement()
    {
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (directionVector != Vector3.zero)
        {
            //Normalize the vector(give length of 1)
            var directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            //Make sure it's no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }
        debugMessage = (directionVector).ToString();

        if (directionVector.x > 0)
            transform.rotation = new Quaternion(0, 180, 0, 0);
        if (directionVector.x < 0)
            transform.rotation = new Quaternion(0, 0, 0, 0);
        
        motor.inputMoveDirection = directionVector;
        lastVelocity = directionVector.x;
    }

    //Creating at player's mouse location within a range, otherwise is set at farthest distance
    void LayTrap()
    {
        GameObject mine = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mine.transform.position = (Input.mousePosition);
    }
}
