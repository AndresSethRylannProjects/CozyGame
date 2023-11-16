using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    // To be changed i.e only temporary movement script
    public List<Sprite> northSprites;
    public List<Sprite> northEastSprites;
    public List<Sprite> southSprites;
    public List<Sprite> southEastSprites;
    public List<Sprite> eastSprites;
    public float walkSpeed;
    public float frameRate;
    Vector2 direction;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }
}
