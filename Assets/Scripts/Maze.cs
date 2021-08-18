using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{

    [SerializeField]
    private int width;
    
    [SerializeField]
    private int height;

    [SerializeField]
    private GameObject wallLength;
    
    [SerializeField]
    private GameObject wallBlock;
    
    [SerializeField]
    private Transform parent;

    bool [,] horizontalPaths ;
    bool [,] verticalPaths;

    // Start is called before the first frame update
    void Start()
    {
        
       horizontalPaths = new bool [height,width-1];
       verticalPaths = new bool [width,height-1];

       for (int i = 0; i < height; i++)  
       {
           for (int j = 0; j< width-1; j++)  
           {
                //horizontal
                int random = Random.Range(0, 3);
                if (random > 1)
                {
                    horizontalPaths[i,j] = true;
                }

           }
       }
       
       for (int i = 0; i < width; i++)  
       {
           for (int j = 0; j< height-1; j++)  
           {
               //vertical
               int random = Random.Range(0, 3);
               if (random > 1)
               {
                   verticalPaths[i,j] = true;
               }
           }
       }
       Draw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Draw()
    {

        float offsetX = (width / 2 * 4 + 4);
        float offsetY = (height / 2 * 4 + 2);
        var horizontalAngle = wallLength.transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        for (int i = 1; i <= width; i++) 
        {
            
            Instantiate(wallLength, new Vector2((4*i)- offsetX, 0- offsetY), Quaternion.identity, parent);
            Instantiate(wallLength, new Vector2((4*i)- offsetX, height*4-offsetY), Quaternion.identity, parent);
        }
        
        for (int i = 1; i <= height; i++) 
        {
            Instantiate(wallLength, new Vector2(0-offsetY, (4*i)-offsetX), horizontalAngle, parent);
            Instantiate(wallLength, new Vector2(width*4-offsetY, (4*i)-offsetX), horizontalAngle , parent);
        }
        
        for (int i = 1; i <= height; i++)  
        {
            for (int j = 1; j<= width-1; j++)  
            {
                if (horizontalPaths[i-1, j-1] != true)
                {
                    Instantiate(wallLength, new Vector2( 4 *j -(offsetY),    (-4 *i) + offsetX ),horizontalAngle, parent);
                }
            }
        }

        for (int i = 1; i <= width; i++) 
        {
            for (int j = 1; j<= height-1; j++)  
            {
                if (verticalPaths[i-1, j-1] != true)
                {
                    Instantiate(wallLength, new Vector2(4 *i -((offsetX)), 4 *j -((offsetX))+2) , Quaternion.identity, parent);
                }
            }
        }
        
        for (int i = 0; i <= height; i++)  
        {
            for (int j = 0; j<= width; j++)  
            {
                Instantiate(wallBlock, new Vector2((4*i)- offsetX + 2, 4*j -((offsetY))), Quaternion.identity, parent);
            }
        }
    }
}
