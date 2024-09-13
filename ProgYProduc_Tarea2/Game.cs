using ProgYProduc_Tarea2;

internal class Game
{
    private Player player;
    private List<Character> enemiesList;
    Random rndom = new Random();


    public void Execute()
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("¡JUEGO POR TURNOS!");
        Console.WriteLine("-----------------------------------------------------");

        player = CreatePlayer();
        enemiesList = new List<Character>
        {
            new EnemyMelee(150, 10),
            new EnemyRange(200, 15, 3),
            new EnemyMelee(60, 20),
            new EnemyRange(80, 8, 2)
        };

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"¡{enemiesList.Count} enemigos aparecen delante de ti.!");
        Console.WriteLine("-----------------------------------------------------");

        while (player.IsDead() == false)
        {
            ShowGameStats();
            PlayerTurn();

            if (enemiesList.All(enemy => enemy.IsDead() == true))
            {
                break;
            }

            EnemiesTurn();
        }

        if (!player.IsDead())
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("¡Victoria! Todos los enemigos han sido derrotados.");
        }
        else
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("¡Has muerto! GAME OVER");
        }
    }

    private Player CreatePlayer()
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("CREA A TU PERSONAJE:");
        Console.Write("Introduce la salud de tu personaje (máximo 100): ");
        int health = CheckValidInput(1, 100);

        Console.Write("Introduce el daño de tu personaje (máximo 100): ");
        int damage = CheckValidInput(1, 100);
        Console.WriteLine("-----------------------------------------------------");
        return new Player(health, damage);
        
    }

    private void ShowGameStats()
    {
        Console.WriteLine("-BATALLA EN CURSO-");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"Vida restante: {player.health}. Poder de ataque: {player.damage}");
        Console.WriteLine("-----------------------------------------------------");
        for (int i = 0; i < enemiesList.Count; i++)
        {
            Console.WriteLine($"Enemigo {i}: Vida = {enemiesList[i].health}, {(enemiesList[i].IsDead() ? "Muerto" : "Vivo")}");
        }
        Console.WriteLine("-----------------------------------------------------");
    }

    private void PlayerTurn()
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Es tu turno:");
        int enemyChosen = CheckValidEnemy();
        int damageDealt = player.CauseDamage();
        enemiesList[enemyChosen].GetHurt(damageDealt);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"¡Has causado {damageDealt} de daño al enemigo {enemyChosen}!");
        Console.WriteLine("-----------------------------------------------------");
    }

    private void EnemiesTurn()
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Es turno del enemigo:");
        foreach (var enemy in enemiesList.Where(enemy => enemy.IsDead() == false))
        {
            int damageCaused = enemy.CauseDamage();
            player.GetHurt(damageCaused);
            Console.WriteLine($"Un enemigo te ha causado {damageCaused} de daño");
        }
        Console.WriteLine("-----------------------------------------------------");
    }

    private int CheckValidEnemy()
    {
        while (true)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Elige al enemigo que atacaras:");
            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (enemiesList[i].IsDead() == false)
                {
                    Console.WriteLine($"{i}: Enemigo con {enemiesList[i].health} de salud");
                }
            }

            if (int.TryParse(Console.ReadLine(), out int enemyIndexChosen) && enemyIndexChosen >= 0 && enemyIndexChosen < enemiesList.Count && enemiesList[enemyIndexChosen].IsDead() == false)
            {
                return enemyIndexChosen;
            }
            Console.WriteLine("Número de enemigo inválido, elige un enemigo vivo.");
        }
    }

    private int CheckValidInput(int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            {
                return value;
            }
            Console.WriteLine($"Cantidad inválida, introduce un número entre {min} y {max}.");
        }
    }
}