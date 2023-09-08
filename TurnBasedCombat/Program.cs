int playerHp = 50;
int enemyHp = 50;

Random random = new Random();
int playerAttack = 0;
int playerDefend = 0;
int enemyAttack = 0;
int enemyDefend = 0;

bool playerDefending = false;
bool enemyDefending = false;

bool playerCharging = false;
bool enemyCharging = false;

Random enemyRandom = new Random();

while (playerHp > 0 && enemyHp > 0)
{
    Console.WriteLine("---Player's Turn---");
    Console.WriteLine();
    Console.WriteLine("Player's HP: " + playerHp);
    Console.WriteLine("Enemy's HP: " + enemyHp);
    Console.WriteLine();
    Console.WriteLine("Press a to attack, c to charge, d to defend");

    string playerChoice = Console.ReadLine();

    if (playerChoice == "a")
    {
        playerAttack = random.Next(1, 11);
        if(playerCharging)
        {
            playerAttack *= 2;
            playerCharging = false;
        }
        if (enemyDefending)
        {
            playerAttack -= enemyDefend;
            enemyDefending = false;
        }
        if (playerAttack < 0)
        {
            playerAttack = 0;
        }
        enemyHp -= playerAttack;
        Console.WriteLine("Player attacks for " + playerAttack + " damage!");
        Console.WriteLine();
    }
    else if (playerChoice == "c")
    {
        playerCharging = true;
        Console.WriteLine("Player charges up!");
        Console.WriteLine();
    }
    else if (playerChoice == "d")
    {
        playerDefend = random.Next(1, 11);
        playerDefending = true;
        Console.WriteLine("Player defends!");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Invalid input");
        Console.WriteLine();
    }
    Console.WriteLine();
    if (enemyHp > 0)
    {
        Console.WriteLine("---Enemy's Turn---");
        int enemyChoice = enemyRandom.Next(0, 3);
        System.Threading.Thread.Sleep(1000);
        if (enemyChoice == 0)
        {
            enemyAttack = random.Next(1, 11);
            if (enemyCharging)
            {
                enemyAttack *= 2;
                enemyCharging = false;
            }
            if (playerDefending)
            {
                enemyAttack -= playerDefend;
                playerDefending = false;
            }
            if (enemyAttack < 0)
            {
                enemyAttack = 0;
            }
            playerHp -= enemyAttack;
            Console.WriteLine("Enemy attacks for " + enemyAttack + " damage!");
            Console.WriteLine();
        }
        else if (enemyChoice == 1)
        {
            enemyCharging = true;
            Console.WriteLine("Enemy charges up!");
            Console.WriteLine();
        }
        else if (enemyChoice == 2)
        {
            enemyDefend = random.Next(1, 11);
            enemyDefending = true;
            Console.WriteLine("Enemy defends!");
            Console.WriteLine();
        }
    }
}

if (playerHp <= 0)
{
    Console.WriteLine("You lose!");
}
else if (enemyHp <= 0)
{
    Console.WriteLine("You win!");
}

