using System.Text;

class GUI : Game
{
    public void StartMenu()
    {
        string blink = "><";

        Console.Write("\n\n\n"
                    + "                ----------------------------------------------------------------------------------------                \n"
                    + "              |                                                                                          |              \n"
                    + "              |   88888 8              8   8 w    8    8                Yb    dP w 8 8                   |              \n"
                    + "              |     8   8d8b. .d88b    8www8   .d88 .d88 .d88b 8d8b.     Yb  dP    8 8 .d88 .d88 .d88b   |              \n"
                    + "              |     8   8P Y8 8.dP'    8   8 8 8  8 8  8 8.dP' 8P Y8      YbdP   8 8 8 8  8 8  8 8.dP    |              \n"
                    + "              |     8   8   8 `Y88P    8   8 8 `Y88 `Y88 `Y88P 8   8       YP    8 8 8 `Y88 `Y88 `Y88P   |              \n"
                    + "              |                                                                             wwdP         |              \n"
                    + "                ----------------------------------------------------------------------------------------                \n"
                    + $"\n\n\n\n\n\n\n\n\n\n\n\n\n                                                 {blink[0]} Press Enter to Start {blink[1]}");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { blink = "><"; }
    }

    public void MainMenu()
    {
        while (!picked)
        {
            string[] pickGUI = { "", "-", "-", "-", "-" };
            pickGUI[pickval] = ">";
            Console.Clear();
            Console.Write("\n\n\n"
                        + "                ----------------------------------------------------------------------------------------                \n"
                        + "              |                                                                                          |              \n"
                        + "              |   88888 8              8   8 w    8    8                Yb    dP w 8 8                   |              \n"
                        + "              |     8   8d8b. .d88b    8www8   .d88 .d88 .d88b 8d8b.     Yb  dP    8 8 .d88 .d88 .d88b   |              \n"
                        + "              |     8   8P Y8 8.dP'    8   8 8 8  8 8  8 8.dP' 8P Y8      YbdP   8 8 8 8  8 8  8 8.dP    |              \n"
                        + "              |     8   8   8 `Y88P    8   8 8 `Y88 `Y88 `Y88P 8   8       YP    8 8 8 `Y88 `Y88 `Y88P   |              \n"
                        + "              |                                                                             wwdP         |              \n"
                        + "                ----------------------------------------------------------------------------------------                \n\n\n\n\n\n");

            Console.WriteLine($"                                                      {pickGUI[1]} New Game\n\n");
            Console.WriteLine($"                                                      {pickGUI[2]} Continue\n\n");
            Console.WriteLine($"                                                      {pickGUI[3]} Tutorial\n\n");
            Console.WriteLine($"                                                        {pickGUI[4]} Exit\n\n");

            ConsoleKeyInfo inp = Console.ReadKey(true);

            if (inp.Key == ConsoleKey.UpArrow && pickval != 1) { pickval -= 1; }
            else if (inp.Key == ConsoleKey.UpArrow && pickval == 1) { pickval = 4; }
            else if (inp.Key == ConsoleKey.DownArrow && pickval != 4) { pickval += 1; }
            else if (inp.Key == ConsoleKey.DownArrow && pickval == 4) { pickval = 1; }
            else if (inp.Key == ConsoleKey.Enter && pickval == 1) { pickval = 1; NamePick(); ClassPick(); SaveData(); SelectSave(); return; }
            else if (inp.Key == ConsoleKey.Enter && pickval == 2) { pickval = 1; SelectSave(); return; }
            else if (inp.Key == ConsoleKey.Enter && pickval == 3) { pickval = 1; Tutorial(); return; }
            else if (inp.Key == ConsoleKey.Enter && pickval == 4) System.Environment.Exit(0);
        }
    }

    public void Tutorial()
    {
        Console.Clear();
        Console.WriteLine("Tutorial or smtn");
        Console.ReadKey();
        MainMenu();
    }

    public void BattleGUI()
    {
        WinLose();
        if (hitPtse <= 0 && hitPtse != maxhitPtse) return;
        if (yourturn)
        {
            while (!picked)
            {
                string[] pickGUI = { "", "-", "-", "-", "-", "-", "-", "-", "-" };
                if (stunp == 0) pickGUI[pickval] = ">";
                string stn = (stunp > 0) ? $"STN:{stunp} " : "";
                string psn = (poisonp > 0) ? $"PSN:{poisonp} " : "";
                string brn = (burnp > 0) ? $"BRN:{burnp} " : "";
                string stne = (stune > 0) ? $"{stune}:STN " : "";
                string brne = (burne > 0) ? $"{burne}:BRN " : "";
                string psne = (poisone > 0) ? $"{poisone}:PSN " : "";

                Console.Clear();
                Console.WriteLine(String.Format("  {0, -56}- -{1, 57}  ", $"--------------------------------------------------------", $"---------------------------------------------------------"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3,25} |", $"{namep} (You)", "Your Turn", $"", $"(Opponent) {namee}"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"--------------------------------------------------------", $"---------------------------------------------------------"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"Class: {classtypep}", $"{classtypee} :Class"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"Level: {levelp}", $"{levele} :Level"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"HP: {hitPtsp}/{maxhitPtsp}", $"{hitPtse}/{maxhitPtse} :HP"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"SP: {staminap}/{maxStaminap}", $"{staminae}/{maxStaminae} :SP"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"MP: {manap}/{maxManap}", $"{manae}/{maxManae} :MP"));
                if (check)
                {
                    Console.WriteLine(String.Format("  {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", "Stats:", $"{psn}{stn}{brn}", $"{psne}{stne}{brne}", ":Stats"));
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Attack:", $"- {phyAtkp}", $"{phyAtke} -", $":Physical Attack"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Power:", $"- {magAtkp}", $"{magAtke} -", $":Magical Power"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Defense:", $"- {armorp}", $"{armore} -", $":Physical Defense"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Resistance:", $"- {magResp}", $"{magRese} -", $":Magical Resistance"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Speed:", $"- {speedp}", $"{speede} -", $":Speed"));
                }
                else if (!check)
                {
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", "Stats:", $"{psn}{stn}{brn}", $"{psne}{stne}{brne}", ":Stats"));
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Attack:", $"- {phyAtkp}", $"??? -", $":Physical Attack"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Power:", $"- {magAtkp}", $"??? -", $":Magical Power"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Defense:", $"- {armorp}", $"??? -", $":Physical Defense"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Resistance:", $"- {magResp}", $"??? -", $":Magical Resistance"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Speed:", $"- {speedp}", $"??? -", $":Speed"));
                }

                if (invcheck)
                {
                    string empty1 = "";
                    string empty2 = "";
                    string[] pickGUI1 = { "-", "-", "-", "-", "-", "-", "-", "-" };
                    InventorySystem();

                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", "Inventory:", "", "", ""));
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"--------------------------------------------------------", $"---------------------------------------------------------"));

                    for (int i = 0; i < 4; i++)
                    {
                        empty1 = "x" + Convert.ToString(itemamount[i]);
                        empty2 = "x" + Convert.ToString(itemamount[i + 4]);

                        if (inventory[i] == "")
                        {
                            empty1 = "";
                        }

                        if (inventory[i + 4] == "")
                        {
                            empty2 = "";
                        }

                        if (pickval - 1 == i) pickGUI1[i] = ">";
                        else if (pickval - 1 == i + 4) pickGUI1[i + 4] = ">";
                        Console.WriteLine(String.Format("| {0, -27}   {1, -26} | {2, 29}   {3, 25} |", $"{pickGUI1[i]} {inventory[i]} {empty1}", $"{pickGUI1[i + 4]} {inventory[i + 4]} {empty2}", $"", $""));
                    }

                    Console.WriteLine(String.Format("  {0, -56}- -{1, 57} ", $"--------------------------------------------------------", $"---------------------------------------------------------"));

                    if (stunp > 0) { yourturn = false; stunp--; Console.WriteLine($"{namep} is currently stunned"); Console.ReadKey(); return; }

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow && pickval != 1) { pickval -= 1; }
                    else if (key.Key == ConsoleKey.UpArrow && pickval == 1) { pickval = 8; }
                    else if (key.Key == ConsoleKey.DownArrow && pickval != 8) { pickval += 1; }
                    else if (key.Key == ConsoleKey.DownArrow && pickval == 8) { pickval = 1; }
                    else if (key.Key == ConsoleKey.RightArrow && pickval < 5) { pickval += 4; }
                    else if (key.Key == ConsoleKey.RightArrow && pickval > 4) { pickval -= 4; }
                    else if (key.Key == ConsoleKey.LeftArrow && pickval > 4) { pickval -= 4; }
                    else if (key.Key == ConsoleKey.LeftArrow && pickval < 5) { pickval += 4; }
                    else if (key.Key == ConsoleKey.Enter && pickval > 0)
                    {
                        itemuse = pickval;
                        ItemEffect();
                        if (inventory[itemuse - 1] == "") { pickval = 1; }
                        if (pick) return;
                    }
                    else if (key.Key == ConsoleKey.Backspace && pickval > 0)
                    {
                        invcheck = false;
                        pickval = 1;
                    }
                }
                else if (combatcheck)
                {
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29}   {3,25} |", "Skills:", "Spells:", "", ""));
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29}   {3,25} |", $"{pickGUI[1]} {skill1p}", $"{pickGUI[5]} {spell1p}", $"", $""));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29}   {3,25} |", $"{pickGUI[2]} {skill2p}", $"{pickGUI[6]} {spell2p}", $"", $""));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29}   {3,25} |", $"{pickGUI[3]} {skill3p}", $"{pickGUI[7]} {spell3p}", $"", $""));
                    Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29}   {3,25} |", $"{pickGUI[4]} {skill4p}", $"{pickGUI[8]} {spell4p}", $"", $""));
                    Console.WriteLine(String.Format("  {0, -56}- -{1, 57} ", $"--------------------------------------------------------", $"---------------------------------------------------------"));

                    if (stunp > 0) { yourturn = true; stunp--; Console.WriteLine($"{namep} is currently stunned"); return; }

                    ConsoleKeyInfo inp1 = Console.ReadKey(true);

                    if (inp1.Key == ConsoleKey.UpArrow && pickval != 1) { pickval -= 1; }
                    else if (inp1.Key == ConsoleKey.UpArrow && pickval == 1) { pickval = 8; }
                    else if (inp1.Key == ConsoleKey.DownArrow && pickval != 8) { pickval += 1; }
                    else if (inp1.Key == ConsoleKey.DownArrow && pickval == 8) { pickval = 1; }
                    else if (inp1.Key == ConsoleKey.RightArrow && pickval < 5) { pickval += 4; }
                    else if (inp1.Key == ConsoleKey.RightArrow && pickval > 4) { pickval -= 4; }
                    else if (inp1.Key == ConsoleKey.LeftArrow && pickval > 4) { pickval -= 4; }
                    else if (inp1.Key == ConsoleKey.LeftArrow && pickval < 5) { pickval += 4; }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 1) { pickp = 1; combatcheck = false; pickval = 1; Skills(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 2) { pickp = 2; combatcheck = false; pickval = 1; Skills(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 3) { pickp = 3; combatcheck = false; pickval = 1; Skills(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 4) { pickp = 4; combatcheck = false; pickval = 1; Skills(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 5) { pickp = 5; combatcheck = false; pickval = 1; Spells(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 6) { pickp = 6; combatcheck = false; pickval = 1; Spells(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 7) { pickp = 7; combatcheck = false; pickval = 1; Spells(); }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 8) { pickp = 8; combatcheck = false; pickval = 1; Spells(); }
                    else if (inp1.Key == ConsoleKey.Backspace) { invcheck = false; combatcheck = false; pickval = 1; }
                }
                else
                {
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                    Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", "Actions:", "", "", ""));
                    Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"--------------------------------------------------------", $"---------------------------------------------------------"));
                    Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"{pickGUI[1]} Fight", $"", $"", $""));
                    Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"{pickGUI[2]} Check", $"", $"", $""));
                    Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"{pickGUI[3]} Inventory", $"", $"", $""));
                    Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"{pickGUI[4]} Run", $"", $"", $""));
                    Console.WriteLine(String.Format("  {0, -56}- -{1, 57} ", $"--------------------------------------------------------", $"---------------------------------------------------------"));

                    if (stunp > 0) { yourturn = true; stunp--; Console.WriteLine($"{namep} is currently stunned"); return; }

                    ConsoleKeyInfo inp1 = Console.ReadKey(true);

                    if (inp1.Key == ConsoleKey.UpArrow && pickval != 1) { pickval -= 1; }
                    else if (inp1.Key == ConsoleKey.UpArrow && pickval == 1) { pickval = 4; }
                    else if (inp1.Key == ConsoleKey.DownArrow && pickval != 4) { pickval += 1; }
                    else if (inp1.Key == ConsoleKey.DownArrow && pickval == 4) { pickval = 1; }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 1) { pickval = 1; combatcheck = true; }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 2) { pickval = 1; check = true; }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 3) { pickval = 1; invcheck = true; }
                    else if (inp1.Key == ConsoleKey.Enter && pickval == 4) System.Environment.Exit(0);
                }
            }
            picked = false;
        }
        else if (!yourturn)
        {
            string stn = (stunp > 0) ? $"STN:{stunp} " : "";
            string psn = (poisonp > 0) ? $"PSN:{poisonp} " : "";
            string brn = (burnp > 0) ? $"BRN:{burnp} " : "";
            string stne = (stune > 0) ? $"{stune}:STN " : "";
            string brne = (burne > 0) ? $"{burne}:BRN " : "";
            string psne = (poisone > 0) ? $"{poisone}:PSN " : "";

            Console.Clear();
            Console.WriteLine(String.Format("  {0, -56}- -{1, 57}  ", $"--------------------------------------------------------", $"---------------------------------------------------------"));
            Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3,25} |", $"{namep} (You)", "", $"Enemy Turn", $"(Opponent) {namee}"));
            Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"--------------------------------------------------------", $"---------------------------------------------------------"));
            Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"Class: {classtypep}", $"{classtypee} :Class"));
            Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"Level: {levelp}", $"{levele} :Level"));
            Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"HP: {hitPtsp}/{maxhitPtsp}", $"{hitPtse}/{maxhitPtse} :HP"));
            Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"SP: {staminap}/{maxStaminap}", $"{staminae}/{maxStaminae} :SP"));
            Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"MP: {manap}/{maxManap}", $"{manae}/{maxManae} :MP"));
            if (check)
            {
                Console.WriteLine(String.Format("  {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", "Stats:", $"{psn}{stn}{brn}", $"{psne}{stne}{brne}", ":Stats"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Attack:", $"- {phyAtkp}", $"{phyAtke} -", $":Physical Attack"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Power:", $"- {magAtkp}", $"{magAtke} -", $":Magical Power"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Defense:", $"- {armorp}", $"{armore} -", $":Physical Defense"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Resistance:", $"- {magResp}", $"{magRese} -", $":Magical Resistance"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Speed:", $"- {speedp}", $"{speede} -", $":Speed"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", "", "", "", ""));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"--------------------------------------------------------", $"---------------------------------------------------------"));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("  {0, -56}- -{1, 57} ", $"--------------------------------------------------------", $"---------------------------------------------------------"));
            }
            else if (!check)
            {
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", "Stats:", $"{psn}{stn}", $"", ":Stats"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Attack:", $"- {phyAtkp}", $"??? -", $":Physical Attack"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Power:", $"- {magAtkp}", $"??? -", $":Magical Power"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Physical Defense:", $"- {armorp}", $"??? -", $":Physical Defense"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Magical Resistance:", $"- {magResp}", $"??? -", $":Magical Resistance"));
                Console.WriteLine(String.Format("| {0, -25} | {1, -28} | {2, 29} | {3, 25} |", $"Speed:", $"- {speedp}", $"??? -", $":Speed"));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"-------------------------- -----------------------------", $"------------------------------ --------------------------"));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", "", "", "", ""));
                Console.WriteLine(String.Format("| {0, -56} | {1, 57} |", $"--------------------------------------------------------", $"---------------------------------------------------------"));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("| {0, -18}   {1, -35} | {2, 36}   {3, 18} |", $"", $"", $"", $""));
                Console.WriteLine(String.Format("  {0, -56}- -{1, 57} ", $"--------------------------------------------------------", $"---------------------------------------------------------"));
            }
            StatusCheck();
            if (stune > 0) { stune--; Console.WriteLine($"{namee} is currently stunned"); return; }
            else RandomAtk();
        }

        Turns();
    }

    public void WinLose()
    {
        if (hitPtse <= 0 && hitPtse != maxhitPtse)
        {
            win = true;
            lose = true;
            Console.Clear();
            Console.WriteLine($"You defeated {namee}\n");
            BattleEnd();
        }
        else if (hitPtsp <= 0 && hitPtsp != maxhitPtsp)
        {
            win = false;
            lose = true;
            phyAtkp -= tempatk;
            magAtkp -= temppow;
            armorp -= temparmor;
            magResp -= tempres;
            speedp -= tempspeed;
            tempatk = 0;
            temppow = 0;
            temparmor = 0;
            tempres = 0;
            tempspeed = 0;
            stunp = 0;
            Console.Clear();
            Console.WriteLine($"You have been defeated");
            Console.ReadKey();
            SelectSave();
        }
        pickval = 1;
    }

    public void BattleLoop()
    {
        do
        {
            BattleGUI();
            Console.ReadKey();
        } while (!win && !lose);
    }

    public void BattleEnd()
    {
        phyAtkp -= tempatk;
        magAtkp -= temppow;
        armorp -= temparmor;
        magResp -= tempres;
        speedp -= tempspeed;
        tempatk = 0;
        temppow = 0;
        temparmor = 0;
        tempres = 0;
        tempspeed = 0;
        stunp = 0;
        poisonp = 0;
        burnp = 0;
        Console.Clear();
        Console.WriteLine("Battle Ended");
        LevelSystem();
        win = false;
        Console.ReadLine();
        Events();
        StoryGUI();
    }

    public void NamePick()
    {
        string? name1 = "";
        int? name2 = 0;
        Console.CursorVisible = true;

        while (name1 == "" || name2 > 20)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,45}   {1,-27}   {2,45}", "", "- - - - - - - - - - - - - -", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", "", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", "      Enter your Name: ", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", "", ""));
            Console.WriteLine(String.Format("{0,45}   {1,-27}   {2,45}", "", "- - - - - - - - - - - - - -", ""));
            Console.Write(String.Format("{0,45}  {1,27}", "\n\n\n", " > "));
            name1 = Console.ReadLine();
            name1 = name1.Replace(" ", "");
            name2 = name1.Length;
            namep = name1;
        }
        Console.CursorVisible = false;
        Console.ReadKey();
    }

    public void ClassPick()
    {
        while (!picked)
        {
            string[] pickGUI = { " ", "-", "-", "-" };
            pickGUI[pickval] = ">";

            Console.Clear();
            Console.WriteLine(String.Format("{0,45}   {1,-27}   {2,45}", "", "- - - - - - - - - - - - - -", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", "", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", $"     Choose your fate", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", "", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", $"      {pickGUI[1]} Knight", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", $"      {pickGUI[2]} Mage", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", $"      {pickGUI[3]} Assassin", ""));
            Console.WriteLine(String.Format("{0,45} | {1,-27} | {2,45}", "", "", ""));
            Console.WriteLine(String.Format("{0,45}   {1,-27}   {2,45}", "", "- - - - - - - - - - - - - -", ""));

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.UpArrow && pickval != 1) { pickval -= 1; }
            else if (key.Key == ConsoleKey.UpArrow && pickval == 1) { pickval = 3; }
            else if (key.Key == ConsoleKey.DownArrow && pickval != 3) { pickval += 1; }
            else if (key.Key == ConsoleKey.DownArrow && pickval == 3) { pickval = 1; }
            else if (key.Key == ConsoleKey.Enter && pickval > 0)
            {
                switch (pickval)
                {
                    case 1:
                        classtypep = "Knight";
                        hitPtsp = 2250;
                        maxhitPtsp = hitPtsp;
                        staminap = 562;
                        maxStaminap = staminap;
                        manap = 148;
                        maxManap = 148;
                        maxManap = manap;
                        phyAtkp = 524;
                        magAtkp = 80;
                        armorp = 260;
                        magResp = 177;
                        speedp = 53;
                        evasionp = 0;
                        skill1p = "Arc Slash";
                        skill2p = "Fortify";
                        skill3p = ""; //Shield Bash
                        skill4p = ""; //Ultima
                        spell1p = "Enhance";
                        spell2p = ""; //Nullify
                        spell3p = ""; //Aegis
                        spell4p = "";
                        passivep = "Resilient";
                        break;
                    case 2:
                        classtypep = "Mage";
                        hitPtsp = 1306;
                        maxhitPtsp = hitPtsp;
                        staminap = 47;
                        maxStaminap = staminap;
                        manap = 867;
                        maxManap = manap;
                        phyAtkp = 32;
                        magAtkp = 560;
                        armorp = 133;
                        magResp = 333;
                        speedp = 102;
                        evasionp = 0;
                        skill1p = "Cudgel Strike";
                        skill2p = "Rest";
                        skill3p = "";
                        skill4p = "";
                        spell1p = "Fireball";
                        spell2p = ""; //Ice Shield
                        spell3p = ""; //Healing Light
                        spell4p = ""; //Thunder's Wrath
                        passivep = "Gnosis";
                        break;
                    case 3:
                        classtypep = "Assassin";
                        hitPtsp = 987;
                        maxhitPtsp = hitPtsp;
                        staminap = 1098;
                        maxStaminap = staminap;
                        manap = 371;
                        maxManap = manap;
                        phyAtkp = 899;
                        magAtkp = 26;
                        armorp = 78;
                        magResp = 299;
                        speedp = 307;
                        evasionp = 30;
                        skill1p = "Dual Cut";
                        skill2p = "Focus";
                        skill3p = ""; //Shadow Step
                        skill4p = ""; //Piercing Barrage
                        spell1p = "Dark Veil";
                        spell2p = ""; //Life Steal
                        spell3p = ""; //Phantom Strike
                        spell4p = "";
                        passivep = "Nimble Grace";
                        break;
                }
                pickval = 1;
                return;
            }
        }
        Console.ReadKey();
    }

    public void SelectSave()
    {
        StreamReader? reader = null;
        string? datap;
        string[] dataparray;
        string[] savename = { "", "", "" };
        string[] savelvl = { "", "", "" };
        string[] saveclass = { "", "", "" };

        try
        {
            for (int i = 0; i < 3; i++)
            {
                reader = new StreamReader($"C:\\Users\\MY PC\\Desktop\\Files\\C#\\#5RPGV2\\RPGv2\\Savestate{i}.txt");
                datap = Encoding.Unicode.GetString(Convert.FromBase64String(reader.ReadLine()));
                dataparray = datap.Split("|");
                reader.Close();

                savename[i] = dataparray[0];
                saveclass[i] = $"Class: {dataparray[1]}";
                savelvl[i] = $"Level: {dataparray[22]}";

                if (savename[i] == "")
                {
                    savename[i] = "Empty";
                    saveclass[i] = "";
                    savelvl[i] = "";
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
        }

        while (!picked)
        {
            Console.Clear();
            string one = "", two = "", three = "";

            if (input == "1") one = "<";
            else if (input == "2") two = "<";
            else if (input == "3") three = "<";

            Console.WriteLine($"                                                     Select Save File:");
            Console.WriteLine(String.Format("                                   -{0,-15}---{1,-15}---{2,-15}- ", "---------------", "---------------", "---------------"));
            Console.WriteLine(String.Format("                                  | {0,-15} | {1,-15} | {2,-15} |", $"Slot 1 {one}", $"Slot 2 {two}", $"Slot 3 {three}"));
            Console.WriteLine(String.Format("                                  | {0,-15} | {1,-15} | {2,-15} |", $"{savename[0]}", $"{savename[1]}", $"{savename[2]}"));
            Console.WriteLine(String.Format("                                  | {0,-15} | {1,-15} | {2,-15} |", $"{savelvl[0]}", $"{savelvl[1]}", $"{savelvl[2]}"));
            Console.WriteLine(String.Format("                                  | {0,-15} | {1,-15} | {2,-15} |", $"{saveclass[0]}", $"{saveclass[1]}", $"{saveclass[2]}"));
            Console.WriteLine(String.Format("                                   -{0,-15}---{1,-15}---{2,-15}- ", "---------------", "---------------", "---------------"));

            ConsoleKeyInfo inp1 = Console.ReadKey(true);

            if (inp1.Key == ConsoleKey.RightArrow && input == "1") { input = "2"; }
            else if (inp1.Key == ConsoleKey.LeftArrow && input == "1") { input = "3"; }
            else if (inp1.Key == ConsoleKey.RightArrow && input == "2") { input = "3"; }
            else if (inp1.Key == ConsoleKey.LeftArrow && input == "2") { input = "1"; }
            else if (inp1.Key == ConsoleKey.RightArrow && input == "3") { input = "1"; }
            else if (inp1.Key == ConsoleKey.LeftArrow && input == "3") { input = "2"; }
            else if (inp1.Key == ConsoleKey.Enter)
            {
                save = Convert.ToByte(input);
                if (savename[Convert.ToByte(input) - 1] == "Empty")
                {
                    NamePick();
                    ClassPick();
                    SaveData();
                    StoryGUI();
                    return;
                }
                else
                {
                    GetSave();
                    eventValue = "a1";
                    GetEnemy();
                    SaveData();
                    StoryGUI();
                    return;
                }
            }
            else if (inp1.Key == ConsoleKey.Backspace) { MainMenu(); }
        }
    }

    public void StoryGUI()
    {
        byte count = 0;
        Console.Clear();

        if (eventValue == "a1")
        {
            parta1 = "Prologue:In a quaint corner of the bustling city of Eldoria, a young man named Alec lived with a passion that set him apart from his peers. While others were content with the humdrum of everyday life, Alec harbored a burning curiosity for the past. He spent countless hours scouring dusty archives and tomes in the city's libraries, yearning to uncover forgotten histories. One fateful day, as Alec was diligently cataloging ancient scrolls, his fingers brushed against an old parchment tucked away in a dusty corner of the archive. The scroll bore a cryptic message, written in a script that hadn't been used in centuries. It spoke of a village called Eldoria, shrouded in myths and legends, said to have disappeared from the annals of history. The final lines of the scroll contained a riddle \"Beyond the horizon, where the sky kisses the land, Eldoria stands where the shadows of two trees land.\"Alec's heart raced as he read those words. He was convinced that this village held the key to unraveling the mysteries of the past. He knew he had to embark on a journey to find Eldoria, to bring its lost stories back to life." + " ";
            parta2 = "The air outside the city's protective walls felt different—charged with a sense of anticipation and uncertainty. As Alec ventured into the unknown, he left behind the familiar sights and sounds of the bustling city, immersing himself in a world where the echoes of civilization grew fainter with each passing step. The treacherous path ahead unfolded like a labyrinth of challenges, where the field plains conspired to test Alec's determination. Tall grasses swayed in the breeze, creating an ever-shifting maze that seemed to have a mind of its own. The subtle whispers of the wind carried tales of forgotten adventures and hidden dangers, urging Alec to proceed with caution. The ground beneath his boots transformed into a battleground as slimes emerged from the underbrush, their amorphous bodies leaving a trail of sticky residue in their wake. Each step became a tussle against the tenacious grasp of the slimes, their gelatinous forms resisting his every movement and its acid starts to melt his boots. Alec prepares for battle." + " ";

            for (int i = 0; i < parta1.Length; i++)
            {
                if (parta1[i] == '.' || parta1[i] == '?' || parta1[i] == '!')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta1[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta1[i] == ',')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(spause);
                }
                else if (parta1[i] == ':')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n> Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            epause = 1500; lpause = 1000; spause = 500; type = 35; count = 0;

            Console.WriteLine("Prologue: \n\n");

            for (int i = 0; i < parta2.Length; i++)
            {
                if (parta2[i] == '.' || parta2[i] == '?' || parta2[i] == '!')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta2[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta2[i] == ',')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(spause);
                }
                else
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n> Press any key to start the battle.");
            Console.ReadKey();
        }

        if (eventValue == "a2")
        {
            epause = 1500; lpause = 1000; spause = 500; type = 35; count = 0;
            parta1 = "Chapter 1 - The Long Road and The Deep Forest Gate:Alec, having vanquished the slime and cleansed himself of its lingering residue, resumed his adventurous quest. Aware of the simmering tensions and desiring to avoid unnecessary conflicts, he chose a safer yet more circuitous route, carefully navigating the terrain and rationing his limited supplies with a strategic eye. As Alec pressed on, the horizon revealed the silhouette of the Kingdom of Errau, a majestic realm with towering spires and impressive structures that captured the imagination. However, the guards stationed at the kingdom's entrance shattered any illusions of a warm welcome. Citing recent discord with outsiders, they were resolute in their refusal to admit Alec. Alec, fueled by determination and an unyielding spirit, saw this as an opportunity to showcase the resourcefulness that had guided him through previous challenges. Formulating a plan to circumvent the vigilant guards, he veered towards the fringes of the kingdom, where a dense forest veiled the borders. Entering the shadows of the towering trees, Alec relied on his skills in stealth to traverse the thick foliage unnoticed. The air was thick with the scent of ancient moss and the distant murmurings of the kingdom's activity. As he moved deeper into the forest, the guards remained unaware of his presence, and Alec's hopes of slipping past them soared. Yet, despite his best efforts, the forest betrayed him. A twig snapped underfoot, or perhaps a leaf crunched at an inopportune moment the guards, attuned to the nuances of their surroundings, swiftly discerned Alec's presence." + " ";
            parta2 = "A stern voice echoed through the trees, and the once tranquil atmosphere shifted as a knight, adorned in formidable armor, galloped toward Alec on a powerful steed. Caught off guard, Alec braced himself for the impending confrontation, his eyes narrowing with determination as he prepared to face the consequences of his clandestine entry into the Kingdom of Errau. The dense forest, witness to Alec's every move, stood silent as the knight swiftly rushes to the source of the sound. Realizing that his attempt at slipping past the guards had been foiled, Alec's instincts kicked in, and he attempted a swift retreat through the dense forest. The underbrush rustled beneath his hurried footsteps as he sought cover among the towering trees, hoping to evade the knight hot on his trail. However, the knight, skilled and determined, proved relentless. The pounding hooves of the steed echoed through the woods, and the knight's pursuit closed in with each passing moment, and Alec's breath quickened, and the urgency of the situation spurred him to push his limits, weaving through the labyrinth of trees in a desperate bid to escape. Despite his agile maneuvers, Alec found himself cornered. A dead end revealed itself, and Alec knew he could no longer elude his pursuer. With a resigned breath, he turned to face the approaching knight, who reigned in his steed, bringing both horse and rider to a powerful and imposing halt. The knight, armored and formidable, dismounted with a deliberate grace. His gaze, obscured by the visor of his helmet, A charged silence enveloped the clearing as Alec, acknowledging the inevitable. Alec prepared for battle." + " ";

            for (int i = 0; i < parta1.Length; i++)
            {
                if (parta1[i] == '.' || parta1[i] == '?' || parta1[i] == '!')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta1[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta1[i] == ',')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(spause);
                }
                else if (parta1[i] == ':')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n> Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            epause = 1500; lpause = 1000; spause = 500; type = 35;

            Console.WriteLine("Chapter 1 - The Long Road and The Deep Forest Gate: \n\n");

            for (int i = 0; i < parta2.Length; i++)
            {
                if (parta2[i] == '.' || parta2[i] == '?' || parta2[i] == '!')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta2[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta2[i] == ',')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(spause);
                }
                else
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n\n\n> Press any key to start the battle.");
            Console.ReadKey();
        }

        if (eventValue == "a3")
        {
            epause = 1500; lpause = 1000; spause = 500; type = 35; count = 0;
            parta1 = "Chapter 2 - Underground Sacred Grounds:After the battle with the knight he helps him out and explains his side of the story, the knight impressed by his skills and determination, lets him pass through the gates in order to enter the kingdom. As he entered the bustling streets, the vibrant energy of the place washed over him. Stalls lined with colorful fabrics, exotic spices, and intricate trinkets enticed passersby. Towers adorned with intricate carvings loomed overhead, casting long shadows on the cobblestone streets. The air was thick with the aroma of street food, and the lively chatter of merchants haggling with customers filled the atmosphere. However, Alec could sense an underlying tension as he traversed the crowded marketplace. The guards, with stern expressions and imposing armor, patrolled the streets diligently, their watchful eyes following every movement of outsiders. Undeterred by the guarded atmosphere, Alec navigated the market, skillfully negotiating for supplies and equipment essential for his impending journey. Merchants, initially skeptical of the outsider, gradually warmed up to him as he displayed a genuine interest in their wares and respect for their customs. Amidst the commerce and commotion, Alec overheard whispers of recent conflicts with strangers that had heightened the guards' suspicion. Eager to avoid unnecessary trouble, Alec chose a more cautious approach, ensuring that his interactions were brief and respectful. As the day unfolded, Alec rented an inn in order to rest for the night." + " ";
            parta2 = "As the night passed, Alec with his equipment and secured essential provisions for the perilous expedition that lay ahead, Alec directed his course towards an underground cave that cut through the imposing mountains. Delving deep into the cavernous depths, darkness slowly covered his surroundings the deeper he goes. He lights his torch as the caverns became pitch black, he continues to walk and sees a light far ahead. Following the light from afar, Alec stumbled upon a an ogre camp nestled within the shadows. Recognizing the potential danger of a direct confrontation, Alec cautiously observe the ogres from a safe distance. Hidden amongst the stalactites and stalagmites, he overheard their hushed conversations, which revolved around an ancient temple concealed amidst the sprawling trees—a place they held in profound reverence. Mindful of the risks posed by the ogres, Alec absorbed every word, learning of the sacred significance the temple held in their folklore. With the newfound knowledge, Alec followed the cryptic directions shared by the ogres, eventually uncovering the hidden entrance to the temple. Thick vines and moss veiled the passage, concealing the ancient structure from casual passersby. As Alec ventured into the temple's dimly lit interior, he was greeted by a mesmerizing mural adorning the walls. The mural unfolded a visual narrative—a map that tantalizingly hinted at the elusive location of Eldoria. " + " ";
            parta3 = "While reading the mysterious mural, Alec failed to hear the footstpes slowly approaching closer to his location, then a group of patrolling orcs found him out and tried subdued the trespasser, Alec's heart raced as who seems to be the leader of the group with a menacing figure and a twisted grin, glared at him with very high intensity. One of the goblin soldiers, armed with a rusty blade, brazenly stepped forward, ready to carry out the leader's command. Alec stammered, trying to reason with the goblin but despite his best efforts his reasoning did not work against them. The goblin leader scoffed, his eyes narrowing and untrusting of Alec, he carries oout a signal to one of his soldiers. A goblin soldier, grinned maliciously and approached Alec with his weapon raised. Alec, realizing he had no choice, drew swiftly drew out his own weapon, with a glint of determination and bravery in his eyes. Alec prepares for battle." + " ";

            for (int i = 0; i < parta1.Length; i++)
            {
                if (parta1[i] == '.' || parta1[i] == '?' || parta1[i] == '!')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta1[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta1[i] == ',')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(spause);
                }
                else if (parta1[i] == ':')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n\n> Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            epause = 1500; lpause = 1000; spause = 500; type = 35;

            Console.WriteLine("Chapter 2 - Underground Sacred Grounds: \n\n");

            for (int i = 0; i < parta2.Length; i++)
            {
                if (parta2[i] == '.' || parta2[i] == '?' || parta2[i] == '!')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta2[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta2[i] == ',')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(spause);
                }
                else
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n\n\n> Press any key to start the battle.");
            Console.ReadKey();
            Console.Clear();

            epause = 1500; lpause = 1000; spause = 500; type = 35;

            Console.WriteLine("Chapter 2 - Underground Sacred Grounds: \n\n");

            for (int i = 0; i < parta3.Length; i++)
            {
                if (parta3[i] == '.' || parta3[i] == '?' || parta3[i] == '!')
                {
                    Console.Write(parta3[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta3[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta3[i] == ',')
                {
                    Console.Write(parta3[i]);
                    Thread.Sleep(spause);
                }
                else
                {
                    Console.Write(parta3[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }
            Console.WriteLine("\n\n> Press any key to start the battle.");
            Console.ReadKey();
        }

        if (eventValue == "a4")
        {
            epause = 1500; lpause = 1000; spause = 500; type = 35; count = 0;
            parta1 = "Chapter 2 - Underground Sacred Grounds:Alec, having swiftly subdued one of the soldiers with a calculated blend of skill and precision, found himself in a tense standoff with the remaining members of the opposing force. As the atmosphere crackled with the palpable tension of imminent conflict, the rest of the soldiers hesitated, uncertain about how to proceed. However, their leader, a stern and authoritative figure, swiftly intervened, issuing a commanding order for his subordinates to stand down. In a resolute tone that carried the weight of authority, the leader sternly directed the group, to hold down. His words sliced through the air, resonating with a mix of confidence and determination. The soldiers reluctantly complied, casting furtive glances at Alec, who stood poised and ready for any further challenges. The leader, undeterred by the earlier setback suffered by his comrade, stepped forward with an air of unwavering resolve. His every movement exuded confidence as he closed the distance between himself and Alec." + " ";
            parta2 = "The tension in the air heightened, and an aura of anticipation surrounded the impending confrontation. As the two adversaries faced off, a charged silence enveloped the scene, broken only by the distant sounds of the surrounding environment. The leader, sizing up Alec with a discerning gaze, seemed to calculate his next move. Alec, in turn, maintained a vigilant stance, fully aware that the unfolding encounter would require every ounce of his skill and determination. In this moment of confrontation, the dynamics shifted, and the battlefield seemed to shrink to the immediate space between Alec and the formidable leader. The air crackled with an unspoken challenge, setting the stage for a duel that would determine the course of the unfolding conflict. The leader, having taken matters into his own hands, stood as the embodiment of their adversary\'s resilience, ready to face Alec in a showdown that would test the limits of both their abilities. Alec prepares for battle." + " ";

            for (int i = 0; i < parta1.Length; i++)
            {
                if (parta1[i] == '.' || parta1[i] == '?' || parta1[i] == '!')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta1[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta1[i] == ',')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(spause);
                }
                else if (parta1[i] == ':')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n> Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            epause = 1500; lpause = 1000; spause = 500; type = 35;

            Console.WriteLine("Chapter 2 - Underground Sacred Grounds: \n\n");

            for (int i = 0; i < parta2.Length; i++)
            {
                if (parta2[i] == '.' || parta2[i] == '?' || parta2[i] == '!')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta2[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta2[i] == ',')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(spause);
                }
                else
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n\n\n> Press any key to start the battle.");
            Console.ReadKey();
        }

        if (eventValue == "a5")
        {
            epause = 1500; lpause = 1000; spause = 500; type = 35; count = 0;
            parta1 = "Chapter 3 - The Sun's Blinding Fury:After defeating the leader, Alec cautiously studied the intricate mural that adorned the ancient temple's walls. Alec's attention was unexpectedly drawn to a glint of light. Through the billowing smoke and falling debris, he caught sight of a pendant worn by the vanquished leader, now discarded amidst the chaos. The pendant, an intricate and ornate emblem, seemed to bear a significance that transcended mere adornment. In a moment of intuition, Alec deftly retrieved the pendant from the deceased body of the leader. As he held it in his hands, the pendant began to pulsate with an otherworldly energy. Unbeknownst to Alec, the pendant acted key, it used the life force of the wearer in order to bind a mythical beast used for wars thousands of years ago. As Alec examined the pendant, a surge of power resonated from within, causing the emblem to fracture. The delicate balance of the guardian's seal shattered, and an ethereal force began to emanate from the broken pendant. The mythical beast, momentarily diverted from its conflict with Alec, reacted to the disturbance with a majestic yet disoriented presence. " + " ";
            parta2 = "Suddenly, a burst of flames erupted in the chamber, signaling the arrival of the temple's majestic guardian, a Phoenix ablaze with anger. The mythical beast's fiery presence triggered a cataclysmic reaction within the sacred structure. A Phoenix unfurled its fiery wings, a powerful shockwave emanated from its majestic form, shaking the very foundations of the temple. Cracks appeared on the walls, and ancient stones dislodged, revealing glimpses of the outside world beyond. The guardian, embodying both beauty and wrath, seemed to be a force of nature, and its displeasure manifested in the destructive upheaval of the temple. The once-sturdy pillars crumbled, and the ceiling began to disintegrate. The mural, once a testament to the temple's storied history, became a casualty of the escalating chaos. Alec, now confronted not only by the formidable Phoenix but also by the crumbling environment, had to adapt swiftly to the evolving battleground. As the guardian unleashed torrents of flame, Alec skillfully navigated the disintegrating temple, using falling debris and collapsing structures to his advantage. The destruction wrought by the Phoenix revealed the outside world in stark contrast to the confined interior. Moonlight streamed through the newfound openings, casting a blinding glow on the unfolding battle. Alec prepares for battle" + " ";

            for (int i = 0; i < parta1.Length; i++)
            {
                if (parta1[i] == '.' || parta1[i] == '?' || parta1[i] == '!')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta1[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta1[i] == ',')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(spause);
                }
                else if (parta1[i] == ':')
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(lpause);
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.Write(parta1[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n> Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            epause = 1500; lpause = 1000; spause = 500; type = 35;

            Console.WriteLine("Chapter 3 - The Sun's Blinding Fury: \n\n");

            for (int i = 0; i < parta2.Length; i++)
            {
                if (parta2[i] == '.' || parta2[i] == '?' || parta2[i] == '!')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(lpause);
                    count++;
                    if (count == 2)
                    {
                        i++;
                        Console.Write($"{parta2[i]}");
                        Console.WriteLine("\n");
                        count = 0;
                    }
                }
                else if (parta2[i] == ',')
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(spause);
                }
                else
                {
                    Console.Write(parta2[i]);
                    Thread.Sleep(type);
                }

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    lpause = 0;
                    spause = 0;
                    type = 0;
                }
            }

            Console.WriteLine("\n\n\n> Press any key to start the battle.");
            Console.ReadKey();
        }
        BattleStart();
    }
}