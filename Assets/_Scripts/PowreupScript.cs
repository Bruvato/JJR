using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using UnityEngine.UI;

sealed class PowreupScriptAttribute : System.Attribute
{
    // See the attribute guidelines at
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    readonly string positionalString;
    
    // This is a positional argument
    public PowreupScriptAttribute(string positionalString)
    {
        this.positionalString = positionalString;
        
        // TODO: Implement code here
        throw new System.NotImplementedException();
    }
    
    public string PositionalString
    {
        get { return positionalString; }
    }
    
    // This is a named argument
    public int NamedInt { get; set; }
}
public class PowreupScript : MonoBehaviour
{
    [SerializeField] private int numberForFunction;
    [SerializeField] private int axisForSide;
    [SerializeField] private int theRealNumberForFunctionCall;
    [SerializeField] private Button clickerForActive;
    

    private void Awake(){
        clickerForActive.onClick.AddListener(()=>{
            bigManChangerScaler();
        });
    }
    private void Start(){
        numberForFunction = Random.Range(0,10);
        axisForSide = Random.Range(0,2);
        theRealNumberForFunctionCall = Random.Range(0,5);
     
    }

    private void bigManChangerScaler(){
        switch(theRealNumberForFunctionCall){
            case 0: //addition
                switch(axisForSide){
                    case 0:
                    Player.Instance.PlayerScale += new Vector3(numberForFunction, 0, 0);
                    break;

                    case 1:
                    Player.Instance.PlayerScale += new Vector3(0, numberForFunction, 0);
                    break;

                    case 2:
                    Player.Instance.PlayerScale += new Vector3(0, 0, numberForFunction);
                    break;
                }
            break;
            case 1: //multiplicaiton
                switch(axisForSide){
                    case 0:
                    Player.Instance.PlayerScale= Vector3.Scale(Player.Instance.PlayerScale, new Vector3(numberForFunction, 1, 1));
                    break;
                    
                    case 1:
                    Player.Instance.PlayerScale= Vector3.Scale(Player.Instance.PlayerScale, new Vector3(1, numberForFunction, 1));
                    break;

                    case 2:
                    Player.Instance.PlayerScale= Vector3.Scale(Player.Instance.PlayerScale, new Vector3(1, 1, numberForFunction));
                    break;
                }
            break;
            case 2: //^#
                switch(axisForSide){
                    case 0:
                    Player.Instance.PlayerScale= new Vector3(Mathf.Pow(Player.Instance.PlayerScale.x, numberForFunction), Player.Instance.PlayerScale.y, Player.Instance.PlayerScale.z);
                    break;
                    
                    case 1:
                    Player.Instance.PlayerScale= new Vector3(Player.Instance.PlayerScale.x, Mathf.Pow(Player.Instance.PlayerScale.y, numberForFunction), Player.Instance.PlayerScale.z);
                    break;

                    case 2:
                    Player.Instance.PlayerScale= new Vector3(Player.Instance.PlayerScale.x, Player.Instance.PlayerScale.y, Mathf.Pow(Player.Instance.PlayerScale.z, numberForFunction));
                    break;
                }

            break;

            case 3://Subtraction
                switch(axisForSide){
                    case 0:
                    Player.Instance.PlayerScale -= new Vector3(numberForFunction, 0, 0);
                    break;
                    
                    case 1:
                    Player.Instance.PlayerScale -= new Vector3(0, numberForFunction, 0);
                    break;

                    case 2:
                    Player.Instance.PlayerScale -= new Vector3(0, 0, numberForFunction);
                    break;
                }
            break;
            case 4://Division
                switch(axisForSide){
                    case 0:
                    Player.Instance.PlayerScale= Vector3.Scale(Player.Instance.PlayerScale, new Vector3(1/numberForFunction, 1, 1));
                    break;
                    
                    case 1:
                    Player.Instance.PlayerScale= Vector3.Scale(Player.Instance.PlayerScale, new Vector3(1, 1/numberForFunction, 1));
                    break;

                    case 2:
                    Player.Instance.PlayerScale= Vector3.Scale(Player.Instance.PlayerScale, new Vector3(1, 1, 1/numberForFunction));
                    break;
                }
            break;
            case 5://#root
                switch(axisForSide){
                    case 0:
                    Player.Instance.PlayerScale= new Vector3(Mathf.Pow(Player.Instance.PlayerScale.x, 1.0f/numberForFunction), Player.Instance.PlayerScale.y, Player.Instance.PlayerScale.z);
                    break;
                    
                    case 1:
                    Player.Instance.PlayerScale= new Vector3(Player.Instance.PlayerScale.x, Mathf.Pow(Player.Instance.PlayerScale.y, 1.0f/numberForFunction), Player.Instance.PlayerScale.z);
                    break;

                    case 2:
                    Player.Instance.PlayerScale= new Vector3(Player.Instance.PlayerScale.x, Player.Instance.PlayerScale.y, Mathf.Pow(Player.Instance.PlayerScale.z, 1.0f/numberForFunction));
                    break;
                }
            break;
        }
    }


}