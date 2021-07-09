using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodC : MonoBehaviour
{
    public GameObject Food;
    
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
        
        transform.Rotate(0, 20 * Time.deltaTime, 0);
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "obstacles")
        {

        
            if (other.tag == "Player")
            {
                FindObjectOfType<AudioManager>().playSound("food");
                PlayerManager.numberofFoods += 1;
                Debug.Log("Foods :" + PlayerManager.numberofFoods);
                Destroy(gameObject);
                foodSpawn();
            }
        }
    }

    void foodSpawn()
    {
        Vector3 position = new Vector3(Random.Range(1.16f, 2.47f), -0.83f, Food.transform.position.z * 5);
        Instantiate(Food, position, Quaternion.identity);
    }

    
}
