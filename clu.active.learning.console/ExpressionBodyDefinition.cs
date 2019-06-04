using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members

    */
    public static class ExpressionBodyDefinition
    {
        public class Card
        {
            public string Number { get; set; }
        }

        static void TestCard1(Card card) => card.Number = "2222";

        static void TestCard2(ref Card card) => card.Number = "1111";

        static void TestCard3(string card) => card = "2222";

        static void TestCard4(ref string card) => card = "1111";

        public static void Test()
        {
            Card card1 = new Card { Number = "1111" }; //card1.Number == "1111"
            TestCard1(card1); //card1.Number == "2222"
            Card card2 = new Card { Number = "2222" }; //card2.Number == "2222"
            TestCard2(ref card2); //card1.Number == "1111"

            string card3 = "1111"; //card3.Number == "1111"
            TestCard3(card3); //card3.Number == "1111"
            string card4 = "2222"; //card4.Number == "2222"
            TestCard4(ref card4); //card4.Number == "1111"

            Console.ReadLine();
        }
    }
}