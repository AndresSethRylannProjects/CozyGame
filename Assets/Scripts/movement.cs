using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public ParticleSystem dust;
    float idleTime;
    Vector2 direction;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused){
        direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).normalized;

        body.velocity = direction * walkSpeed;

        // handle directions
        HandleSpriteFlip();

        SetSprite();
        }

    }

    void SetSprite() {
        List<Sprite> directionSprites = GetSpriteDirection();
        if(directionSprites != null) {
            // holding dir
            float playTime = Time.time - idleTime; // how long have we been moving
            int frame = (int)((playTime * frameRate) % directionSprites.Count); // total frames since we started moving
            spriteRenderer.sprite = directionSprites[frame];
        } else {
            // holding nothing
            idleTime = Time.time;
        }
    }

    void HandleSpriteFlip() {
        // if we are facing right and player holds left flip
         if (!spriteRenderer.flipX && direction.x < 0) {
            spriteRenderer.flipX = true;
            dust.Play();
        }
        // inverse
        else if (spriteRenderer.flipX && direction.x > 0) {
            spriteRenderer.flipX = false;
            dust.Play();
        }
    }

    List<Sprite> GetSpriteDirection() {

        List<Sprite> currentSprites = null;

        if(direction.y > 0){
            // north behaviour
            if (Math.Abs(direction.x) > 0) // east or west
            {
                currentSprites = northEastSprites;
            } else { // neutral x
                currentSprites = northSprites;
            }
        } else if(direction.y < 0){
            // south
            if (Math.Abs(direction.x) > 0) // east or west
            {
                currentSprites = southEastSprites;
            } else { // neutral x
                currentSprites = southSprites;
            }
        } else {
           if (Math.Abs(direction.x) > 0) // east or west
            {
                currentSprites = eastSprites;
            }
        }
        return currentSprites;
    }
}
