using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private GameObject[] _baseRecipe = null;
    [SerializeField] private GameObject[] _vegetables = null;
    [SerializeField] private GameObject[] _meat = null;
    [SerializeField] private GameObject[] _sauce = null;
    [SerializeField] private GameObject[] _extra = null;
    [SerializeField] private List<Transform> _orderHolder = null;
    Dictionary<string, GameObject> Burger = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Pizza = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Hotdog = new Dictionary<string, GameObject>();
    private bool readyToOrder;

    //In this start all ingredients are added to one big list, and a order is generated.
    void Start()
    {
        AddIngrdientsToList();
        GenerateOrder();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateOrder();
        }
    }

    public void GenerateOrder()
    {
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
        Instantiate(Burger["TopBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["sauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["Patty"], _orderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["BottomBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        
    }

    // in SpawnOrderPizza all pizza Ingredients are added in order. 
    private void SpawnOrderPizza()
    {
        int orderNumber = 0;
        Instantiate(Burger["TopBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["sauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["Patty"], _orderHolder[orderNumber].position, Quaternion.identity);
        orderNumber += 1;
        Instantiate(Burger["BottomBun"], _orderHolder[orderNumber].position, Quaternion.identity);
    }

    // in SpawnOrderHotDog all hotdog Ingredients are added in order. 
    private void SpawnOrderHotDog()
    {
        int orderNumber = 0;
        int randomIngredient = Random.Range(0,3);
        Debug.Log(randomIngredient);
        if (randomIngredient >= 2)
        {
            GameObject union = Instantiate(Hotdog["Union"], _orderHolder[orderNumber].position, Quaternion.identity);
            union.transform.parent = _orderHolder[orderNumber];
            union.name = "HotdogUnion";
            orderNumber += 1;
        }
        GameObject sauce = Instantiate(Hotdog["sauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        sauce.transform.parent = _orderHolder[orderNumber];
        sauce.name = "HotdogSauce";
        orderNumber += 1;
        GameObject meat = Instantiate(Hotdog["meat"], _orderHolder[orderNumber].position, Quaternion.identity);
        meat.transform.parent = _orderHolder[orderNumber];
        meat.name = "HotdogMeat";
        orderNumber += 1;
        GameObject bread = Instantiate(Hotdog["Bread"], _orderHolder[orderNumber].position, Quaternion.identity);
        bread.transform.parent = _orderHolder[orderNumber];
        bread.name = "HotdogBase";
    }

    /*
        In the AddIngredientsToList function all possible ingredients are added to the right lists.
        In the inspector they are added to a few lists, and now they are added to a dictionary for the right order.
        This is so we can call out the name of the ingredient while making the order.
        For burgers the sauce can be one of 3 things to give more variety. 
     */

    private void AddIngrdientsToList()
    {
        int sauceNumber = Random.Range(0, 1);
        Burger.Add("TopBun", _baseRecipe[0]);
        Burger.Add("BottomBun", _baseRecipe[1]);
        Burger.Add("Patty", _meat[0]);
        Burger.Add("sauce", _sauce[sauceNumber]);
        Hotdog.Add("Union", _extra[0]);
        Hotdog.Add("sauce", _sauce[2]);
        Hotdog.Add("meat", _meat[1]);
        Hotdog.Add("Bread", _baseRecipe[2]);
    }
}
