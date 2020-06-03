using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    [SerializeField] private GameObject[] _baseRecipe = null;
    [SerializeField] private GameObject[] _vegetables = null;
    [SerializeField] private GameObject[] _meat = null;
    [SerializeField] private GameObject[] _sauce = null;
    [SerializeField] private GameObject[] _extra = null;
    [SerializeField] private GameObject[] _iceFlavors = null;
    [SerializeField] private CanvasScaler _canvas;
    [SerializeField] private List<Transform> _orderHolder = null;
    [SerializeField] private List<Transform> _iceHolder = null;
    Dictionary<string, GameObject> Burger = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Ice = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Hotdog = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> Kip = new Dictionary<string, GameObject>();
    private bool _isHamBurger = false;
    private bool _readyToOrder;
    private bool _chickenOrBeef = false;
    private int _randomOrder;
    private float _UISize = 1;

    //In this start all ingredients are added to one big list, and a order is generated.
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        AddIngrdientsToList();
        GenerateOrder();
    }

    //Generate order picks a rendom recipe and selects that. This is done so you wont allways have a burger. 
    public void GenerateOrder()
    {
        if (StaticK.Difficulty >= 1)
        {
            _randomOrder = Random.Range(0, 4);
        }
        if (StaticK.Difficulty < 1)
        {
            _randomOrder = Random.Range(0, 2);
        }
        
        _readyToOrder = true;
        if (_readyToOrder == true)
        {
            switch (_randomOrder)
            {
                case 0:
                    SpawnOrderIce();
                    break;
                case 1:
                    SpawnOrderHotDog();
                    break;
                case 2:
                    SpawnOrderBurger();
                    break;
                case 3:
                    SpawnOrderKip();
                    break;
            }
            
        }
    }

    // in SpawnOrderBurger all burger Ingredients are added in order. 
    private void SpawnOrderBurger()
    {
        _isHamBurger = true;
        // 3 ints are created to begin, 1 to place them in the right spot, 2 for a random extra ingrediënt and 3 to determine if we have a chicken or normal burger. 
        int orderNumber = 0;
        int cheeseUnion = 1;
        //Next the said ingredient is instantiated as a gameobject, this is so we can change the parent and the name in order for the spawn system for coding to work to its fullest extend.
         GameObject bottombun = Instantiate(Burger["BottomBun"], _orderHolder[orderNumber].position, Quaternion.identity);
         bottombun.transform.parent = _orderHolder[orderNumber];
         bottombun.name = "BurgerBottomBun";
         ScaleUI(bottombun);
         orderNumber += 1;
        //Last the order number is increased to spawn the next ingredient on the next placeholder.
        GameObject patty = Instantiate(Burger["Patty"], _orderHolder[orderNumber].position, Quaternion.identity);
        patty.transform.parent = _orderHolder[orderNumber];
        patty.name = "BurgerPatty";
        ScaleUI(patty);
        orderNumber += 1;
        GameObject lettuce = Instantiate(Burger["Lettuce"], _orderHolder[orderNumber].position, Quaternion.identity);
        lettuce.transform.parent = _orderHolder[orderNumber];
        lettuce.name = "BurgerLettuce";
        ScaleUI(lettuce);
        orderNumber += 1;
        GameObject tomato = Instantiate(Burger["Tomato"], _orderHolder[orderNumber].position, Quaternion.identity);
        tomato.transform.parent = _orderHolder[orderNumber];
        tomato.name = "BurgerTomato";
        ScaleUI(tomato);
        orderNumber += 1;
        for (int i = 0; i < cheeseUnion; i++)
        {
            int ingredientAmount = Random.Range(0, 2);   
            switch (ingredientAmount)
            {
                case 0:
                    GameObject union = Instantiate(Burger["Union"], _orderHolder[orderNumber].position, Quaternion.identity);
                    union.transform.parent = _orderHolder[orderNumber];
                    union.name = "BurgerUnion";
                    ScaleUI(union);
                    orderNumber += 1;
                    break;
                case 1:
                    GameObject cheese = Instantiate(Burger["Cheese"], _orderHolder[orderNumber].position, Quaternion.identity);
                    cheese.transform.parent = _orderHolder[orderNumber];
                    cheese.name = "BurgerCheese";
                    ScaleUI(cheese);
                    orderNumber += 1;
                    break;
            }
        }
        GameObject topbun = Instantiate(Burger["TopBun"], _orderHolder[orderNumber].position, Quaternion.identity);
        topbun.transform.parent = _orderHolder[orderNumber];
        topbun.name = "BurgerTopBun";
        ScaleUI(topbun);
        orderNumber += 1;

    }

    // in SpawnOrderPizza all pizza Ingredients are added in order. 
    private void SpawnOrderIce()
    {
        // 2 ints are created to begin, 1 to place them in the right spot, 2 for a random extra ingrediënt. 
        int orderNumber = 0;
        int randomExtraIngredients = Random.Range(0, 2);
        GameObject icehorn = Instantiate(Ice["Horn"], _iceHolder[orderNumber].position, Quaternion.identity);
        icehorn.transform.parent = _iceHolder[orderNumber];
        icehorn.name = "IceHorn";
        ScaleUI(icehorn);
        orderNumber += 1;
        switch (randomExtraIngredients)
        {
            case 0:
                GameObject choco = Instantiate(Ice["Chocolate"], _iceHolder[orderNumber].position, Quaternion.identity);
                choco.transform.parent = _iceHolder[orderNumber];
                choco.name = "IceChocolate";
                ScaleUI(choco);
                orderNumber += 1;
                break;
            case 1:
                GameObject strawberry = Instantiate(Ice["Strawberry"], _iceHolder[orderNumber].position, Quaternion.identity);
                strawberry.transform.parent = _iceHolder[orderNumber];
                strawberry.name = "IceStrawberry";
                ScaleUI(strawberry);
                orderNumber += 1;
                break;
        }
        if (StaticK.Difficulty >= 1)
        {
            GameObject cherry = Instantiate(Ice["Cherry"], _iceHolder[orderNumber].position, Quaternion.identity);
            cherry.transform.parent = _iceHolder[orderNumber];
            cherry.name = "IceCherry";
            ScaleUI(cherry);
        }
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
        ScaleUI(bread);
        orderNumber += 1;
        GameObject meat = Instantiate(Hotdog["Meat"], _orderHolder[orderNumber].position, Quaternion.identity);
        meat.transform.parent = _orderHolder[orderNumber];
        meat.name = "HotdogMeat";
        ScaleUI(meat);
        orderNumber += 1;
        switch (randomSauce)
        {
            case 0:
                GameObject sauceketchup = Instantiate(Hotdog["SauceKetchup"], _orderHolder[orderNumber].position, Quaternion.identity);
                sauceketchup.transform.parent = _orderHolder[orderNumber];
                sauceketchup.name = "HotdogSauce";
                ScaleUI(sauceketchup);
                orderNumber += 1;
                break;
            case 1:
                GameObject saucemustard = Instantiate(Hotdog["SauceMustard"], _orderHolder[orderNumber].position, Quaternion.identity);
                saucemustard.transform.parent = _orderHolder[orderNumber];
                saucemustard.name = "HotdogSauce";
                ScaleUI(saucemustard);
                orderNumber += 1;
                break;
        }
        if (randomIngredient >= 1 && StaticK.Difficulty >= 1)
        {
            GameObject union = Instantiate(Hotdog["Union"], _orderHolder[orderNumber].position, Quaternion.identity);
            union.transform.parent = _orderHolder[orderNumber];
            union.name = "HotdogUnion";
            ScaleUI(union);
        }
    }
    //In SpawnOrderKip all kip ingredients are added in order. 
    private void SpawnOrderKip()
    {
        int orderNumber = 0;
        GameObject bottombun = Instantiate(Kip["KipOnder"], _orderHolder[orderNumber].position, Quaternion.identity);
        bottombun.transform.parent = _orderHolder[orderNumber];
        bottombun.name = "KipBottomBun";
        ScaleUI(bottombun);
        orderNumber += 1;
        GameObject chicken = Instantiate(Kip["Kip"], _orderHolder[orderNumber].position, Quaternion.identity);
        chicken.transform.parent = _orderHolder[orderNumber];
        chicken.name = "BurgerChicken";
        ScaleUI(chicken);
        orderNumber += 1;
        GameObject lettuce = Instantiate(Kip["Sla"], _orderHolder[orderNumber].position, Quaternion.identity);
        lettuce.transform.parent = _orderHolder[orderNumber];
        lettuce.name = "BurgerLettuce";
        ScaleUI(lettuce);
        orderNumber += 1;
        GameObject tomato = Instantiate(Kip["Tomaat"], _orderHolder[orderNumber].position, Quaternion.identity);
        tomato.transform.parent = _orderHolder[orderNumber];
        tomato.name = "BurgerTomato";
        ScaleUI(tomato);
        orderNumber += 1;
            int ingredientAmount = Random.Range(0, 2);
        if (ingredientAmount >=1)
        {
            GameObject union = Instantiate(Burger["Union"], _orderHolder[orderNumber].position, Quaternion.identity);
            union.transform.parent = _orderHolder[orderNumber];
            union.name = "BurgerUnion";
            ScaleUI(union);
            orderNumber += 1;
        }
        GameObject topbun = Instantiate(Kip["KipBoven"], _orderHolder[orderNumber].position, Quaternion.identity);
        topbun.transform.parent = _orderHolder[orderNumber];
        topbun.name = "KipTopBun";
        ScaleUI(topbun);
        orderNumber += 1;

    }
    /*
        In the AddIngredientsToList function all possible ingrediënts are added to the right lists.
        In the inspector they are added to a few lists, and now they are added to a dictionary for the right order.
        This is so we can call out the name of the ingredient while making the order.
        For burgers the sauce can be one of 3 things to give more variety.
        The variety goes for multiple ingrediënts.
     */

    private void AddIngrdientsToList()
    {
        int sauceNumber = Random.Range(0, 2);
        int pizzaSauceNumber = Random.Range(4, 6);
        Burger.Add("TopBun", _baseRecipe[0]);
        Burger.Add("BottomBun", _baseRecipe[1]);
        Burger.Add("Patty", _meat[0]);
        Burger.Add("Sauce", _sauce[sauceNumber]);
        Burger.Add("Cheese", _extra[1]);
        Burger.Add("Union", _extra[2]);
        Burger.Add("Lettuce", _vegetables[0]);
        Burger.Add("Tomato", _vegetables[1]);
        Hotdog.Add("Union", _extra[0]);
        Hotdog.Add("SauceKetchup", _sauce[2]);
        Hotdog.Add("SauceMustard", _sauce[3]);
        Hotdog.Add("Meat", _meat[1]);
        Hotdog.Add("Bread", _baseRecipe[2]);
        Ice.Add("Horn", _baseRecipe[3]);
        Ice.Add("Strawberry", _iceFlavors[1]);
        Ice.Add("Chocolate", _iceFlavors[2]);
        Ice.Add("Cherry", _iceFlavors[3]);
        Kip.Add("KipOnder", _baseRecipe[4]);
        Kip.Add("KipBoven", _baseRecipe[5]);
        Kip.Add("Sla", _vegetables[2]);
        Kip.Add("Tomaat", _vegetables[3]);
        Kip.Add("Union", _extra[3]);
        Kip.Add("Kip", _meat[2]);

    }

    // Under is a reset function so when the order is done, a new customer can post his order.
    public void ResetOrder()
    {
        for(int i = 0; i < _orderHolder.Count; i++)
        {
            foreach (Transform child in _orderHolder[i])
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        for (int i = 0; i < _iceHolder.Count; i++)
        {
            foreach (Transform child in _iceHolder[i])
            {
                GameObject.Destroy(child.gameObject);
            }
        }

    }
    private void ScaleUI(GameObject obj)
    {
        if (Screen.height <= 718)
        {
            obj.transform.localScale = new Vector3(Screen.height / 75, Screen.height / 210, 1);
        }
        
    }
}
