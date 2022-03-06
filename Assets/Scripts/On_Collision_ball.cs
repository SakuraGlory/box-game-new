using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class On_Collision_ball : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
      
     
    
    }        
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.tag== "box")
         {
           
            Destroy(other.gameObject); 
             
         } 

        if (other.gameObject.tag== "keerda")
        {
             
             Destroy(this.gameObject);
             
             SceneManager.LoadScene("level6");
        }
    }

}