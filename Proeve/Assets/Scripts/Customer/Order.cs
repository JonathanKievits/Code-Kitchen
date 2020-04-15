using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private GameObject[] baseRecipe;
    [SerializeField] private GameObject[] vegetables;
    [SerializeField] private GameObject[] meat;
    [SerializeField] private GameObject[] sauce;
    [SerializeField] private GameObject[] extra;
    [SerializeField] private List<Transform> OrderHolder;
    Dictionary<string, GameObject> Burger = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Pizza = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Hotdog = new Dictionary<string, GameObject>();
    private bool readyToOrder;

    //In this start all ingredients are added to one big list, and a order is generated.
    void Start()
    {
        AddIngrdientsToList();
        readyToOrder = true;
        if (readyToOrder == true)
        {
            SpawnOrderHotDog();
        }
    }

    // in SpawnOrderBurger all burger Ingredients are added in order. 
    private void SpawnOrderBurger()
    {
        int orderNumber = 0;
        Instantiate(Burger["TopBun"], OrderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["sauce"], OrderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["Patty"], OrderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["BottomBun"], OrderHolder[orderNumber].position, Quaternion.identity);
        
    }

    // in SpawnOrderPizza all pizza Ingredients are added in order. 
    private void SpawnOrderPizza()
    {
        int orderNumber = 0;
        Instantiate(Burger["TopBun"], OrderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["sauce"], OrderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["Patty"], OrderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["BottomBun"], OrderHolder[orderNumber].position, Quaternion.identity);
    }

    // in SpawnOrderHotDog all hotdog Ingredients are added in order. 
    private void SpawnOrderHotDog()
    {
        int orderNumber = 0;
        GameObject union = Instantiate(Hotdog["Union"], OrderHolder[orderNumber].position, Quaternion.identity);
        union.transform.parent = OrderHolder[orderNumber];
        orderNumber += 1;
        GameObject sauce = Instantiate(Hotdog["sauce"], OrderHolder[orderNumber].position, Quaternion.identity);
        sauce.transform.parent = OrderHolder[orderNumber];
        orderNumber += 1;
        GameObject meat = Instantiate(Hotdog["meat"], OrderHolder[orderNumber].position, Quaternion.identity);
        meat.transform.parent = OrderHolder[orderNumber];
        orderNumber += 1;
        GameObject bread = Instantiate(Hotdog["Bread"], OrderHolder[orderNumber].position, Quaternion.identity);
        bread.transform.parent = OrderHolder[orderNumber];
    }

    /*
        In the AddIngredientsToList function all possible ingredients are added to the right lists.
        In the inspector they are added to a few lists, and now they are added to a dictionary for the right order.
        This is so we can call out the name of the ingredient while making the order.
        For burgers the sauce can be one of 3 things to give more variety. 
     */

    private void AddIngrdientsToList()
    {
        int sauceNumber = Random.Range(0, 4);
        Burger.Add("TopBun", baseRecipe[0]);
        Burger.Add("BottomBun", baseRecipe[1]);
        Burger.Add("Patty", meat[0]);
        Burger.Add("sauce", sauce[sauceNumber]);
        Hotdog.Add("Union", extra[0]);
        Hotdog.Add("sauce", sauce[3]);
        Hotdog.Add("meat", meat[1]);
        Hotdog.Add("Bread", baseRecipe[2]);
    }
}
