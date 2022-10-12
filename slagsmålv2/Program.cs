bool match = true;
bool outcome;
int gold = 100;
int bet = 0;
int pStr = 0;
int pVit = 0;
int pCrit = 0;
int skillPoint = 0;
int bStr = 0;
int bVit = 0;
int bCrit = 0;
int bSkills = 5;
int streak = 0;
int rounds = 0;
string winLose = "boulder";
string pAvatar = "gravel";
string bAvatar = "gravel";
string answer1 = "rock";
string answer2 = "stone";
string name = "a";
string bot = "boulder";
Random generator = new Random();

Console.WriteLine("You, Fighter. What is your name?");
name = Console.ReadLine();

while (name.Length < 2 || name.Length > 12)
{
    if (name.Length < 2)
    {
        Console.WriteLine("That name is too short, try again.");
    }
    else
    {
        Console.WriteLine("That name is too long, shorten it!");
    }
    name = Console.ReadLine();
}

while (match == true)
{
    bot = GetBot();
    MatchStartUp();
    FighterCustomizing();
    outcome = Fight(name, bot, pStr, pVit, pCrit, bStr, bVit, bCrit, pAvatar, bAvatar, rounds);
    if (outcome == true)
    {
        streak++;
        gold += 50;
        Console.WriteLine($"Congratulations, you won against {bot} and now have a winstreak of {streak}. \n+50 gold and +3 skillpoints for winning.");
        if (bet > 0 && winLose == "win")
        {
            gold += bet * 2;
            Console.WriteLine($"You bet {bet} gold on that you would win and you did win, you now have {gold} gold.");
        }
        else if (bet > 0)
        {
            Console.WriteLine("You lost your bet, you bet on losing.");
        }
    }
    else if (outcome == false)
    {
        pStr = 0;
        pVit = 0;
        pCrit = 0;
        Console.WriteLine($"{bot} defeated you and you lost your skillpoints.");
        if (bet > 0 && winLose == "lose")
        {
            gold += bet * 2;
            Console.WriteLine($"You bet {bet} gold on that you would lose and you did lose, you now have {gold} gold.");
        }
        else if (bet > 0)
        {
            Console.WriteLine("You lost your bet, you bet on winning.");
        }
        if(streak > 0)
        {
            Console.WriteLine("Your streak has been reset.");
            streak = 0;
        }
    }

    answer2 = "pebbles";
    while(answer2 != "no" && answer2 != "yes")
    {
        Console.WriteLine("Do you want to fight again?");
        answer1 = Console.ReadLine();
        answer2 = answer1.ToLower();

        if(answer2 == "no")
        {
            match = false;
        }
    } 
}

static string GetBot()
{
    string bot = "pebble";
    Random generator = new Random();
    int botNum = generator.Next(1, 4);
    if (botNum == 1)
    {
        bot = "John";
    }
    else if (botNum == 2)
    {
        bot = "Max";
    }
    else if (botNum == 3)
    {
        bot = "Steve";
    }

    return bot;
}

void MatchStartUp()
{
    bet = 0;
    winLose = "pebbles";

    Console.Clear();
    Console.WriteLine($"In this next fight, we will see {name} against {bot}. \nDo you wish to bet gold on the fight? (If you win the bet get 2x the gold) \nCurrent gold: {gold}.");
    answer1 = Console.ReadLine();
    answer2 = answer1.ToLower();

    if (answer2 == "yes")
    {
        bool betting = true;

        if (gold < 1)
        {
            Console.WriteLine("You do not have any gold to bet with.");
            betting = false;
        }

        while (betting == true)
        {
            Console.Clear();
            Console.WriteLine("What will you bet on, that you win or lose?");
            answer1 = Console.ReadLine();
            winLose = answer1.ToLower();

            Console.WriteLine($"How much gold do you wish to bet? Current gold: {gold}.");
            answer1 = Console.ReadLine();
            bet = Convert.ToInt32(answer1);

            while (bet > gold || bet < 1)
                if (bet > gold)
                {
                    Console.WriteLine($"You want to bet {bet} gold but you only have {gold} gold. You cannot bet more gold than you have, try again. \nHow much gold do you wish to bet?");
                    answer1 = Console.ReadLine();
                    bet = Convert.ToInt32(answer1);
                }
                else if (bet == 0)
                {
                    Console.WriteLine("You cannot bet 0 gold, try again. \nHow much gold do you wish to bet?");
                    answer1 = Console.ReadLine();
                    bet = Convert.ToInt32(answer1);
                }
                else if (bet < 0)
                {
                    Console.WriteLine("You cannot bet a negative amount of gold, try again. \nHow much gold do you wish to bet?");
                    answer1 = Console.ReadLine();
                    bet = Convert.ToInt32(answer1);
                }

            Console.WriteLine($"You wish to bet {bet} gold?");
            answer1 = Console.ReadLine();
            answer2 = answer1.ToLower();

            if (answer2 == "yes")
            {
                gold -= bet;
                Console.WriteLine($"You bet {bet} gold on that you {winLose}. If you're right, you'll get {2 * bet} gold. \nPress enter to continue.");
                Console.ReadLine();
                betting = false;
            }
            else
            {
                Console.WriteLine("Do you want bet another amount?");
                answer1 = Console.ReadLine();
                answer2 = answer1.ToLower();

                if (answer2 == "no")
                {
                    Console.WriteLine("Do you wish to not place a bet?");
                    answer1 = Console.ReadLine();
                    answer2 = answer1.ToLower();

                    if (answer2 == "yes")
                    {
                        bet = 0;
                        winLose = "pebbles";
                        betting = false;
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine("You did not want to place a bet. \nPress enter to continue.");
        Console.ReadLine();
    }

    rounds = 0;
    while (rounds < 4 || rounds > 16)
    {
        Console.WriteLine("How many rounds do you want the fight to consist of? \nHave to be atleast 4 and maximum 16.");
        answer1 = Console.ReadLine();
        bool roundSuccess = int.TryParse(answer1, out rounds);
    }
}

void FighterCustomizing()
{
    Console.Clear();
    skillPoint += 3;
    while (skillPoint > 0)
    {
        Console.WriteLine($"You have {skillPoint} skillpoints to spend. \nWhat do you want to spend a skill point on? \nStrength(str), Vitality(vit) or Crit Chance(crit)?");
        answer1 = Console.ReadLine();
        answer2 = answer1.ToLower();

        if (answer2 == "strength" || answer2 == "str")
        {
            pStr += 2;
            skillPoint--;
            Console.Clear();
        }
        else if (answer2 == "vitality" || answer2 == "vit")
        {
            pVit += 10;
            skillPoint--;
            Console.Clear();

        }
        else if (answer2 == "crit chance" || answer2 == "crit" || answer2 == "chance")
        {
            pCrit += 1;
            skillPoint--;
            Console.Clear();

            if (pCrit > 19)
            {
                pCrit = 19;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("That was not an option, try again.");
        }
    }

    bStr = 0;
    bVit = 0;
    bCrit = 0;
    bSkills = 5;
    while (bSkills > 0)
    {
        int bStats = generator.Next(1, 4);
        if (bStats == 1)
        {
            bStr += 2;
            bSkills--;
        }
        else if (bStats == 2)
        {
            bVit += 10;
            bSkills--;
        }
        else if (bStats == 3)
        {
            bCrit += 1;
            bSkills--;
        }
    }

    Console.WriteLine($"{name} has {pStr / 2} strength, {pVit / 10} vitality and {pCrit} crit chance. \n{bot} has {bStr / 2} strength, {bVit / 10} vitality and {bCrit} crit chance. \nPress enter to continue.");
    Console.ReadLine();
    Console.Clear();

    Console.WriteLine("Choose your character.");
    Console.WriteLine(@"A:
      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  \\ .=|=. //
   \\(_=_)//
    (:| |:)
     || ||
     () ()
     || ||
     || ||
    ==' '==");
    Console.WriteLine(@"B:
       _          (`-. 
       \`----.    ) ^_`)
,__     \__   `\_/  ( `
 \_\      \__  `|   }
   \\  .--' \__/    }
    ))/   \__,<  /_/
    ((|  _/_/ `\ \_\_
     `\_____\\  )__\_\");
    Console.WriteLine(@"C:
 ___    ___
( _<    >_ )
//        \\
\\___..___//
 `-(    )-'
   _|__|_
  /_|__|_\
  /_|__|_\
  /_\__/_\
   \ || /  _)
     ||   ( )
     \\___//
      `---'");
    while (answer2 != "a" && answer2 != "b" && answer2 != "c")
    {
        answer1 = Console.ReadLine();
        answer2 = answer1.ToLower();

        if (answer2 == "a")
        {
            pAvatar = @"      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  \\ .=|=. //
   \\(_=_)//
    (:| |:)
     || ||
     () ()
     || ||
     || ||
    ==' '==";
            int bCharacter = generator.Next(1, 3);
            if (bCharacter == 1)
            {
                bAvatar = @"       _          (`-. 
       \`----.    ) ^_`)
,__     \__   `\_/  ( `
 \_\      \__  `|   }
   \\  .--' \__/    }
    ))/   \__,<  /_/
    ((|  _/_/ `\ \_\_
     `\_____\\  )__\_\";
            }
            else if (bCharacter == 2)
            {
                bAvatar = @" ___    ___
( _<    >_ )
//        \\
\\___..___//
 `-(    )-'
   _|__|_
  /_|__|_\
  /_|__|_\
  /_\__/_\
   \ || /  _)
     ||   ( )
     \\___//
      `---'";
            }
        }
        else if (answer2 == "b")
        {
            pAvatar = @"       _          (`-. 
       \`----.    ) ^_`)
,__     \__   `\_/  ( `
 \_\      \__  `|   }
   \\  .--' \__/    }
    ))/   \__,<  /_/
    ((|  _/_/ `\ \_\_
     `\_____\\  )__\_\";

            int bCharacter = generator.Next(1, 3);
            if (bCharacter == 1)
            {
                bAvatar = @"      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  \\ .=|=. //
   \\(_=_)//
    (:| |:)
     || ||
     () ()
     || ||
     || ||
    ==' '==";
            }
            else if (bCharacter == 2)
            {
                bAvatar = @" ___    ___
( _<    >_ )
//        \\
\\___..___//
 `-(    )-'
   _|__|_
  /_|__|_\
  /_|__|_\
  /_\__/_\
   \ || /  _)
     ||   ( )
     \\___//
      `---'";
            }
        }
        else if (answer2 == "c")
        {
            pAvatar = @" ___    ___
( _<    >_ )
//        \\
\\___..___//
 `-(    )-'
   _|__|_
  /_|__|_\
  /_|__|_\
  /_\__/_\
   \ || /  _)
     ||   ( )
     \\___//
      `---'";

            int bCharacter = generator.Next(1, 3);
            if (bCharacter == 1)
            {
                bAvatar = @"      .-.
     (o.o)
      |=|
     __|__
   //.=|=.\\
  // .=|=. \\
  \\ .=|=. //
   \\(_=_)//
    (:| |:)
     || ||
     () ()
     || ||
     || ||
    ==' '==";
            }
            else if (bCharacter == 2)
            {
                bAvatar = @"       _          (`-. 
       \`----.    ) ^_`)
,__     \__   `\_/  ( `
 \_\      \__  `|   }
   \\  .--' \__/    }
    ))/   \__,<  /_/
    ((|  _/_/ `\ \_\_
     `\_____\\  )__\_\";
            }
        }
        else
        {
            Console.WriteLine("That was not an option, try again.");
        }
    }

}

static bool Fight(string name, string bot, int pStr, int pVit, int pCrit, int bStr, int bVit, int bCrit, string pAvatar, string bAvatar, int rounds)
{
    bool outcome = true;
    int pHp = 100 + pVit;
    int bHp = 100 + bVit;
    int oPHp = pHp;
    int oBHp = bHp;
    int pDmg = 10 + pStr;
    int bDmg = 10 + bStr;
    int acc;
    int crit;
    int round = 0;
    string answer1;
    string answer2 = "pebble";
    Random generator = new Random();

    Console.Clear();
    Console.WriteLine(pAvatar);
    Console.WriteLine($"{name} {pHp}/{oPHp} \nMatch Start (press enter to start) \n{bot} {bHp}/{oBHp}");
    Console.WriteLine(bAvatar);
    Console.ReadLine();

    while (pHp > 0 && bHp > 0)
    {
        answer2 = "pebbles";
        while (answer2 != "q" && answer2 != "quick" && answer2 != "h" && answer2 != "heavy")
        {
            Console.WriteLine($"(Quick = {pDmg} dmg and 75% accuracy | Heavy = {pDmg + pDmg / 2} dmg and 40% accuracy) \nQuick Attack or Heavy Attack? [q/h or quick/heavy]");
            answer1 = Console.ReadLine();
            answer2 = answer1.ToLower();

            if (answer2 == "q" || answer2 == "quick")
            {
                acc = generator.Next(1, 5);
                if (acc > 1)
                {
                    crit = generator.Next(1 + pCrit, 21);
                    if (crit == 1 + pCrit)
                    {
                        Console.Clear();
                        bHp -= pDmg * 2;
                        Console.WriteLine($"You hit {bot} with a quick attack crit dealing {pDmg * 2} damage.");
                    }
                    else
                    {
                        Console.Clear();
                        bHp -= pDmg;
                        Console.WriteLine($"You hit {bot} with a quick attack dealing {pDmg} damage.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You missed.");
                }
            }
            else if (answer2 == "h" || answer2 == "heavy")
            {
                acc = generator.Next(1, 11);
                if (acc < 5)
                {
                    crit = generator.Next(1 + pCrit, 21);
                    if (crit == 1 + pCrit)
                    {
                        Console.Clear();
                        bHp -= pDmg * 2 + pDmg / 2;
                        Console.WriteLine($"You hit {bot} with a heavy attack crit dealing {pDmg * 2 + pDmg / 2} damage.");
                    }
                    else
                    {
                        Console.Clear();
                        bHp -= pDmg + pDmg / 2;
                        Console.WriteLine($"You hit {bot} with a heavy attack dealing {pDmg + pDmg / 2} damage.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You missed.");
                }
            }
        }

        if (bHp < 1)
        {
            bHp = 0;
        }

        round++;
        Console.WriteLine(pAvatar);
        Console.WriteLine($"{name} {pHp}/{oPHp} \nRound {round}/{rounds} (press enter to continue) \n{bot} {bHp}/{oBHp}");
        Console.WriteLine(bAvatar);
        Console.ReadLine();

        if (bHp < 1)
        {
            bHp = 0;
            outcome = true;
            break;
        }

        int bAttack = generator.Next(1, 3);
        if (bAttack == 1)
        {
            acc = generator.Next(1, 5);
            if (acc > 1)
            {
                crit = generator.Next(1 + bCrit, 21);
                if (crit == 1 + bCrit)
                {
                    Console.Clear();
                    pHp -= bDmg * 2;
                    Console.WriteLine($"{bot} hit you with a quick attack crit dealing {bDmg * 2} damage.");
                }
                else
                {
                    Console.Clear();
                    pHp -= bDmg;
                    Console.WriteLine($"{bot} hit you with a quick attack dealing {bDmg} damage.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{bot} missed.");
            }
        }
        else if (bAttack == 2)
        {
            acc = generator.Next(1, 11);
            if (acc < 5)
            {
                crit = generator.Next(1 + bCrit, 21);
                if (crit == 1 + bCrit)
                {
                    Console.Clear();
                    pHp -= bDmg * 2 + bDmg / 2;
                    Console.WriteLine($"{bot} hit you with a heavy attack crit dealing {bDmg * 2 + bDmg / 2} damage.");
                }
                else
                {
                    Console.Clear();
                    pHp -= bDmg + bDmg / 2;
                    Console.WriteLine($"{bot} hit you with a heavy attack dealing {bDmg + bDmg / 2} damage.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{bot} missed.");
            }
        }

        if (pHp < 1)
        {
            pHp = 0;
        }

        Console.WriteLine(pAvatar);
        Console.WriteLine($"{name} {pHp}/{oPHp} \nRound {round}/{rounds}  \n{bot} {bHp}/{oBHp}");
        Console.WriteLine(bAvatar);

        if (pHp < 1)
        {
            pHp = 0;
            outcome = false;
            break;
        }

        if(round == rounds)
        {
            if(bHp < pHp)
            {
                Console.WriteLine($"The last round has ended. You had more Hp than {bot}.");
                outcome = true;
                break;
            }
            else if(pHp < bHp)
            {
                Console.WriteLine($"The last round has ended. {bot} had more Hp than you.");
                outcome = false;
                break;
            }
        }
    }

    return outcome;
}
