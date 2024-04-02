using System;

class Program
{
    static int[,] allMoney = { { 100, 10 }, { 500, 4 }, { 1000, 3 }, { 5000, 2 } };

    static void Main()
    {
        getMoneyFromATM(6000);
        getMoneyFromATM(1000);
        getMoneyFromATM(2500);
        getMoneyFromATM(6000);
    }

    static void getMoneyFromATM(int giveOut)
    {
        bool success = true;

        for (int i = allMoney.GetLength(0) - 1; i >= 0; i--)
        {
            int denom = allMoney[i, 0];
            int count = allMoney[i, 1];

            int numNotesToGive = giveOut / denom;

            if (numNotesToGive > count)
            {
                numNotesToGive = count;
            }

            giveOut -= numNotesToGive * denom;
            allMoney[i, 1] -= numNotesToGive;

            if (giveOut == 0)
            {
                break;
            }
        }

        if (giveOut == 0)
        {
            Console.WriteLine("Сумма выдана.");
            Console.WriteLine("Количество оставшихся номиналов купюр:");

            for (int i = 0; i < allMoney.GetLength(0); i++)
            {
                Console.WriteLine($"{allMoney[i, 1]} шт номинала {allMoney[i, 0]}");
            }
        }
        else
        {
            Console.WriteLine("Невозможно выдать данную сумму.");
        }
    }
}
