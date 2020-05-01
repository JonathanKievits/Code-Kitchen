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
    private int randomOrder;

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
        randomOrder = Random.Range(0, 3);
        readyToOrder = true;
        if (readyToOrder == true)
        {
            switch (randomOrder)
            {
                case 0:
                    SpawnOrderBurger();
                    break;
                case 1:SpawnOrderPizza();
                    break;
                case 2:
                    SpawnOrderHotDog();
                    break;
            }
            
        }
    }

    // in SpawnOrderBurger all burger Ingredients are added in order. 
    private void SpawnOrderBurger()
    {
        int orderNumber = 0;
        GameObject topbun = Instantiate(Burger["TopBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        topbun.transform.parent = _orderHolder[orderNumber];
        topbun.name = "BurgerTopBun";
        orderNumber += 1;
        GameObject sauce = Instantiate(Burger["sauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        sauce.transform.parent = _orderHolder[orderNumber];
        sauce.name = "BurgerSauce";
        orderNumber += 1;
        GameObject patty = Instantiate(Burger["Patty"], _orderHolder[orderNumber].position, Quaternion.identity);
        patty.transform.parent = _orderHolder[orderNumber];
        patty.name = "BurgerPatty";
        orderNumber += 1;
        GameObject bottombun = Instantiate(Burger["BottomBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        bottombun.transform.parent = _orderHolder[orderNumber];
        bottombun.name = "BurgerBottomBun";

    }

    // in SpawnOrderPizza all pizza Ingredients are added in order. 
    private void SpawnOrderPizza()
    {
        int orderNumber = 0;
        int randomExtraIngredients = Random.Range(0, 3);
        GameObject sauce = Instantiate(Pizza["extraSauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        sauce.transform.parent = _orderHolder[orderNumber];
        sauce.name = "PizzaSauce";
        orderNumber += 1;
        for(int i = 0; i < randomExtraIngredients; i++)
        {
            int randomIngredient = Random.Range(0, 4);
            switch (randomIngredient)
            {
                case 0:
                    GameObject mozarella = Instantiate(Pizza["Mozarella"], _orderHolder[orderNumber].position, Quaternion.identity);
                    mozarella.transform.parent = _orderHolder[orderNumber];
                    mozarella.name = "PizzaMozarella";
                    orderNumber += 1;
                    break;
                case 1:
                    GameObject pesto = Instantiate(Pizza["Pesto"], _orderHolder[orderNumber].position, Quaternion.identity);
                    pesto.transform.parent = _orderHolder[orderNumber];
                    pesto.name = "PizzaPesto";
                    orderNumber += 1;
                    break;
                case 2:
                    if (StaticK.Difficulty >= 1)
                    {
                        GameObject pineapple = Instantiate(Pizza["PineApple"], _orderHolder[orderNumber].position, Quaternion.identity);
                        pineapple.transform.parent = _orderHolder[orderNumber];
                        pineapple.name = "PizzaPineApple";
                        orderNumber += 1;
                    }
                    else
                    {
                        i -= 1;
                    }

                    break;
                case 3:
                    if(StaticK.Difficulty >= 1)
                    {
                        GameObject salami = Instantiate(Pizza["Salami"], _orderHolder[orderNumber].position, Quaternion.identity);
                        salami.transform.parent = _orderHolder[orderNumber];
                        salami.name = "PizzaSalami";
                        orderNumber += 1;
                    }
                    else
                    {
                        i -= 1;
                    }

                    break;
            }
        }
        GameObject tomato = Instantiate(Pizza["TomatoSauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        tomato.transform.parent = _orderHolder[orderNumber];
        tomato.name = "PizzaTomato";
        orderNumber += 1;
        GameObject dough = Instantiate(Pizza["Dough"], _orderHolder[orderNumber].position, Quaternion.identity);
        dough.transform.parent = _orderHolder[orderNumber];
        dough.name = "PizzaDough";
    }

    // in SpawnOrderHotDog all hotdog Ingredients are added in order. 
    private void SpawnOrderHotDog()
    {
        int orderNumber = 0;
        int randomIngredient = Random.Range(0,3);
        Debug.Log(randomIngredient);
        if (randomIngredient >= 2 && StaticK.Difficulty >= 1)
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
        For burgers the sauce can be one of 3 things to give more variety. .
     */

    private void AddIngrdientsToList()
    {
        int sauceNumber = Random.Range(0, 2);
        int pizzaSauceNumber = Random.Range(4, 6);
        Burger.Add("TopBun", _baseRecipe[0]);
        Burger.Add("BottomBun", _baseRecipe[1]);
        Burger.Add("Patty", _meat[0]);
        Burger.Add("sauce", _sauce[sauceNumber]);
        Hotdog.Add("Union", _extra[0]);
        Hotdog.Add("sauce", _sauce[2]);
        Hotdog.Add("meat", _meat[1]);
        Hotdog.Add("Bread", _baseRecipe[2]);
        Pizza.Add("Dough", _baseRecipe[3]);
        Pizza.Add("Salami", _meat[2]);
        Pizza.Add("TomatoSauce", _sauce[3]);
        Pizza.Add("extraSauce", _sauce[pizzaSauceNumber]);
        Pizza.Add("Mozarella", _extra[1]);
        Pizza.Add("Pesto", _extra[2]);
        Pizza.Add("PineApple", _extra[3]);
    }
}
