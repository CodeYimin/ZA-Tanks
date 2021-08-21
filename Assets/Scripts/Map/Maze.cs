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
       verticalPaths = new bool [height-1, width];

       
       
       Generate();
       Randomly(10);
       // printOutDebug();
       Draw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Generate the Maze
    void Generate()
    {
        
        Stack <string> history = new Stack<string>();
        bool [,] visited = new bool [height, width];
        visited[0, 0] = true;
        history.Push("0,0");
        while (history.Count != 0)
        {
            
            bool up = false;
            bool down = false;
            bool left = false;
            bool right = false;

            int counter = 0;
            ArrayList  selection = new ArrayList();
            
            int xCurrent = int.Parse(history.Peek().Substring(0,history.Peek().IndexOf(',')));
            int yCurrent = int.Parse(history.Peek().Substring(history.Peek().IndexOf(',')+1));

            //left
            if (xCurrent > 0  && visited[yCurrent, xCurrent-1] != true)
            {
                left = true;
                selection.Add("left");
                counter++;
            } 
            
            //right
            if (xCurrent < height-1 && visited[yCurrent, xCurrent+1] != true)
            {
                right = true;
                selection.Add("right");
                counter++;
            }
            
            //up
            if (yCurrent > 0 && visited[yCurrent -1, xCurrent] != true)
            {
                up = true;
                selection.Add("up");
                counter++;
            } 
            
            //down
            if (yCurrent < width-1 && visited[yCurrent +1, xCurrent] != true)
            {
                down = true;
                selection.Add("down");
                counter++;
            }

            if (up || down || left || right)
            {
                
                int randomInt = Random.Range(0, counter);

                if (selection[randomInt].Equals("up"))
                {
                    
                    visited[yCurrent-1, xCurrent] = true;
                    string tempString = xCurrent + "," + (yCurrent - 1);
                    history.Push(tempString);
                    verticalPaths[yCurrent-1, xCurrent] = true;
                }
                
                if (selection[randomInt].Equals("down"))
                {
                    
                    visited[yCurrent+1, xCurrent] = true;
                    string tempString = xCurrent + "," + (yCurrent +1);
                    history.Push(tempString);
                    verticalPaths[yCurrent , xCurrent] = true;
                }
                
                if (selection[randomInt].Equals("left"))
                {
                    visited[yCurrent, xCurrent-1] = true;
                    string tempString = (xCurrent-1) + "," + yCurrent;
                    history.Push(tempString);
                    horizontalPaths[yCurrent , xCurrent -1] = true;
                        
                }
                
                if (selection[randomInt].Equals("right"))
                {
                    visited[yCurrent, xCurrent+1] = true;
                    string tempString = (xCurrent+1) + "," + yCurrent;
                    history.Push(tempString);
                    horizontalPaths[yCurrent , xCurrent] = true;
                }
                
            }
            else
            {
                history.Pop();
            }

        }
    }

    //Randomly puts paths in the map
    void Randomly(int percentage)
    {
        //Randomly puts true in arrays
        for (int i = 0; i < height; i++)  
        {
            for (int j = 0; j< width-1; j++)  
            {
                //horizontal
                int random = Random.Range(0, 101);
                if (random < percentage)
                {
                    horizontalPaths[i,j] = true;
                }

            }
        }
        for (int j = 0; j< height-1; j++)  
        {
            for (int i = 0; i < width; i++)  
            {
                //vertical
                int random = Random.Range(0, 101);
                if (random < percentage)
                {
                    verticalPaths[j,i] = true;
                }
            }
        }
    }

    //Prints out the 2d arrays
    void PrintOutDebug()
    {
        Debug.Log("Vertical Paths");
        StringBuilder sb = new StringBuilder();
        for(int j=0; j<height-1; j++)
        {
            for(int i=0; i< width; i++)
            {
           
                sb.Append(verticalPaths [j,i]);
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

                if (!verticalPaths[i,j])
                {
                    size++;
                }
                else
                {
                    if (size != 0)
                    {
                        GameObject mald = Instantiate(wall, new Vector2(((last * wallLength) - offsetX + (j * wallLength) - offsetX) / 2.0f, (-(i + 1) * wallLength) + offsetY) ,  Quaternion.identity, parent);
                        mald.transform.localScale = new Vector2(wallLength * size + 0.25f, 0.25f);
                    }

                    last = j+1;
                    size = 0;
                }

            }
            
            if (size != 0)
            {
                GameObject mald =Instantiate(wall, new Vector2( ((last*wallLength))/2.0f,(-(i+1)*wallLength) + offsetY),  Quaternion.identity, parent);
                mald.transform.localScale = new Vector2(wallLength * size + 0.25f, 0.25f);
            }
            
        }
        
    }
}
