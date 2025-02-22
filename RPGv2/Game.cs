using System.Data;
using System.Formats.Asn1;
using System.Text;

class Game
{
    //Events
    public string eventValue;

    //Player Stats
    public string? namep;
    public string classtypep;
    public int levelp;
    public int levelupval;
    public float expp;
    public long hitPtsp;
    public long maxhitPtsp;
    public int staminap;
    public int maxStaminap;
    public int manap;
    public int maxManap;
    public int phyAtkp;
    public int magAtkp;
    public int armorp;
    public int magResp;
    public int speedp;
    public int evasionp;
    public string skill1p;
    public string skill2p;
    public string skill3p;
    public string skill4p;
    public string spell1p;
    public string spell2p;
    public string spell3p;
    public string spell4p;
    public long damageskillp;
    public long damagespellp;
    public bool defendp;
    public string passivep;
    public int stunp = 0;
    public int burnp = 0;
    public int poisonp = 0;

    //Enemy Stats
    public string? namee;
    public string classtypee;
    public int levele;
    public float expe;
    public long hitPtse;
    public long maxhitPtse;
    public int staminae;
    public int maxStaminae;
    public int manae;
    public int maxManae;
    public int phyAtke;
    public int magAtke;
    public int armore;
    public int magRese;
    public int speede;
    public int evasione;
    public string skill1e;
    public string skill2e;
    public string skill3e;
    public string skill4e;
    public string spell1e;
    public string spell2e;
    public string spell3e;
    public string spell4e;
    public long damageskille;
    public long damagespelle;
    public bool defende;
    public string passivee;
    public int stune = 0;
    public int burne = 0;
    public int poisone = 0;

    //Game Stuff
    public bool check = true;
    public bool invcheck = false;
    public bool combatcheck = false;
    public int itemuse;
    public int tempatk = 0;
    public int temppow = 0;
    public int temparmor = 0;
    public int tempres = 0;
    public int tempspeed = 0;
    public bool levelup = false;
    public byte reached = 0;
    public bool criticalhit = false;
    public byte save = 1;
    public bool clear = false;
    public long totalDmg;
    public byte pickp = 2;
    public string input = "1";
    public int pickval = 1;
    public bool picked = false;
    public int spadd = 0;
    public int mpadd = 0;
    public int xpadd = 0;
    public bool yourturn;
    public int expadd = 0;
    public int spcost = 0;
    public int mpcost = 0;
    public int moveAccuracy;
    public bool pick;
    public bool win = false;
    public bool lose = false;
    public int epause = 1500, lpause = 1000, spause = 500, type = 35;
    public string? parta1, parta2, parta3, parta4, parta5, partb1, partb2, partb3, partb4, partb5;
    public int whichTurn;
    Random numberGen = new();

    //Lists
    public string[] enemylist = { "Slime", "Royal Knight", "Orc Warrior", "Orc Warlord", "Phoenix", "Bandit", "Elven Duelist", "Warlock", "Gate Guardian", "Cult Leader", "Cthulu" };
    public string[] itemlist = { "Small Healing Potion", "Large Healing Potion", "Lesser Mana Potion", "Greater Mana Potion", "Rock Potion", "Swiftness Potion", "Antidote", "Phoenix Feather", "Smoke Bomb", "Grenade", "Flash Bomb", "Mind Elixir", "Might Elixir" };
    public int[] itemamount = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public string[] inventory = { "", "", "", "", "", "", "", "", "" };

    public Game()
    {
        hitPtsp = 0;
        levelp = 1;
        levelupval = 50;
        expp = 0f;
        eventValue = "a1";
    }

    public void SaveData()
    {
        StreamWriter writer = null;

        try
        {
            switch (save)
            {
                case 1:
                    writer = new StreamWriter("C:\\Users\\MY PC\\Desktop\\Stuff\\C#\\#5RPGV2\\RPGv2\\Savestate0.txt");
                    break;
                case 2:
                    writer = new StreamWriter("C:\\Users\\MY PC\\Desktop\\Stuff\\C#\\#5RPGV2\\RPGv2\\Savestate1.txt");
                    break;
                case 3:
                    writer = new StreamWriter("C:\\Users\\MY PC\\Desktop\\Stuff\\C#\\#5RPGV2\\RPGv2\\Savestate2.txt");
                    break;
                default:
                    SaveData();
                    break;
            }

            //Encrypt = Convert.ToBase64String(Encoding.Unicode.GetBytes(example));
            //Decrypt = Encoding.Unicode.GetString(Convert.FromBase64String(example));
            writer.WriteLine(@$"{namep}|{classtypep}|{hitPtsp}|{maxhitPtsp}|{staminap}|{maxStaminap}|{manap}|{maxManap}|{phyAtkp}|{magAtkp}|{armorp}|{magResp}|{speedp}|{evasionp}|{skill1p}|{skill2p}|{skill3p}|{skill4p}|{spell1p}|{spell2p}|{spell3p}|{spell4p}|{levelp}|{passivep}|{expp}|{levelupval}");
            writer.WriteLine(@$"{namee}|{classtypee}|{hitPtse}|{maxhitPtse}|{staminae}|{maxStaminae}|{manae}|{maxManae}|{phyAtke}|{magAtke}|{armore}|{magRese}|{speede}|{evasione}|{skill1e}|{skill2e}|{skill3e}|{skill4e}|{spell1e}|{spell2e}|{spell3e}|{spell4e}|{levele}|{passivee}|{expadd}");
            writer.WriteLine(@$"{eventValue}");
            writer.WriteLine(@$"{inventory[0]}|{inventory[1]}|{inventory[2]}|{inventory[3]}|{inventory[4]}|{inventory[5]}|{inventory[6]}|{inventory[7]}|{itemamount[0]}|{itemamount[1]}|{itemamount[2]}|{itemamount[3]}|{itemamount[4]}|{itemamount[5]}|{itemamount[6]}|{itemamount[7]}");
            writer.Close();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            NamePick();
        }
        finally
        {
            //
        }
    }

    public void GetSave()
    {
        StreamReader? reader = null;
        string? datap;
        string? datae;
        string? data;
        string? datai;

        try
        {
            switch (save)
            {
                case 1:
                    reader = new StreamReader("C:\\Users\\MY PC\\Desktop\\Stuff\\C#\\#5RPGV2\\RPGv2\\Savestate0.txt");
                    break;
                case 2:
                    reader = new StreamReader("C:\\Users\\MY PC\\Desktop\\Stuff\\C#\\#5RPGV2\\RPGv2\\Savestate1.txt");
                    break;
                case 3:
                    reader = new StreamReader("C:\\Users\\MY PC\\Desktop\\Stuff\\C#\\#5RPGV2\\RPGv2\\Savestate3.txt");
                    break;
            }

            datap = Encoding.Unicode.GetString(Convert.FromBase64String(reader.ReadLine()));
            datae = Encoding.Unicode.GetString(Convert.FromBase64String(reader.ReadLine()));
            data = Encoding.Unicode.GetString(Convert.FromBase64String(reader.ReadLine()));
            datai = Encoding.Unicode.GetString(Convert.FromBase64String(reader.ReadLine()));

            string[] dataparray = datap.Split('|');
            string[] dataearray = datae.Split('|');
            string[] dataarray = data.Split('|');
            string[] dataiarray = datai.Split('|');

            namep = dataparray[0];
            classtypep = dataparray[1];
            hitPtsp = Convert.ToInt32(dataparray[2]);
            maxhitPtsp = Convert.ToInt32(dataparray[3]);
            staminap = Convert.ToInt32(dataparray[4]);
            maxStaminap = Convert.ToInt32(dataparray[5]);
            manap = Convert.ToInt32(dataparray[6]);
            maxManap = Convert.ToInt32(dataparray[7]);
            phyAtkp = Convert.ToInt32(dataparray[8]);
            magAtkp = Convert.ToInt32(dataparray[9]);
            armorp = Convert.ToInt32(dataparray[10]);
            magResp = Convert.ToInt32(dataparray[11]);
            speedp = Convert.ToInt32(dataparray[12]);
            evasionp = Convert.ToInt32(dataparray[13]);
            skill1p = dataparray[14];
            skill2p = dataparray[15];
            skill3p = dataparray[16];
            skill4p = dataparray[17];
            spell1p = dataparray[18];
            spell2p = dataparray[19];
            spell3p = dataparray[20];
            spell4p = dataparray[21];
            levelp = Convert.ToInt32(dataparray[22]);
            passivep = dataparray[23];
            expp = Convert.ToInt32(dataparray[24]);
            levelupval = Convert.ToInt32(dataparray[25]);

            namee = dataearray[0];
            classtypee = dataearray[1];
            hitPtse = Convert.ToInt32(dataearray[2]);
            maxhitPtse = Convert.ToInt32(dataearray[3]);
            staminae = Convert.ToInt32(dataearray[4]);
            maxStaminae = Convert.ToInt32(dataearray[5]);
            manae = Convert.ToInt32(dataearray[6]);
            maxManae = Convert.ToInt32(dataearray[7]);
            phyAtke = Convert.ToInt32(dataearray[8]);
            magAtke = Convert.ToInt32(dataearray[9]);
            armore = Convert.ToInt32(dataearray[10]);
            magRese = Convert.ToInt32(dataearray[11]);
            speede = Convert.ToInt32(dataearray[12]);
            evasione = Convert.ToInt32(dataearray[13]);
            skill1e = dataearray[14];
            skill2e = dataearray[15];
            skill3e = dataearray[16];
            skill4e = dataearray[17];
            spell1e = dataearray[18];
            spell2e = dataearray[19];
            spell3e = dataearray[20];
            spell4e = dataearray[21];
            levele = Convert.ToInt32(dataearray[22]);
            passivee = dataearray[23];
            expadd = Convert.ToInt32(dataearray[24]);

            eventValue = dataarray[0];

            inventory[0] = dataiarray[0];
            inventory[1] = dataiarray[1];
            inventory[2] = dataiarray[2];
            inventory[3] = dataiarray[3];
            inventory[4] = dataiarray[4];
            inventory[5] = dataiarray[5];
            inventory[6] = dataiarray[6];
            inventory[7] = dataiarray[7];
            itemamount[0] = Convert.ToInt32(dataiarray[8]);
            itemamount[1] = Convert.ToInt32(dataiarray[9]);
            itemamount[2] = Convert.ToInt32(dataiarray[10]);
            itemamount[3] = Convert.ToInt32(dataiarray[11]);
            itemamount[4] = Convert.ToInt32(dataiarray[12]);
            itemamount[5] = Convert.ToInt32(dataiarray[13]);
            itemamount[6] = Convert.ToInt32(dataiarray[14]);
            itemamount[7] = Convert.ToInt32(dataiarray[15]);
            GetEnemy();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
        }
    }

    public void ClearSave()
    {
        StreamWriter? writer = null;
        writer = new StreamWriter($"C:\\Users\\MY PC\\Desktop\\Files\\C# Files\\#5\\RPGv2\\Savestate{save - 1}.txt");
        writer.WriteLine("|||||||||||||||||||||||");
        writer.Close();
    }

    public void InventorySystem()
    {
        //Auto Sort Inventory
        for (int o = 0; o < 8; o++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (itemamount[i] == 0)
                {
                    inventory[i] = "";
                }

                if (inventory[i] == "")
                {
                    inventory[i] = inventory[i + 1];
                    inventory[i + 1] = "";
                    itemamount[i] = itemamount[i + 1];
                    itemamount[i + 1] = 0;
                }

                if (itemamount[i] == 0)
                {
                    inventory[i] = "";
                }
            }
        }
    }

    public void ItemEffect()
    {
        if (inventory[itemuse - 1] == itemlist[0])
        {
            int hpAdd = 500;
            if (hitPtsp >= maxhitPtsp - hpAdd && hitPtsp < maxhitPtsp)
            {
                hpAdd = (int)(maxhitPtsp - hitPtsp);
                hitPtsp += hpAdd;
                Console.WriteLine($"{namep} restored {hpAdd} HP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
            else if (hitPtsp >= maxhitPtsp)
            {
                Console.WriteLine($"{namep}'s HP is already full");
                Console.ReadKey();
            }
            else
            {
                hitPtsp += hpAdd;
                Console.WriteLine($"{namep} restored {hpAdd} HP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
        }
        else if (inventory[itemuse - 1] == itemlist[1])
        {
            int hpAdd = 1000;
            if (hitPtsp >= maxhitPtsp - hpAdd && hitPtsp < maxhitPtsp)
            {
                hpAdd = (int)(maxhitPtsp - hitPtsp);
                hitPtsp += hpAdd;
                Console.WriteLine($"{namep} restored {hpAdd} HP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
            else if (hitPtsp >= maxhitPtsp)
            {
                Console.WriteLine($"{namep}'s HP is already full");
            }
            else
            {
                hitPtsp += hpAdd;
                Console.WriteLine($"{namep} restored {hpAdd} HP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
        }
        else if (inventory[itemuse - 1] == itemlist[2])
        {
            int mpAdd = 100;
            if (manap >= maxManap - mpAdd && manap < maxManap)
            {
                mpAdd = maxManap - manap;
                manap += mpAdd;
                Console.WriteLine($"{namep} restored {mpAdd} MP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
            else if (manap >= maxManap)
            {
                Console.WriteLine($"{namep}'s MP is already full");
                Console.ReadKey();
            }
            else
            {
                manap += mpAdd;
                Console.WriteLine($"{namep} restored {mpAdd} MP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
        }
        else if (inventory[itemuse - 1] == itemlist[3])
        {
            int mpAdd = 300;
            if (manap >= maxManap - mpAdd && manap < maxManap)
            {
                mpAdd = maxManap - manap;
                manap += mpAdd;
                Console.WriteLine($"{namep} restored {mpAdd} MP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
            else if (manap >= maxManap)
            {
                Console.WriteLine($"{namep}'s MP is already full");
                Console.ReadKey();
            }
            else
            {
                manap += mpAdd;
                Console.WriteLine($"{namep} restored {mpAdd} MP");
                itemamount[itemuse - 1]--;
                invcheck = false;
                pick = true;
                return;
            }
        }
        else if (inventory[itemuse - 1] == itemlist[4])
        {
            armorp += 75;
            temparmor += 75;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Armor increased 75");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[5])
        {
            speedp += 150;
            tempspeed += 150;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Speed increased by 150");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[6])
        {
            poisonp = 0;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Poison Cured");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[7])
        {
            hitPtsp = maxhitPtsp;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Resurected");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[8])
        {
            itemamount[itemuse - 1]--;
            Console.WriteLine("Enemy accuracy decreased and run chance increased");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[9])
        {
            hitPtse -= 500;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Grenade dealt 500 damage");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[10])
        {
            magResp += 100;
            tempres += magResp;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Magic Resistance increased by 100");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[11])
        {
            magAtkp += 200;
            temppow += magAtkp;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Magic Power increased by 200");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == itemlist[12])
        {
            phyAtkp += 175;
            tempatk += phyAtkp;
            itemamount[itemuse - 1]--;
            Console.WriteLine("Physical Damage increased by 175");
            invcheck = false;
            pick = true;
            return;
        }
        else if (inventory[itemuse - 1] == "") { pickval = 1; }
    }

    public void LevelSystem()
    {
        double stathp = maxhitPtsp;
        double statsp = maxStaminap;
        double statmp = maxManap;
        double statatk = phyAtkp;
        double statpow = magAtkp;
        double statdef = armorp;
        double statres = magResp;
        double statspd = speedp;

        int prevlevel = levelp;
        int levelups = levelp;
        int lvl = 0;
        expp += expadd;
        Console.WriteLine($"\n{namep} gained {expadd} exp");

        //Lvl system
        while (expp >= levelupval)
        {
            if (expp >= levelupval)
            {
                double lvlval = levelupval;

                expp = expp - levelupval;
                lvlval *= 1.5;
                lvlval = Math.Round(lvlval);
                levelupval = Convert.ToInt32(lvlval);
                levelp++;
                levelups++;
                lvl++;
                levelup = true;
            }
            else
            {
                levelup = false;
            }
        }

        if (levelup)
        {
            Console.WriteLine($"{namep} leveled up");
            Console.WriteLine($"Lvl: {prevlevel} ---> {levelups}\n");
        }

        //Lvl up stat increase
        for (int i = 0; i < lvl; i++)
        {
            if (levelup)
            {
                switch (classtypep)
                {
                    case "Knight":
                        stathp *= 1.07;
                        statsp *= 1.05;
                        statmp *= 1.01;
                        statatk *= 1.2;
                        statpow *= 1.01;
                        statdef *= 1.12;
                        statres *= 1.08;
                        statspd *= 1.01;
                        break;
                    case "Mage":
                        stathp *= 1.02;
                        statsp *= 1.09;
                        statmp *= 1.06;
                        statatk *= 1.035;
                        statpow *= 1.185;
                        statdef *= 1.02;
                        statres *= 1.06;
                        statspd *= 1.05;
                        break;
                    case "Assassin":
                        stathp *= 1.024;
                        statsp *= 1.12;
                        statmp *= 1.04;
                        statatk *= 1.5;
                        statpow *= 1.1;
                        statdef *= 1.02;
                        statres *= 1.05;
                        statspd *= 1.09;
                        break;
                }
            }

            hitPtsp = Convert.ToInt64(Math.Round(stathp));
            maxhitPtsp = Convert.ToInt64(Math.Round(stathp));
            staminap = Convert.ToInt32(Math.Round(statsp));
            maxStaminap = Convert.ToInt32(Math.Round(statsp));
            manap = Convert.ToInt32(Math.Round(statmp));
            maxManap = Convert.ToInt32(Math.Round(statmp));
            phyAtkp = Convert.ToInt32(Math.Round(statatk));
            magAtkp = Convert.ToInt32(Math.Round(statpow));
            armorp = Convert.ToInt32(Math.Round(statdef));
            magResp = Convert.ToInt32(Math.Round(statres));
            speedp = Convert.ToInt32(Math.Round(statspd));
        }

        if (levelup)
        {
            if (levelp >= 3 && reached == 0)
            {
                switch (classtypep)
                {
                    case "Knight":
                        if (skill3p == "")
                        {
                            skill3p = "Shield Bash";
                            Console.WriteLine($"{namep} learned {skill3p}");
                        }
                        break;
                    case "Mage":
                        if (spell2p == "")
                        {
                            spell2p = "Ice Shield";
                            Console.WriteLine($"{namep} learned {spell2p}");
                        }
                        break;
                    case "Assassin":
                        if (skill3p == "")
                        {
                            skill3p = "Shadow Step";
                            Console.WriteLine($"{namep} learned {skill3p}");
                        }
                        break;
                    default:
                        break;
                }
                reached++;
            }

            if (levelp >= 7 && reached == 1)
            {
                switch (classtypep)
                {
                    case "Knight":
                        if (spell2p == "")
                        {
                            spell2p = "Nullify";
                            Console.WriteLine($"{namep} learned {spell2p}");
                        }
                        break;
                    case "Mage":
                        if (spell3p == "")
                        {
                            spell3p = "Healing Light";
                            Console.WriteLine($"{namep} learned {spell3p}");
                        }
                        break;
                    case "Assassin":
                        if (spell2p == "")
                        {
                            spell2p = "Life Steal";
                            Console.WriteLine($"{namep} learned {spell2p}");
                        }
                        if (skill4p == "")
                        {
                            skill4p = "Phantom Strike";
                            Console.WriteLine($"{namep} learned {skill4p}");
                        }
                        break;
                    default:
                        break;
                }
                reached++;
            }

            if (levelp >= 10 && reached == 2)
            {
                switch (classtypep)
                {
                    case "Knight":
                        if (spell3p == "")
                        {
                            spell3p = "Aegis";
                            Console.WriteLine($"{namep} learned {spell3p}");
                        }
                        if (skill4p == "")
                        {
                            skill4p = "Ultima";
                            Console.WriteLine($"{namep} learned {skill4p}");
                        }
                        break;
                    case "Mage":
                        if (spell4p == "")
                        {
                            spell4p = "Lightning Strike";
                            Console.WriteLine($"{namep} learned {spell4p}");
                        }
                        break;
                    case "Assassin":
                        if (skill4p == "")
                        {
                            skill4p = "Piercing Barrage";
                            Console.WriteLine($"{namep} learned {skill4p}");
                        }
                        break;
                    default:
                        break;
                }
                reached++;
            }

            if (levelp >= 15 && reached == 3)
            {
                switch (classtypep)
                {
                    case "Mage":
                        if (spell2p == "")
                        {
                            spell2p = "Frost Armor";
                            Console.WriteLine($"{namep}'s Ice Shield was upgraded to {spell2p}");
                        }
                        if (spell4p == "")
                        {
                            spell4p = "Thunder's Wrath";
                            Console.WriteLine($"{namep}'s Lightning Strike was upgraded to {spell4p}");
                        }
                        break;
                    default:
                        break;
                }
                reached++;
            }
        }

        levelup = false;
        Console.WriteLine($"Level {levelp}: {expp}/{levelupval}");
    }

    //Player skills, spells and passive
    public void PassiveEffectsP()
    {
        double percenthpadd;

        switch (passivep)
        {
            case "Tough":
                if (hitPtsp <= maxhitPtsp / 2)
                {
                    percenthpadd = maxhitPtsp;
                    percenthpadd *= 0.1;

                    hitPtsp += Convert.ToInt32(percenthpadd);
                }
                break;
            case "Gnosis":
                if (numberGen.Next(0, 101) >= 50)
                {
                    manap += 200;
                    burnp = 0;
                    stunp = 0;
                    poisonp = 0;
                }
                break;
            case "Nimble Grace":
                if (criticalhit)
                {
                    //Critical attacks grant extra turns
                }
                break;
        }

        Console.ReadLine();
        BattleGUI();
        PassiveEffectsP();
    }

    public void Skills()
    {
        damageskillp = 0;

        switch (pickp)
        {
            case 1:
                switch (skill1p)
                {
                    case "Arc Slash":
                        if (staminap >= 50)
                        {
                            staminap -= 50;
                            damageskillp += numberGen.Next(50, 76) + phyAtkp - armore;
                            damageskillp = (damageskillp <= 0) ? 0 : damageskillp;
                            hitPtse -= damageskillp;
                            Console.WriteLine($"{namep} used {skill1p}");
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill1p} dealt {damageskillp} damage");
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                    case "Cudgel Strike":
                        if (staminap >= 5)
                        {
                            staminap -= 5;
                            damageskillp += numberGen.Next(20, 31) + phyAtkp - armore;
                            damageskillp = (damageskillp <= 0) ? 0 :
                            hitPtse -= damageskillp;
                            Console.WriteLine($"{namep} used {skill1p}");
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill1p} dealt {damageskillp} damage");
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                    case "Dual Cut":
                        if (staminap >= 20)
                        {
                            staminap -= 20;
                            Console.WriteLine($"{namep} used {skill1p}");
                            for (int i = 0; i < 2; i++)
                            {
                                damageskillp += numberGen.Next(10, 21) + phyAtkp - armore;
                                damageskillp = (damageskillp < 0) ? 0 : damageskillp;
                                hitPtse -= damageskillp;
                                Thread.Sleep(1000);
                                Console.WriteLine($"{skill1p} dealt {damageskillp} damage");
                                totalDmg += damageskillp;
                            }
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill1p} dealt a total of {totalDmg} damage");
                            totalDmg = 0;
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                }
                break;
            case 2:
                switch (skill2p)
                {
                    case "Fortify":
                        spadd = Convert.ToInt32(maxStaminap * 0.2);
                        if (staminap > maxStaminap - spadd) spadd = maxStaminap - staminap;
                        else if (staminap < maxStaminap - spadd) Convert.ToInt32(maxStaminap * 0.2);
                        else if (staminap == maxStaminap) spadd = 0;

                        Console.WriteLine($"{namep} used {skill2p}");
                        if (staminap < maxStaminap) { Thread.Sleep(1000); Console.WriteLine($"{namep} restored {spadd} stamina"); }
                        staminap += spadd;
                        temparmor += Convert.ToInt32(armorp * 0.1);
                        armorp += Convert.ToInt32(armorp * 0.1);
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namep}'s physical defense increased");
                        picked = true;
                        break;
                    case "Rest":
                        if (staminap >= maxStaminap && manap >= maxManap)
                        {
                            Console.WriteLine($"{namep}'s mana and stamina are already full");
                            pickval = 1;
                            combatcheck = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            spadd = Convert.ToInt32(maxStaminap * 0.1);
                            if (staminap > maxStaminap - spadd) spadd = maxStaminap - staminap;
                            else if (staminap < maxStaminap - spadd) Convert.ToInt32(maxStaminap * 0.1);
                            else if (staminap == maxStaminap) spadd = 0;

                            mpadd = Convert.ToInt32(maxManap * 0.4);
                            if (manap > maxManap - mpadd) mpadd = maxManap - manap;
                            else if (manap < maxManap - mpadd) Convert.ToInt32(maxManap * 0.4);
                            else if (manap == maxManap) mpadd = 0;

                            manap += mpadd;
                            staminap += spadd;

                            Console.WriteLine($"{namep} used {skill2p}");
                            Thread.Sleep(1000);
                            if (spadd != 0)
                            {
                                Console.WriteLine($"{namep} restored {spadd} stamina");
                                Thread.Sleep(1000);
                            }
                            if (mpadd != 0) Console.WriteLine($"{namep} restored {mpadd} mana");
                            picked = true;
                        }
                        break;
                    case "Focus":
                        spadd = Convert.ToInt32(maxStaminap * 0.6);
                        if (staminap > maxStaminap - spadd) spadd = maxStaminap - staminap;
                        else if (staminap < maxStaminap - spadd) Convert.ToInt32(maxStaminap * 0.6);
                        else if (staminap == maxStaminap) spadd = 0;

                        if (staminap > maxStaminap)
                        {
                            staminap += spadd;
                            Console.WriteLine($"{namep} used {skill2p}");
                            Thread.Sleep(1000);
                            Console.WriteLine($"{namep} restored {spadd} stamina");
                            Thread.Sleep(1000);
                            Console.WriteLine($"{namep} restored {mpadd} mana");
                            picked = true;
                        }
                        else if (staminap == maxStaminap)
                        {
                            Console.WriteLine($"{namep}'s stamina is already full");
                            Console.ReadKey(true);
                        }
                        break;
                }
                break;
            case 3:
                switch (skill3p)
                {
                    case "Shield Bash":
                        if (staminap >= 145)
                        {
                            staminap -= 145;
                            damageskillp += numberGen.Next(50, 66) + phyAtkp - armore;
                            Console.WriteLine($"{namep} used {skill3p}");
                            Thread.Sleep(1000);
                            hitPtse -= damageskillp;
                            Console.WriteLine($"{skill1p} dealt {damageskillp} damage");
                            if (numberGen.Next(0, 101) <= 30) { Thread.Sleep(1000); Console.WriteLine($"{skill1p} stunned {namee} for a one turn"); stune++; }
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                    case "Shadow Step":
                        if (staminap >= 125)
                        {
                            staminap -= 125;
                            damageskillp = numberGen.Next(120, 151) + phyAtkp - armore;
                            Console.WriteLine($"{namep} used {skill3p}");
                            Thread.Sleep(1000);
                            hitPtse -= damageskillp;
                            Console.WriteLine($"{skill1p} dealt {damageskillp} damage");
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                }
                break;
            case 4:
                switch (skill4p)
                {
                    case "Ultima":
                        if (staminap >= maxStaminap)
                        {
                            staminae -= maxStaminap;
                            damageskillp = (int)maxhitPtsp;
                            Console.WriteLine($"{namep} used {skill3p}");
                            Thread.Sleep(1000);
                            hitPtse -= damageskillp;
                            Console.WriteLine($"{skill1p} dealt {damageskillp} damage");
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                    case "Piercing Barrage":
                        long total = 0;
                        if (staminap >= 750)
                        {
                            staminap -= 750;
                            Console.WriteLine($"{namep} used {skill4p}");
                            for (int i = 0; i < 5; i++)
                            {
                                damageskillp = numberGen.Next(200, 251) + phyAtkp - armore;
                                Thread.Sleep(1000);
                                hitPtse -= damageskillp;
                                Console.WriteLine($"{skill4p} dealt {damageskillp} damage");
                                total += damageskillp;
                            }
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill4p} dealt a total of {total} damage");
                            picked = true;
                        }
                        else
                        {
                            Console.WriteLine($"{namep} does not have enough stamina");
                            Console.ReadKey();
                        }
                        break;
                }
                break;
            default:
                break;
        }
    }

    public void Spells()
    {
        damagespellp = 0;

        switch (pickp)
        {
            case 5:
                switch (spell1p)
                {
                    case "Enhance":
                        manap -= 50;
                        tempatk += Convert.ToInt32(phyAtkp * 0.2);
                        phyAtkp += Convert.ToInt32(phyAtkp * 0.2);
                        temparmor += Convert.ToInt32(armorp * 0.1);
                        armorp += Convert.ToInt32(armorp * 0.1);
                        Console.WriteLine($"{namep} used {spell1p}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namep}'s physical damage and armor increased");
                        picked = true;
                        break;
                    case "Fireball":
                        manap -= 100;
                        damagespellp = magAtkp + numberGen.Next(20, 51) - magResp;
                        Console.WriteLine($"{namep} used {spell1p}");
                        Thread.Sleep(1000);
                        hitPtse -= damagespellp;
                        Console.WriteLine($"{spell1p} dealt {damagespellp} damage");
                        if (numberGen.Next(1, 101) < 30) { burne++; Thread.Sleep(1000); Console.WriteLine($"{namee} was burned"); }
                        picked = true;
                        break;
                    case "Dark Veil":
                        manap -= 75;
                        Console.WriteLine($"{namep} used {spell1p}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell1p} surrounded the area with darkness");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell1p} blinded {namee}");
                        break;
                    default:
                        break;
                }
                break;
        }
    }

    //Enemy
    public void GetEnemy()
    {
        switch (eventValue)
        {
            case "a1":
                namee = enemylist[0];
                expadd = 100;
                levele = 2;
                classtypee = "Monster";
                hitPtse = 444;
                maxhitPtse = hitPtse;
                staminae = 77;
                maxStaminae = staminae;
                manae = 0;
                maxManae = manae;
                phyAtke = 330;
                magAtke = 0;
                armore = 221;
                magRese = 223;
                speede = 25;
                skill1e = "Tackle";
                skill2e = "Acid Spray"; //Acid Spray
                skill3e = "";
                skill4e = "";
                spell1e = "";
                spell2e = "";
                spell3e = "";
                spell4e = "";
                passivee = "Slimy";
                break;
            case "a2":
                namee = enemylist[1];
                expadd = 300;
                levele = 4;
                classtypee = "Knight";
                hitPtse = 760;
                maxhitPtse = hitPtse;
                staminae = 188;
                maxStaminae = staminae;
                manae = 155;
                maxManae = manae;
                phyAtke = 500;
                magAtke = 0;
                armore = 357;
                magRese = 299;
                speede = 177;
                skill1e = "Thrust";
                skill2e = "En Guarde";
                skill3e = "Galloping Charge";
                skill4e = "";
                spell1e = "Iron Skin";
                spell2e = "Royal Blessing";
                spell3e = "";
                spell4e = "";
                passivee = "Valor";
                break;
            case "a3":
                namee = enemylist[2];
                expadd = 400;
                levele = 7;
                classtypee = "Monster";
                hitPtse = 1080;
                maxhitPtse = hitPtse;
                staminae = 677;
                maxStaminae = staminae;
                manae = 0;
                maxManae = manae;
                phyAtke = 544;
                magAtke = 0;
                armore = 588;
                magRese = 133;
                speede = 10;
                skill1e = "Brutal Strike";
                skill2e = "War Cry";
                skill3e = "Crushing Blow";
                skill4e = "";
                spell1e = "";
                spell2e = "";
                spell3e = "";
                spell4e = "";
                passivee = "Brute";
                break;
            case "a4":
                namee = enemylist[3];
                expadd = 500;
                levele = 10;
                classtypee = "Monster";
                hitPtse = 2333;
                maxhitPtse = hitPtse;
                staminae = 999;
                maxStaminae = staminae;
                manae = 0;
                maxManae = manae;
                phyAtke = 560;
                magAtke = 0;
                armore = 588;
                magRese = 133;
                speede = 67;
                skill1e = "Big Stomp";
                skill2e = "Bloodthirsty";
                skill3e = "Heavy Slam";
                skill4e = "Frenzied Assault";
                spell1e = "";
                spell2e = "";
                spell3e = "";
                spell4e = "";
                passivee = "Rage";
                break;
            case "a5":
                namee = enemylist[4];
                expadd = 1000;
                levele = 25;
                classtypee = "Beast";
                hitPtse = 5000;
                maxhitPtse = hitPtse;
                staminae = 2000;
                maxStaminae = staminae;
                manae = 3000;
                maxManae = manae;
                phyAtke = 750;
                magAtke = 1119;
                armore = 790;
                magRese = 455;
                speede = 340;
                skill1e = "Talon Strike";
                skill2e = "Loud Screech";
                skill3e = "Searing Dive";
                skill4e = "Fiery Hurricane";
                spell1e = "Flamethrower";
                spell2e = "Burning Aura";
                spell3e = "Soothing Ember";
                spell4e = "Solar Flare";
                passivee = "Rebirth";
                break;
            case "b1":
                namee = enemylist[5];
                expadd = 300;
                levele = 5;
                classtypee = "Assasin";
                hitPtse = 355;
                maxhitPtse = hitPtse;
                staminae = 244;
                maxStaminae = staminae;
                manae = 0;
                maxManae = manae;
                phyAtke = 450;
                magAtke = 0;
                armore = 122;
                magRese = 0;
                speede = 288;
                skill1e = "Stab";
                skill2e = "Pickpocket";
                skill3e = "Poison Edge";
                skill4e = "Slashing Strike";
                spell1e = "";
                spell2e = "";
                spell3e = "";
                spell4e = "";
                passivee = "Greed";
                break;
            case "b2":
                namee = enemylist[6];
                expadd = 500;
                levele = 8;
                classtypee = "Assasin";
                hitPtse = 677;
                maxhitPtse = hitPtse;
                staminae = 500;
                maxStaminae = staminae;
                manae = 346;
                maxManae = manae;
                phyAtke = 750;
                magAtke = 149;
                armore = 377;
                magRese = 100;
                speede = 555;
                skill1e = "Swift Strike";
                skill2e = "Deep Focus";
                skill3e = "Wide Cleave";
                skill4e = "Sonic Barrage";
                spell1e = "Foresight";
                spell2e = "Reflex";
                spell3e = "";
                spell4e = "";
                passivee = "Quick";
                break;
            case "b3":
                namee = enemylist[7];
                expadd = 1000;
                levele = 10;
                classtypee = "Mage";
                hitPtse = 677;
                maxhitPtse = hitPtse;
                staminae = 500;
                maxStaminae = staminae;
                manae = 588;
                maxManae = manae;
                phyAtke = 500;
                magAtke = 899;
                armore = 377;
                magRese = 100;
                speede = 555;
                skill1e = "Pommel Strike";
                skill2e = "Restore";
                skill3e = "";
                skill4e = "";
                spell1e = "Dark Energy";
                spell2e = "Binding Chain";
                spell3e = "Soul Siphon";
                spell4e = "Blades of Ruin";
                passivee = "Perceptive";
                break;
            case "b4":
                namee = enemylist[8];
                expadd = 2500;
                levele = 15;
                classtypee = "Knight";
                hitPtse = 2900;
                maxhitPtse = hitPtse;
                staminae = 1200;
                maxStaminae = staminae;
                manae = 588;
                maxManae = manae;
                phyAtke = 1500;
                magAtke = 0;
                armore = 555;
                magRese = 477;
                speede = 55;
                skill1e = "Hard Hit";
                skill2e = "Resilience";
                skill3e = "Counter Strike";
                skill4e = "Buster Blade";
                spell1e = "Protection";
                spell2e = "";
                spell3e = "";
                spell4e = "";
                passivee = "Reinforced";
                break;
            case "b5":
                namee = enemylist[9];
                expadd = 0;
                levele = 1;
                classtypee = "Mage";
                hitPtse = 2900;
                maxhitPtse = hitPtse;
                staminae = 1200;
                maxStaminae = staminae;
                manae = 588;
                maxManae = manae;
                phyAtke = 0;
                magAtke = 0;
                armore = 555;
                magRese = 477;
                speede = 55;
                skill1e = "";
                skill2e = "";
                skill3e = "";
                skill4e = "";
                spell1e = "Blood Ritual";
                spell2e = "";
                spell3e = "";
                spell4e = "";
                passivee = "Sacrificial Lamb";
                break;
            default:
                break;
        }
    }

    //Enemy skills, spells, and passives
    public void EnemySkills()
    {
        damageskille = 0;
        Accuracy();
        switch (pickp)
        {
            case 1:
                switch (skill1e)
                {
                    case "Darkness Strike":
                        staminae -= 10;
                        damageskille += numberGen.Next(450, 500) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Tackle":
                        staminae -= 3;
                        damageskille += numberGen.Next(65, 81) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        if (numberGen.Next(0, 101) <= moveAccuracy) { hitPtsp -= damageskille; Console.WriteLine($"{skill1e} dealt {damageskille} damage"); }
                        else Console.WriteLine($"{namee}'s attack missed");
                        break;
                    case "Thrust":
                        staminae -= 15;
                        damageskille += numberGen.Next(70, 190) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Brutal Strike":
                        staminae -= 55;
                        damageskille += numberGen.Next(201, 251) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Big Stomp":
                        staminae -= 77;
                        damageskille += numberGen.Next(450, 501) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Talon Strike":
                        staminae -= 150;
                        damageskille += numberGen.Next(455, 700) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Stab":
                        staminae -= 25;
                        damageskille += numberGen.Next(55, 100) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Swift Strike":
                        staminae -= 50;
                        damageskille += numberGen.Next(250, 401) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Pommel Strike":
                        staminae -= 10;
                        damageskille += numberGen.Next(100, 121) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    case "Hard Hit":
                        staminae -= 122;
                        damageskille += numberGen.Next(500, 851) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill1e} dealt {damageskille} damage");
                        break;
                    default:
                        break;
                }
                break;

            case 2:
                switch (skill2e)
                {
                    case "Acid Spray":
                        staminae -= 30;
                        damageskille += numberGen.Next(100, 151) + phyAtke;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        temparmor += -25;
                        armorp += -25;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill2e} dealt {damageskille} damage");
                        break;
                    case "En Guarde":
                        spadd = 50;
                        if (staminae > maxStaminae - spadd) spadd = maxStaminae - staminae;
                        else if (staminae < maxStaminae - spadd) spadd = 50;
                        else if (staminae == maxStaminae) spadd = 0;

                        if (staminae >= maxStaminae - spadd || staminae < maxStaminae - spadd)
                        {
                            Console.WriteLine($"{namee} used {skill2e}");
                            if (staminae > maxStaminae)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine($"{namee} restored {spadd} stamina");
                                staminae += spadd;
                            }

                            Thread.Sleep(1000);
                            Console.WriteLine($"{namee} raised its defenses");
                            armore += 25;
                        }
                        break;
                    case "War Cry":
                        Console.WriteLine($"{namee} used {skill2e}");
                        phyAtke += 75;
                        Console.WriteLine($"{skill2e} increaded {namee}'s physical attack");
                        break;
                    case "Bloodthirsty":
                        Console.WriteLine($"{namee} used {skill2e}");
                        Thread.Sleep(1000);
                        phyAtke += 200;
                        hitPtse += -500;
                        Console.WriteLine($"{namee} sacrificed its health to greatly increase its physical attack");
                        break;
                    case "Loud Screech":
                        int stn = numberGen.Next(0, 101);
                        staminae -= 350;
                        Console.WriteLine($"{namee} used {skill2e}");
                        if (stn > 30)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"{namee}'s {skill2e} has stunned {namep} for the next 2 turns");
                            stunp += 2;
                        }
                        Thread.Sleep(1000);
                        temparmor += -50;
                        armorp -= 50;
                        Console.WriteLine($"{skill2e} reduced {namep}'s armor");
                        break;
                    case "Pickpocket":
                        staminae -= 75;
                        int chance = numberGen.Next(1, 101);
                        int lost = numberGen.Next(1, 9);
                        damageskille += numberGen.Next(200, 251) + phyAtke;
                        Console.WriteLine($"{namee} used {skill2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill2e} dealt {damageskille} damage");

                        if (chance < 30)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"{namee} stole {namep}'s {inventory[0]}");
                            inventory[0] = "";
                        }
                        break;
                    case "Deep Focus":
                        spadd = 200;
                        if (staminae > maxStaminae - spadd) spadd = maxStaminae - staminae;
                        else if (staminae < maxStaminae - spadd) spadd = 50;
                        else if (staminae == maxStaminae) spadd = 0;
                        Console.WriteLine($"{namee} used {skill2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namee} restored {spadd} stamina");
                        break;
                    case "Restore":
                        mpadd = 300;
                        if (manae > maxManae - mpadd) mpadd = maxManae - manae;
                        else if (manae < maxManae - mpadd) mpadd = 300;
                        else if (manae == maxManae) mpadd = 0;
                        Console.WriteLine($"{namee} used {skill2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namee} restored {spadd} stamina");
                        break;
                    case "Resilience":
                        spadd = 500;
                        if (staminae > maxStaminae - spadd) spadd = maxStaminae - staminae;
                        else if (staminae < maxStaminae - spadd) spadd = 500;
                        else if (staminae == maxStaminae) spadd = 0;

                        if (staminae >= maxStaminae - spadd || staminae < maxStaminae - spadd)
                        {
                            Console.WriteLine($"{namee} used {skill2e}");
                            if (staminae > maxStaminae)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine($"{namee} restored {spadd} stamina");
                                staminae += spadd;
                            }

                            Thread.Sleep(1000);
                            Console.WriteLine($"{namee} raised its defenses");
                            armore += 25;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch (skill3e)
                {
                    case "Galloping Charge":
                        staminae -= 90;
                        damageskille += numberGen.Next(500, 751) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");
                        break;
                    case "Crushing Blow":
                        staminae -= 300;
                        damageskille += numberGen.Next(750, 951) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");
                        break;
                    case "Heavy Slam":
                        staminae -= 550;
                        damageskille += numberGen.Next(1000, 1201) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");
                        break;
                    case "Searing Dive":
                        staminae -= 1200;
                        damageskille += numberGen.Next(1500, 3001) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");

                        if (numberGen.Next(0, 101) <= 40)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill3e} burned {namep} for 2 turns");
                            burnp += 2;
                        }
                        break;
                    case "Poison Edge":
                        staminae -= 90;
                        damageskille += numberGen.Next(300, 501) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");

                        if (numberGen.Next(0, 101) <= 40)
                        {
                            Console.WriteLine($"{skill3e} poisoned {namep} for 5 turns");
                            poisonp += 5;
                        }
                        break;
                    case "Wide Cleave":
                        staminae -= 165;
                        damageskille += numberGen.Next(500, 751) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");
                        break;
                    case "Counter Strike":
                        staminae -= 550;
                        damageskille += damageskillp + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill3e} dealt {damageskille} damage");
                        break;
                }
                break;
            case 4:
                switch (skill4e)
                {
                    case "Frenzied Assault":
                        hitPtse -= 750;
                        damageskille += 999 + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill4e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill4e} dealt {damageskille} damage");
                        break;
                    case "Fiery Hurricane":
                        staminae -= 1750;
                        damageskille += numberGen.Next(300, 951) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill4e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill4e} dealt {damageskille} damage");
                        break;
                    case "Slashing Strike":
                        long total = 0;
                        staminae -= 205;
                        Console.WriteLine($"{namee} used {skill4e}");
                        for (int i = 0; i < 3; i++)
                        {
                            damageskille = numberGen.Next(100, 500) + phyAtke - armorp;
                            damageskille = (damageskille <= 0) ? 0 : damageskille;
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill4e} dealt {damageskille} damage");
                            total += damageskille;
                            hitPtsp -= damageskille;
                        }
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill4e} dealt a total of {total} damage");
                        break;
                    case "Sonic Barrage":
                        long total1 = 0;
                        staminae -= 380;
                        Console.WriteLine($"{namee} used {skill4e}");
                        for (int i = 0; i < 5; i++)
                        {
                            damageskille = numberGen.Next(300, 751) + phyAtke - armorp;
                            damageskille = (damageskille <= 0) ? 0 : damageskille;
                            Thread.Sleep(1000);
                            Console.WriteLine($"{skill4e} dealt {damageskille} damage");
                            total1 += damageskille;
                            hitPtsp -= damageskille;
                        }
                        Console.WriteLine($"{skill4e} dealt a total of {total1} damage");
                        break;
                    case "Buster Blade":
                        staminae -= 1000;
                        damageskille += numberGen.Next(1000, 1201) + phyAtke - armorp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damageskille;
                        Console.WriteLine($"{namee} used {skill4e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{skill4e} dealt {damageskille} damage");
                        if (numberGen.Next(0, 100) <= 70)
                        {
                            Console.WriteLine($"{skill4e} stunned {namep} for 3 turns;");
                            stunp += 3;
                        }
                        break;
                }
                break;
        }
    }

    public void EnemySpells()
    {
        damagespelle = 0;
        switch (pickp)
        {
            case 5:
                switch (spell1e)
                {
                    case "Iron Skin":
                        manae -= 50;
                        Console.WriteLine($"{namee} used {spell1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namee}'s armor  increased");
                        armore += 30;
                        break;
                    case "Flamethrower":
                        manae -= 200;
                        damagespelle += numberGen.Next(500, 751) + magAtke - magResp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damagespelle;
                        Console.WriteLine($"{namee} used {spell1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell1e} dealt {damagespelle}");
                        break;
                    case "Foresight":
                        manae -= 30;
                        Console.WriteLine($"{namee} used {spell1e}");
                        break;
                    case "Dark Energy":
                        manae -= 50;
                        damagespelle += numberGen.Next(300, 651) + magAtke - magResp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damagespelle;
                        Console.WriteLine($"{namee} used {spell1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell1e} dealt {damagespelle}");
                        break;
                    case "Protection":
                        manae -= 200;
                        Console.WriteLine($"{namee} used {spell1e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namee}'s armor and magic resistance increased");
                        armore += 250; magRese += 300;
                        break;
                    case "Blood Ritual":
                        manae -= maxManae;
                        Console.WriteLine($"{namee} used {spell1e}");
                        break;
                }
                break;
            case 6:
                switch (spell2e)
                {
                    case "Royal Blessing":
                        manae -= 100;
                        Console.WriteLine($"{namee} used {spell2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namee}'s magic resistance and attack increased");
                        magRese += 50; phyAtke += 50;
                        break;
                    case "Burning Aura":
                        manae -= 560;
                        damagespelle += magAtke - magResp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damagespelle;
                        Console.WriteLine($"{namee} used {spell2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell2e} dealt {damagespelle}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namep} is burned for 5 turns");
                        burnp += 5;
                        break;
                    case "Reflex":
                        Console.WriteLine($"{namee} used {spell2e}");
                        break;
                    case "Binding Chain":
                        manae -= 100;
                        damagespelle += numberGen.Next(450, 751) + magAtke - magResp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damagespelle;
                        Console.WriteLine($"{namee} used {spell2e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell2e} dealt {damagespelle}");
                        break;
                }
                break;
            case 7:
                switch (spell3e)
                {
                    case "Soothing Ember":
                        Console.WriteLine($"{namee} used {spell3e}");
                        Thread.Sleep(1000);
                        spadd = 300;
                        if (staminae > maxStaminae - spadd) spadd = maxStaminae - staminae;
                        else if (staminae < maxStaminae - spadd) spadd = 300;
                        else if (staminae == maxStaminae) spadd = 0;
                        mpadd = 300;
                        if (manae > maxManae - mpadd) mpadd = maxManae - manae;
                        else if (manae < maxManae - mpadd) mpadd = 300;
                        else if (manae == maxManae) mpadd = 0;
                        Console.WriteLine($"{namee} restored its stamina and mana");
                        break;
                    case "Soul Siphon":
                        manae -= 270;
                        damagespelle += numberGen.Next(200, 601) + magAtke - magResp;
                        hitPtsp -= damagespelle;
                        Console.WriteLine($"{namee} used {spell3e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell3e} dealt {damagespelle}");
                        Thread.Sleep(1000);
                        hitPtse += damagespelle;
                        Console.WriteLine($"{namee} restored its health");
                        break;
                }
                break;
            case 8:
                switch (spell4e)
                {
                    case "Solar Flare":
                        manae -= 2000;
                        damagespelle += numberGen.Next(500, 1001) + magAtke - magResp;
                        damageskille = (damageskille <= 0) ? 0 : damageskille;
                        hitPtsp -= damagespelle;
                        Console.WriteLine($"{namee} used {spell4e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell4e} dealt {damagespelle}");
                        break;
                    case "Blades of Ruin":
                        Console.WriteLine($"{namee} used {spell4e}");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{spell4e} greatly increased its physical attack");
                        phyAtke += 500;
                        Thread.Sleep(1000);
                        Console.WriteLine($"{namee}'s {skill1e} transformed into Darkness Strike");
                        skill1e = "Darkness Strike";
                        skill4e = "";
                        break;
                }
                break;
        }
    }

    public void GetCost()
    {
        spcost = 0;
        mpcost = 0;

        switch (pickp)
        {
            case 1:
                switch (skill1e)
                {
                    case "Tackle":
                        spcost = 3;
                        break;
                    case "Thrust":
                        spcost = 15;
                        break;
                    case "Brutal Strike":
                        spcost = 55;
                        break;
                    case "Big Stomp":
                        spcost = 77;
                        break;
                    case "Talon Strike":
                        spcost = 150;
                        break;
                    case "Stab":
                        spcost = 25;
                        break;
                    case "Swift Strike":
                        spcost = 50;
                        break;
                    case "Pommel Strike":
                        spcost = 10;
                        break;
                    case "Hard Hit":
                        spcost = 122;
                        break;
                }
                break;
            case 2:
                switch (skill2e)
                {
                    case "Acid Spray":
                        spcost = 30;
                        break;
                    case "Loud Screech":
                        spcost = 350;
                        break;
                    case "Pickpocket":
                        spcost = 75;
                        break;
                }
                break;
            case 3:
                switch (skill3e)
                {
                    case "Galloping Charge":
                        spcost = 90;
                        break;
                    case "Crushing Blow":
                        spcost = 300;
                        break;
                    case "Heavy Slam":
                        spcost = 550;
                        break;
                    case "Searing Dive":
                        spcost = 1200;
                        break;
                    case "Poison Edge":
                        spcost = 90;
                        break;
                    case "Wide Cleave":
                        spcost = 165;
                        break;
                    case "Counter Strike":
                        spcost = 550;
                        break;
                }
                break;
            case 4:
                switch (skill4e)
                {
                    case "Frenzied Assault":
                        spcost = 750;
                        break;
                    case "Fiery Hurricane":
                        spcost = 1750;
                        break;
                    case "Slashing Strike":
                        spcost = 205;
                        break;
                    case "Sonic Barrage":
                        spcost = 380;
                        break;
                    case "Buster Blade":
                        spcost = 1000;
                        break;
                }
                break;
            case 5:
                switch (spell1e)
                {
                    case "Iron Skin":
                        mpcost = 50;
                        break;
                    case "Flamethrower":
                        mpcost = 500;
                        break;
                    case "Foresight":
                        mpcost = 30;
                        break;
                    case "Dark Energy":
                        mpcost = 50;
                        break;
                    case "Protection":
                        mpcost = 280;
                        break;
                    case "Blood Ritual":
                        mpcost = maxManae;
                        break;
                }
                break;
            case 6:
                switch (spell2e)
                {
                    case "Royal Blessing":
                        mpcost = 100;
                        break;
                    case "Burning Aura":
                        mpcost = 750;
                        break;
                    case "Reflex":
                        mpcost = 100;
                        break;
                    case "Binding Chain":
                        mpcost = 100;
                        break;
                }
                break;
            case 7:
                switch (spell3e)
                {
                    case "Soul Siphon":
                        mpcost = 270;
                        break;
                }
                break;
            case 8:
                switch (spell4e)
                {
                    case "Solar Flare":
                        mpcost = 2000;
                        break;
                }
                break;
        }
    }

    public void Accuracy()
    {
        switch (pickp)
        {
            case 1:
                if (skill1e == "Tackle") moveAccuracy = 95;
                else if (skill1e == "Thrust") moveAccuracy = 90;
                else if (skill1e == "Brutal Strike") moveAccuracy = 80;
                else if (skill1e == "Big Stomp") moveAccuracy = 85;
                else if (skill1e == "Talon Strike") moveAccuracy = 80;
                else if (skill1e == "Stab") moveAccuracy = 90;
                else if (skill1e == "Swift Strike") moveAccuracy = 95;
                else if (skill1e == "Pommel Strike") moveAccuracy = 85;
                else if (skill1e == "Hard Hit") moveAccuracy = 90;
                break;
        }

    }

    public void BattleStart()
    {
        if (speede >= speedp) yourturn = false;
        else yourturn = true;
        win = false; lose = false;
        return;
    }

    public void Turns()
    {

        if (whichTurn % 2 == 0)
        {
            int spadd1, spadd2, mpadd1, mpadd2;
            if (staminae <= maxStaminae - Convert.ToInt32(maxStaminae * 0.075)) spadd1 = Convert.ToInt32(staminae * 0.075);
            else if (staminae >= maxStaminae - Convert.ToInt32(maxStaminae * 0.075)) spadd1 = maxStaminae - staminae;
            else spadd1 = 0;

            if (staminap <= maxStaminap - Convert.ToInt32(maxStaminap * 0.075)) spadd2 = Convert.ToInt32(staminap * 0.075);
            else if (staminap >= maxStaminap - Convert.ToInt32(maxStaminap * 0.075)) spadd2 = maxStaminap - staminap;
            else spadd2 = 0;

            if (manae <= maxManae - Convert.ToInt32(maxStaminae * 0.065)) mpadd1 = Convert.ToInt32(manae * 0.065);
            else if (manae >= maxManae - Convert.ToInt32(maxStaminae * 0.065)) mpadd1 = maxManae - manae;
            else mpadd1 = 0;

            if (manap <= maxManap - Convert.ToInt32(maxStaminap * 0.065)) mpadd2 = Convert.ToInt32(manap * 0.065);
            else if (manap >= maxManap - Convert.ToInt32(maxStaminap * 0.065)) mpadd2 = maxManap - manap;
            else mpadd2 = 0;

            staminae += spadd1;
            staminap += spadd2;
            manae += mpadd1;
            manap += mpadd2;
        }

        whichTurn++;
        if (yourturn) yourturn = false;
        else if (!yourturn) yourturn = true;
    }

    public void RandomAtk()
    {
        int random;

        while (!picked)
        {
            random = numberGen.Next(0, 101);

            switch (namee)
            {
                case "Slime":
                    if (random >= 0 && random <= 45 && skill1e != "") { pickp = 1; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 45 && random <= 100 && skill2e != "") { pickp = 2; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    break;
                case "Royal Knight":
                case "Orc Warrior":
                case "Orc Warlord":
                case "Bandit":
                case "Elven Duelist":
                case "Gate Guardian":
                    if (random >= 0 && random <= 30 && skill1e != "") { pickp = 1; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 30 && random <= 40 && skill3e != "") { pickp = 3; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 40 && random <= 60 && skill4e != "") { pickp = 4; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 60 && random <= 80 && spell1e != "") { pickp = 5; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else if (random > 80 && random <= 100 && spell2e != "") { pickp = 6; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    break;
                case "Phoenix":
                    if (random >= 0 && random <= 25 && skill1e != "") { pickp = 1; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 25 && random <= 30 && skill2e != "") { pickp = 2; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 30 && random <= 40 && skill3e != "") { pickp = 3; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 40 && random <= 50 && skill4e != "") { pickp = 4; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 50 && random <= 75 && spell1e != "") { pickp = 5; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else if (random > 75 && random <= 90 && spell2e != "") { pickp = 6; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else if (random > 90 && random <= 100 && spell4e != "") { pickp = 8; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else { pickp = 7; EnemySpells(); picked = true; }
                    break;
                case "Warlock":
                    if (random >= 0 && random <= 30 && skill1e != "") { pickp = 1; GetCost(); Accuracy(); if (staminae >= spcost) { EnemySkills(); picked = true; } }
                    else if (random > 30 && random <= 40 && spell3e != "") { pickp = 7; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else if (random > 40 && random <= 60 && spell4e != "") { pickp = 8; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else if (random > 60 && random <= 80 && spell1e != "") { pickp = 5; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    else if (random > 80 && random <= 100 && spell2e != "") { pickp = 6; GetCost(); Accuracy(); if (manae >= mpcost) { EnemySpells(); picked = true; } }
                    break;
            }

            /*
            if (random >= 0 && random <= 10 && spell2e != "") { pickp = 2; EnemySkills(); picked = true; }
            else if (random > 10 && random <= 20 && skill2e != "") { pickp = 2; EnemySkills(); picked = true; }
            else if (random > 20 && random <= 40 && skill2e != "") { pickp = 2; EnemySkills(); picked = true; }
            else if (random > 40 && random <= 60 && skill2e != "") { pickp = 2; EnemySkills(); picked = true; }
            else if (random > 60 && random <= 80 && skill2e != "" && staminae >= spcost) { pickp = 2; EnemySkills(); picked = true; }
            else if (random > 80 && random <= 100 && spell2e != "") { pickp = 2; EnemySkills(); picked = true; } 
            */
        }
        picked = false;
    }

    public void PassiveEffectE()
    {
        //
    }

    public void StatusCheck()
    {
        if (poisonp > 0)
        {
            Console.WriteLine($"{namep} is hurt by poison");
            Thread.Sleep(1000);
            double psndmg = maxhitPtsp * (Convert.ToDouble(poisonp) * 0.01);
            hitPtsp -= Convert.ToInt32(psndmg);
            poisonp--;
        }
        if (burnp > 0)
        {
            Console.WriteLine($"{namep} is hurt by burn");
            Thread.Sleep(1000);
            double psndmg = maxhitPtsp * 0.015;
            hitPtsp -= Convert.ToInt32(psndmg);
            burnp--;
        }
    }

    public void Events()
    {
        switch (eventValue)
        {
            case "a1":
                eventValue = "a2";
                break;
            case "a2":
                eventValue = "a3";
                break;
            case "a3":
                eventValue = "a4";
                break;
            case "a4":
                eventValue = "a5";
                break;
            case "a5":
                eventValue = "b2";
                break;
            case "b1":
                eventValue = "b2";
                break;
            case "b2":
                eventValue = "b3";
                break;
            case "b3":
                eventValue = "b4";
                break;
            case "b4":
                eventValue = "b5";
                break;
            case "b5":
                eventValue = "b6";
                break;
        }
        GetEnemy();
    }

    public virtual void BattleGUI()
    {
        //
    }

    public virtual void NamePick()
    {
        //
    }

    public virtual void ClassPick()
    {
        //
    }
}