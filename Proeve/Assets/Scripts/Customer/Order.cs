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
    private bool chickenOrBeef = false;
    private int randomOrder;

    //In this start all ingredients are added to one big list, and a order is generated.
    void Start()
    {

        AddIngrdientsToList();
        //SpawnOrderBurger();
        //SpawnOrderHotDog();
        GenerateOrder();
    }

    
    public void GenerateOrder()
    {
        randomOrder = Random.Range(0, 2);
        readyToOrder = true;
        if (readyToOrder == true)
        {
            switch (randomOrder)
            {
                case 0:
                    SpawnOrderBurger();
                    break;
                case 1:
                    SpawnOrderHotDog();
                    break;
                case 2:
                    SpawnOrderPizza();
                    break;
            }
            
        }
    }

    // in SpawnOrderBurger all burger Ingredients are added in order. 
    private void SpawnOrderBurger()
    {
        int orderNumber = 0;
        int cheeseUnion = 1;
        int chickenorpatty = Random.Range(0, 2);
        GameObject bottombun = Instantiate(Burger["BottomBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        bottombun.transform.parent = _orderHolder[orderNumber];
        bottombun.name = "BurgerBottomBun";
        orderNumber += 1;
        GameObject patty = Instantiate(Burger["Patty"], _orderHolder[orderNumber].position, Quaternion.identity);
        patty.transform.parent = _orderHolder[orderNumber];
        patty.name = "BurgerPatty";
        orderNumber += 1;
        /*switch (chickenorpatty)
        {
            case 0:
                GameObject patty = Instantiate(Burger["Patty"], _orderHolder[orderNumber].position, Quaternion.identity);
                patty.transform.parent = _orderHolder[orderNumber];
                patty.name = "BurgerPatty";
                orderNumber += 1;
                chickenOrBeef = false;
                break;
            case 1:
                GameObject chicken = Instantiate(Burger["Chicken"], _orderHolder[orderNumber].position, Quaternion.identity);
                chicken.transform.parent = _orderHolder[orderNumber];
                chicken.name = "BurgerChicken";
                orderNumber += 1;
                chickenOrBeef = true;
                break;
        }*/
        GameObject lettuce = Instantiate(Burger["Lettuce"], _orderHolder[orderNumber].position, Quaternion.identity);
        lettuce.transform.parent = _orderHolder[orderNumber];
        lettuce.name = "BurgerLettuce";
        orderNumber += 1;
        GameObject tomato = Instantiate(Burger["Tomato"], _orderHolder[orderNumber].position, Quaternion.identity);
        tomato.transform.parent = _orderHolder[orderNumber];
        tomato.name = "BurgerTomato";
        orderNumber += 1;
        for (int i = 0; i < cheeseUnion; i++)
        {
            int ingredientAmount = 0;
            if (chickenOrBeef == true){
                ingredientAmount = 0;
            }
            else {
                ingredientAmount = Random.Range(0, 2);
            }
                    
            switch (ingredientAmount)
            {
                case 0:
                    GameObject union = Instantiate(Burger["Union"], _orderHolder[orderNumber].position, Quaternion.identity);
                    union.transform.parent = _orderHolder[orderNumber];
                    union.name = "BurgerUnion";
                    orderNumber += 1;
                    break;
                case 1:
                    GameObject cheese = Instantiate(Burger["Cheese"], _orderHolder[orderNumber].position, Quaternion.identity);
                    cheese.transform.parent = _orderHolder[orderNumber];
                    cheese.name = "BurgerCheese";
                    orderNumber += 1;
                    break;
            }
        }
        /*
        GameObject sauce = Instantiate(Burger["sauce"], _orderHolder[orderNumber].position, Quaternion.identity);
        sauce.transform.parent = _orderHolder[orderNumber];
        sauce.name = "BurgerSauce";
        orderNumber += 1; */
        GameObject topbun = Instantiate(Burger["TopBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        topbun.transform.parent = _orderHolder[orderNumber];
        topbun.name = "BurgerTopBun";
        orderNumber += 1;

    }

    // in SpawnOrderPizza all pizza Ingredients are added in order. 
    private void SpawnOrderPizza()
    {
        int orderNumber = 0;
        int randomExtraIngredients = Random.Range(0, 3);
        GameObject sauce = Instantiate(Pizza["ExtraSauce"], _orderHolder[orderNumber].position, Quaternion.identity);
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
        int randomSauce = Random.Range(0,2);
        Debug.Log(randomIngredient);
        GameObject bread = Instantiate(Hotdog["Bread"], _orderHolder[orderNumber].position, Quaternion.identity);
        bread.transform.parent = _orderHolder[orderNumber];
        bread.name = "HotdogBase";
        orderNumber += 1;
        GameObject meat = Instantiate(Hotdog["Meat"], _orderHolder[orderNumber].position, Quaternion.identity);
        meat.transform.parent = _orderHolder[orderNumber];
        meat.name = "HotdogMeat";
        orderNumber += 1;
        GameObject sauceketchup = Instantiate(Hotdog["SauceKetchup"], _orderHolder[orderNumber].position, Quaternion.identity);
        sauceketchup.transform.parent = _orderHolder[orderNumber];
        sauceketchup.name = "HotdogSauce";
        orderNumber += 1;
        /*switch (randomSauce)
        {
            case 0:
                GameObject sauceketchup = Instantiate(Hotdog["SauceKetchup"], _orderHolder[orderNumber].position, Quaternion.identity);
                sauceketchup.transform.parent = _orderHolder[orderNumber];
                sauceketchup.name = "HotdogSauce";
                orderNumber += 1;
                break;
            case 1:
                GameObject saucemustard = Instantiate(Hotdog["SauceMustard"], _orderHolder[orderNumber].position, Quaternion.identity);
                saucemustard.transform.parent = _orderHolder[orderNumber];
                saucemustard.name = "HotdogSauce";
                orderNumber += 1;
                break;
        }*/
        if (randomIngredient >= 2 && StaticK.Difficulty >= 1)
        {
            GameObject union = Instantiate(Hotdog["Union"], _orderHolder[orderNumber].position, Quaternion.identity);
            union.transform.parent = _orderHolder[orderNumber];
           union.name = "HotdogUnion";
        }
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
        Burger.Add("Chicken", _meat[3]);
        Burger.Add("Sauce", _sauce[sauceNumber]);
        Burger.Add("Cheese", _extra[4]);
        Burger.Add("Union", _extra[5]);
        Burger.Add("Lettuce", _vegetables[0]);
        Burger.Add("Tomato", _vegetables[1]);
        Hotdog.Add("Union", _extra[0]);
        Hotdog.Add("SauceKetchup", _sauce[2]);
        Hotdog.Add("SauceMustard", _sauce[6]);
        Hotdog.Add("Meat", _meat[1]);
        Hotdog.Add("Bread", _baseRecipe[2]);
        Pizza.Add("Dough", _baseRecipe[3]);
        Pizza.Add("Salami", _meat[2]);
        Pizza.Add("TomatoSauce", _sauce[3]);
        Pizza.Add("ExtraSauce", _sauce[pizzaSauceNumber]);
        Pizza.Add("Mozarella", _extra[1]);
        Pizza.Add("Pesto", _extra[2]);
        Pizza.Add("PineApple", _extra[3]);
    }

    private void ResetOrder()
    {
        for(int i = 0; i < _orderHolder.Count; i++)
        {
            foreach (Transform child in _orderHolder[i])
            {
                GameObject.Destroy(child.gameObject);
            }
        }

    }
}
