using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Maze : MonoBehaviour
{

    [SerializeField]
    private int wallLength;

    [SerializeField]
    private int width;
    
    [SerializeField]
    private int height;

    [SerializeField]
    private GameObject wall;

    [SerializeField]
    private Transform parent;

    bool [,] horizontalPaths;
    bool [,] verticalPaths;

    //How the maze works is like this:
    //There are 2 2d Arrays that stores the wall that is in between 2 tiles
    //If that element is true, it means that there is no wall between those 2 tiles
    
    void Start()
    {
        
        //Array thing
       horizontalPaths = new bool [height,width-1];
       verticalPaths = new bool [width,height-1];

       
       //Randomly puts true in arrays
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
       
       
        
       Debug.Log("Vertical Paths");
       StringBuilder sb = new StringBuilder();
       for(int i=0; i< width; i++)
       {
           for(int j=0; j<height-1; j++)
           {
               sb.Append(verticalPaths [i,j]);
               sb.Append(' ');				   
           }
           sb.AppendLine();
       }
       Debug.Log(sb.ToString());
       
       Debug.Log("Horizontal Paths");
        sb = new StringBuilder();
       for(int i=0; i< height; i++)
       {
           for(int j=0; j<width-1; j++)
           {
               sb.Append(horizontalPaths [i,j]);
               sb.Append(' ');				   
           }
           sb.AppendLine();
       }
       Debug.Log(sb.ToString());
    
       
       Draw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Draws the maze
    void Draw()
    {

        // Width of Maze divided by 2 
        float offsetX = (width * wallLength /2.0f);
        
        // Height of Maze divided by 2
        float offsetY = (height * wallLength / 2.0f);
        
        //Angle of wall rotated 90* (vertical)
        var horizontalAngle = wall.transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        //Main Walls
        GameObject thing =Instantiate(wall, new Vector2(0, offsetY), Quaternion.identity, parent);
        thing.transform.localScale = new Vector2(wallLength *width + 0.25f, 0.25f);
        thing =Instantiate(wall, new Vector2(0, -offsetY), Quaternion.identity, parent);
        thing.transform.localScale = new Vector2(wallLength *width + 0.25f, 0.25f);
        thing =Instantiate(wall, new Vector2(offsetX, 0), horizontalAngle, parent);
        thing.transform.localScale = new Vector2(wallLength *height + 0.25f, 0.25f);
        thing = Instantiate(wall, new Vector2(-offsetX, 0), horizontalAngle , parent);
        thing.transform.localScale = new Vector2(wallLength *height + 0.25f, 0.25f);
        
        //Horizontal paths (vertical lines)
        for (int i = 0; i < width-1; i++)
        {
            int size = 0;

            int last = 0;
            
            for (int j = 0; j < height; j++)
            {

                if (!horizontalPaths[j,i])
                {
                    size++;
                }
                else
                {
                    if (size != 0)
                    {
                        GameObject mald = Instantiate(wall, new Vector2(((i + 1) * wallLength) - offsetX, (-(last * wallLength) + offsetY - (j * wallLength) + offsetY) / 2.0f), horizontalAngle, parent);
                        mald.transform.localScale = new Vector2(wallLength * size + 0.25f, 0.25f);
                    }

                    last = j+1;
                    size = 0;
                }

            }
            
            if (size != 0)
            {

                GameObject mald =Instantiate(wall, new Vector2(((i+1)*wallLength) - offsetX, (-(last*wallLength))/2.0f), horizontalAngle, parent);
               mald.transform.localScale = new Vector2(wallLength * size + 0.25f, 0.25f);
            }
            
        }


        //vertical paths (vertical lines)
        for (int i = 0; i < height-1; i++)
        {
            int size = 0;

            int last = 0;
            
            for (int j = 0; j < width; j++)
            {

                if (!verticalPaths[j,i])
                {
                    size++;
                }
                else
                {
                    if (size != 0)
                    {
                        GameObject mald = Instantiate(wall, new Vector2((-(last * wallLength) + offsetX - (j * wallLength) + offsetY) / 2.0f, ((i + 1) * wallLength) - offsetY) ,  Quaternion.identity, parent);
                        mald.transform.localScale = new Vector2(wallLength * size + 0.25f, 0.25f);
                    }

                    last = j+1;
                    size = 0;
                }

            }
            
            if (size != 0)
            {

                GameObject mald =Instantiate(wall, new Vector2( (-(last*wallLength))/2.0f,((i+1)*wallLength) - offsetY),  Quaternion.identity, parent);
                mald.transform.localScale = new Vector2(wallLength * size + 0.25f, 0.25f);
            }
            
        }
        
    }
}
