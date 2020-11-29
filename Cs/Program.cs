using System;
using System.Collections.Generic;

namespace lab4
{
    public class Food 
    {
        public Food(string code, int count) 
        {
            this.Count = count;
            this.Code = code;
        }   
        string code;
        int count;

        public string Code { get => code; set => code = value; }
        public int Count { get => count; set => count = value; }
    }
    public interface IRestourante {

        string restouranteName();

        string order(List<Food> foodList);
    }

    public class FastFoodRestourante : IRestourante 
    {
        public string order(List<Food> foodList)
        {
            string orderString = "[";
            for(int i = 0; i < foodList.Count; i++) 
            {
                orderString += "[" + foodList[i].Code + ", " + foodList[i].Count + "]";
                if (i < foodList.Count - 1) orderString += ", ";
            }
            orderString += "]";
            return orderString;
        }

        public string restouranteName()
        {
            return "McDonalds";
        }
    }

    public class JapanRestourante : IRestourante
    {
        public string order(List<Food> foodList)
        {
            string codeList = "[";
            string countList = "[";
            for (int i = 0; i < foodList.Count; i++) 
            {
                codeList += foodList[i].Code;
                countList += foodList[i].Count;
                if (i < foodList.Count - 1) 
                { 
                    countList += ", ";
                    codeList += ", ";
                }
            }
            codeList += "]";
            countList += "]";
            return codeList + ", " + countList;
        }

        public string restouranteName()
        {
            return "Sushi";
        }
    }

    public class TraditionalRestourante : IRestourante
    {
        public string order(List<Food> foodList)
        {
            string orderString = "[";
            for(int i = 0; i < foodList.Count; i++) 
            {
                for (int j = 0; j < foodList[i].Count; j++) 
                {
                    orderString += foodList[i].Code + ", ";
                }
            }
            orderString = orderString.Substring(0, orderString.Length - 2) + "]";
            return orderString;
        }

        public string restouranteName()
        {
            return "Traditional Ukrainian foods";
        }
    }

    public class OrderFactory {

        IRestourante selectedRestourante;

        public void selectRestourante(string foodType) {
            switch(foodType) {
                case "a":
                    selectedRestourante = new FastFoodRestourante();
                return;
                case "b":
                    selectedRestourante = new JapanRestourante();
                return;
                case "c": 
                    selectedRestourante = new TraditionalRestourante();
                return;
                default:
                    selectedRestourante = null;
                return;
                
            }
        }

        public void order(List<Food> foodList) 
        {
            if (selectedRestourante == null) 
            {
                Console.WriteLine("No selected restourante");  
                return;  
            }

            Console.WriteLine(selectedRestourante.restouranteName());
            Console.WriteLine(selectedRestourante.order(foodList));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderFactory orderFactory = new OrderFactory();
            Console.WriteLine("Select food type:\na.FastFood\nb.Sushi\nc.Traditional Ukrainian");  
            string foodType = Console.ReadLine(); 
            orderFactory.selectRestourante(foodType);

            List<Food> foodList = new List<Food>();
            
            Console.WriteLine("Enter food code and count");
            bool finishOrder = false;
            while (!finishOrder)
            {
                Console.Write("Code: ");
                string code = Console.ReadLine(); 
                Console.Write("Count: ");
                int count = Int32.Parse(Console.ReadLine());
                foodList.Add(new Food(code, count));

                Console.WriteLine("Finish order? y/n");
                string finish = Console.ReadLine();
                finishOrder = finish == "y";
            }

            orderFactory.order(foodList);
            Console.ReadKey();
        }
    }
}