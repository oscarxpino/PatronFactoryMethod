using PatronFactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronFactoryMethod
{
	//Pino Alvarez Oscar Brandon

	public abstract class Pizza // se crea clase abstracta de Pizza
	{

		public Pizza()
		{
			Toppings = new List<string>();//Agregar los toppings
		}

		public string Dough
		{
			get; set;
		}

		public string Name //Asignar nombre a la pizza
		{
			get; set;
		}

		public string Sauce //Lo anterior pero con la salsa
		{
			get; set;
		}

		public List<string> Toppings
		{
			get; set;
		}
//Pino Alvarez Oscar Brandon
		public void Bake()
		{
			Console.WriteLine("Bake for 25 minutes at 350");
		}

		public void Box()//Empaquetado de las pizzas con su correspondiente mensaje
		{
			Console.WriteLine("Place pizza in official PizzaStore box");
		}

		public virtual void Cut() //Metodo para el corte se usa virtual para que el override pueda modificar esta info
		{
			Console.WriteLine("Cutting the pizza into diagonal slices");
		}

		public void Prepare()//Preparacion
		{
			Console.WriteLine("Preparing " + Name);
			Console.WriteLine("Tossing dough...");
			Console.WriteLine("Adding sauce...");
			Console.WriteLine("Adding toppings: ");
			foreach (string topping in Toppings)
			{
				Console.WriteLine("    " + Toppings);
			}
		}
//Pino Alvarez Oscar Brandon
		public override string ToString()//Se implementara override para poder modificar cada uno de los siguientes datos
		{
			StringBuilder display = new StringBuilder();
			display.Append("----" + Name + "----\n");
			display.Append(Dough + "\n");
			display.Append(Sauce + "\n");
			foreach (string topping in Toppings)
			{
				display.Append(topping.ToString() + "\n");
			}

			return display.ToString();
		}
	}
}

public abstract class PizzaStore//Clase abstracta de la tienda pizza
{
	//Se creara la pizza a partir del metodo CreatePizza() donde item obtendra el tipo de pizza que sera
	public abstract Pizza CreatePizza(string item);
	//Mostrara la informacion relacionada con la preparacion de la pizza y retornara esta misma para que se despliegue en pantalla
	public Pizza OrderPizza(string type)
	{
		Pizza pizza = CreatePizza(type);
		Console.WriteLine("--- Making a " + pizza.Name + " ---");
		pizza.Prepare();
		pizza.Bake();
		pizza.Cut();
		pizza.Box();
		return pizza;
	}
}
//Pino Alvarez Oscar Brandon
public class ChicagoPizzaStore : PizzaStore //se crea clase para la tienda de chicago que tendra heredados los metodos de pizza store

{
	public override Pizza CreatePizza(String item)//se utiliza override para modificar un metodo heredado
	{
		Pizza pizza = null;

		switch (item)//Dependiendo de la pizza selecciona se desplegara su forma de preparacion
		{
			case "cheese"://Preparacion pizza de queso
				pizza = new ChicagoStyleCheesePizza();
				break;
			case "veggie"://Preparacion pizza vegana
                pizza = ChicagoStyleVeggiePizza();
                break;
			case "pepperoni"://Preparacion pizza de peperoni
				pizza = new ChicagoStylePepperoniPizza();
				break;
		}

		return pizza;//Retornara la informacion de la pizza correspondiente
	}
}
//Pino Alvarez Oscar Brandon
public class ChicagoStyleCheesePizza : Pizza // Para el estilo chicago este hereda para salsa, masa, toppings, etc
{
	public ChicagoStyleCheesePizza()//Preparacion para la pizza de masa gruesa de estilo deep dish
	{
		Name = "Chicago Style Deep Dish Cheese Pizza";
		Dough = "Extra Thick Crust Doush";
		Sauce = "Plum Tomate Sauce";

		Toppings.Add("Shredded Mozzarella Cheese");//Agregar toppings en este caso mozarella rayado
	}

	public override void Cut()//El estilo del corte
	{
		Console.WriteLine("Cutting the pizza into square slices");
	}
}

public class ChicagoStyleClamPizza : Pizza //Segundo estilo de pizza de mariscos
{
	public ChicagoStyleClamPizza()
	{
		Name = "Chicago Style Clam Pizza";
		Dough = "Extra Thick Crust Doush";
		Sauce = "Plum Tomate Sauce";

		Toppings.Add("Shredded Mozzarella Cheese");
		Toppings.Add("Frozen Clams from Chesapeake Bay");//Mariscos frios de la bahia
	}
	//Pino Alvarez Oscar Brandon
	public override void Cut()//Llama y modifica el tipo de corte
	{
		Console.WriteLine("Cutting the pizza into square slices");
	}
}

public class ChicagoStylePepperoniPizza : Pizza // Clase para la pizza de pepperoni
{
	public ChicagoStylePepperoniPizza()
	{
		Name = "Chicago Pepperoni Pizza";
		Dough = "Extra Thick Crust Doush";
		Sauce = "Plum Tomate Sauce";

		Toppings.Add("Shredded Mozzarella Cheese");
		Toppings.Add("Black Olives");
		Toppings.Add("Spinach");
		Toppings.Add("Eggplant");
		Toppings.Add("Sliced Pepperoni");
	}

	public override void Cut()//Tipo de corte
	{
		Console.WriteLine("Cutting the pizza into square slices");
	}
}
//Pino Alvarez Oscar Brandon
public class ChicagoStyleVeggiePizza : Pizza
{
	public ChicagoStyleVeggiePizza()
	{
		Name = "Chicago Deep Dish Veggie Pizza";
		Dough = "Extra Thick Crust Dough";
		Sauce = "Plum Tomato Sauce";

		Toppings.Add("Shredded Mozzarella Cheese");
		Toppings.Add("Black Olives");
		Toppings.Add("Spinach");
		Toppings.Add("Eggplant");
	}

	public override void Cut()
	{
		Console.WriteLine("Cutting the pizza into square slices");
	}
}

public class NYStyleCheesePizza : Pizza
{
	public NYStyleCheesePizza()
	{
		Name = "NY Style Sauce and Cheese Pizza";
		Dough = "Thin Crust Dough";
		Sauce = "Marinara Sauce";

		Toppings.Add("Grated Reggiano Cheese");
	}
}
//Pino Alvarez Oscar Brandon
public class NYStyleClamPizza : Pizza
{
	public NYStyleClamPizza()
	{
		Name = "NY Style Clam Pizza";
		Dough = "Thin Crust Dough";
		Sauce = "Marinara Sauce";

		Toppings.Add("Grated Reggiano Cheese");
		Toppings.Add("Fresh Clams from Long Island Sound");
	}
}

//La Clase tomara y agregara los datos para la preparacion cocrte de preparacion dependiendo del estilo de pizza correspondiente

public class NYStylePepperoniPizza : Pizza
{
	public NYStylePepperoniPizza()
	{
		Name = "NY Style Pepperoni Pizza";
		Dough = "Thin Crust Dough";
		Sauce = "Marinara Sauce";

		Toppings.Add("Grated Reggiano Cheese");
		Toppings.Add("Sliced Pepperoni");
		Toppings.Add("Garlic");
		Toppings.Add("Onion");
		Toppings.Add("Mushrooms");
		Toppings.Add("Red Pepper");
	}
}
//Pino Alvarez Oscar Brandon
public class NYStyleVeggiePizza : Pizza
{
	public NYStyleVeggiePizza()
	{
		Name = "NY Style Veggie Pizza";
		Dough = "Thin Crust Dough";
		Sauce = "Marinara Sauce";

		Toppings.Add("Grated Reggiano Cheese");
		Toppings.Add("Garlic");
		Toppings.Add("Onion");
		Toppings.Add("Mushrooms");
		Toppings.Add("Red Pepper");
	}
}

class PizzaTestDrive
{
	static void Main(string[] args)
	{
		PizzaStore nyStore = new NYPizzaStore();
		PizzaStore chicagoStore = new ChicagoPizzaStore();
		//Se usara para desplegar la inforamcion completa de la pizza ordenada por algun usuario
		//Entre los datos sera el tipo de corte, preparacion, ingredientes, estilo, etc
		Pizza pizza = nyStore.OrderPizza("cheese");

		Console.WriteLine("Ethan ordered a " + pizza.Name + "\n");

		pizza = chicagoStore.OrderPizza("cheese");
		Console.WriteLine("Joel ordered a " + pizza.Name + "\n");


		pizza = nyStore.OrderPizza("clam");
		Console.WriteLine("Ethan ordered a " + pizza.Name + "\n");

		pizza = chicagoStore.OrderPizza("clam");
		Console.WriteLine("Joel ordered a " + pizza.Name + "\n");

		pizza = nyStore.OrderPizza("pepperoni");
		Console.WriteLine("Ethan ordered a " + pizza.Name + "\n");

		pizza = chicagoStore.OrderPizza("pepperoni");
		Console.WriteLine("Joel ordered a " + pizza.Name + "\n");

		pizza = nyStore.OrderPizza("veggie");
		Console.WriteLine("Ethan ordered a " + pizza.Name + "\n");

		pizza = chicagoStore.OrderPizza("veggie");
		Console.WriteLine("Joel ordered a " + pizza.Name + "\n");

		Console.ReadKey();
	}
}


