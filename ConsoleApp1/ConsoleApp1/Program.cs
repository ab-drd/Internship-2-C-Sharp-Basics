using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var playlist = new Dictionary<int, string>();
            var caseSwitch = -1; var counter = 1;
            Console.WriteLine("=================================================");
            while (caseSwitch != 0)
            {
                Console.WriteLine(counter + ". akcija\n");
                Console.WriteLine("Odaberite akciju:\n1 - Ispis cijele liste\n2 - Ispis imena pjesme unosom pripadajuceg rednog broja" +
                "\n3 - Ispis rednog broja pjesme unosom pripadajuceg imena\n4 - Unos nove pjesme\n5 - Brisanje pjesme po rednom broju" +
                "\n6 - Brisanje pjesme po imenu\n7 - Brisanje cijele liste\n8 - Uredivanje imena pjesme" +
                "\n9 - Uredivanje rednog broja pjesme\n10 - Shuffle\n0 - izlaz iz aplikacije\n");
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        PrintPlaylist_All(playlist);
                        break;
                    case 2:
                        PrintPlaylist_Key(playlist);
                        break;
                    case 3:
                        PrintPlaylist_Value(playlist);
                        break;
                    case 4:
                        AddSong(playlist);
                        break;
                    case 5:
                        RemoveSong_Key(playlist);
                        break;
                    case 6:
                        RemoveSong_Value(playlist);
                        break;
                    case 7:
                        RemoveSong_All(playlist);
                        break;
                    case 8:
                        EditSongName(playlist);
                        break;
                    case 9:
                        EditSongNumber(playlist);
                        break;
                    case 10:
                        playlist = ShufflePlaylist(playlist);
                        break;
                    default:
                        Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                        break;
                }
                Console.WriteLine("\n=================================================\n");
                counter++;
            }

        }

        static void PrintPlaylist_All(Dictionary<int, string> givenPlaylist)
        {
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                Console.WriteLine("ISPIS PLAYLISTE:\n");
                foreach (KeyValuePair<int, string> kvp in givenPlaylist)
                {
                    Console.WriteLine("{0}. - {1}", kvp.Key, kvp.Value);
                }
            }
        }

        static void PrintPlaylist_Key(Dictionary<int, string> givenPlaylist)
        {
            var indexOfPrint = 0; var shouldIStop = -1; var choice = 0; var satisfied = -1;

            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                Console.WriteLine("Unesite redni broj pjesme koju zelite ispisati:");
                while (shouldIStop != 0)
                {
                    indexOfPrint = int.Parse(Console.ReadLine());
                    if (!givenPlaylist.ContainsKey(indexOfPrint))
                    {
                        Console.WriteLine("Nije pronadjena pjesma rednog broja {0}", indexOfPrint);
                        Console.WriteLine("Zelite li ponovno unijeti redni broj pjesme koju zelite ispisati?\n1 - da\n2 - ne, vrati me na izbornik");
                        while (satisfied != 0)
                        {
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Unesite redni broj pjesme koju zelite ispisati:");
                                    satisfied = 0;
                                    break;
                                case 2:
                                    shouldIStop = 0;
                                    satisfied = 0;
                                    break;
                                default:
                                    Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                    break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Na {0}. se nalazi pjesma {1}", indexOfPrint, givenPlaylist[indexOfPrint]);
                        shouldIStop = 0;
                    }
                }
            }
        }

        static void PrintPlaylist_Value(Dictionary<int, string> givenPlaylist)
        {
            var nameOfPrint = ""; var shouldIStop = -1; var choice = 0; var satisfied = -1;

            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                Console.WriteLine("Unesite ime pjesme ciji redni broj zelite ispisati:");
                while (shouldIStop != 0)
                {
                    nameOfPrint = Console.ReadLine();
                    if (!givenPlaylist.ContainsValue(nameOfPrint))
                    {
                        Console.WriteLine("Nije pronadjena pjesma {0}", nameOfPrint);
                        Console.WriteLine("Zelite li ponovno unijeti ime pjesme koju zelite ispisati?\n1 - da\n2 - ne, vrati me na izbornik");
                        while (satisfied != 0)
                        {
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    satisfied = 0;
                                    Console.WriteLine("Unesite ime pjesme ciji redni broj zelite ispisati:");
                                    break;
                                case 2:
                                    satisfied = 0;
                                    shouldIStop = 0;
                                    break;
                                default:
                                    break;
                            }
                        }

                    }
                    else
                    {
                        foreach (KeyValuePair<int, string> kvp in givenPlaylist)
                        {
                            if (kvp.Value == nameOfPrint)
                            {
                                Console.WriteLine("Pjesma {0} se nalazi na broju {1}.", kvp.Value, kvp.Key);
                                break;
                            }
                        }
                        shouldIStop = 0;
                    }
                }
            }
        }

        static void AddSong(Dictionary<int, string> givenPlaylist)
        {
            var newSong = ""; var shouldIStop = -1;
            Console.WriteLine("Unesite ime pjesme koju zelite unijeti u playlistu:");
            while (shouldIStop != 0)
            {
                var choice = 0;
                newSong = Console.ReadLine();
                Console.WriteLine("Jeste li sigurni da zelite unijeti pjesmu '{0}' u playlistu?\n1 - da, unesi pjesmu" +
                    "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", newSong);
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if (!givenPlaylist.ContainsValue(newSong))
                        {
                            givenPlaylist[givenPlaylist.Count + 1] = newSong;
                            Console.WriteLine("Pjesma '{0}' uspjesno unesena u playlistu na redni broj {1}", newSong, givenPlaylist.Count);
                        }
                        else
                        {
                            Console.WriteLine("Pjesma '{0}' se vec nalazi u playlisti", newSong);
                        }
                        shouldIStop = 0;
                        break;
                    case 2:
                        Console.WriteLine("Unesite ime pjesme koju zelite unijeti u playlistu:");
                        break;
                    case 0:
                        shouldIStop = 0;
                        Console.WriteLine("Povratak na izbornik");
                        break;
                }
            }
        }

        static void RemoveSong_Key(Dictionary<int, string> givenPlaylist)
        {
            var indexRemove = 0; var shouldIStop = -1; var satisfied = -1; var choice = 0; var choose = 0;
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                Console.WriteLine("Unesite redni broj pjesme koju zelite izbrisati:");
                while (shouldIStop != 0)
                {
                    indexRemove = int.Parse(Console.ReadLine());
                    if (!givenPlaylist.ContainsKey(indexRemove))
                    {
                        Console.WriteLine("Nije pronadjena pjesma na rednom broju {0}", indexRemove);
                        Console.WriteLine("Zelite li ponovno unijeti redni broj pjesme koju zelite izbrisati?\n1 - da\n2 - ne, vrati me na izbornik");
                        while (satisfied != 0)
                        {
                            choose = int.Parse(Console.ReadLine());
                            switch (choose)
                            {
                                case 2:
                                    shouldIStop = 0;
                                    satisfied = 0;
                                    break;
                                case 1:
                                    Console.WriteLine("Unesite redni broj pjesme koju zelite izbrisati:");
                                    satisfied = 0;
                                    break;
                                default:
                                    Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jeste li sigurni da zelite izbrisati pjesmu na rednom broju {0} u playlisti?\n1 - da, izbrisi pjesmu" +
                        "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", indexRemove);
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                var numberOfSongs = givenPlaylist.Count;
                                var deletedSong = givenPlaylist[indexRemove];
                                givenPlaylist.Remove(indexRemove);
                                for (var i = indexRemove; i < numberOfSongs; i++)
                                {
                                    givenPlaylist[i] = givenPlaylist[i + 1];
                                    givenPlaylist.Remove(i + 1);
                                }
                                Console.WriteLine("Pjesma '{0}' na rednom broju {1} uspjesno izbrisana.", deletedSong, indexRemove);
                                shouldIStop = 0;
                                break;
                            case 2:
                                Console.WriteLine("Unesite redni broj pjesme koju zelite izbrisati:");
                                break;
                            case 0:
                                shouldIStop = 0;
                                Console.WriteLine("Povratak na izbornik");
                                break;
                        }
                    }
                }
            }
        }

        static void RemoveSong_Value(Dictionary<int, string> givenPlaylist)
        {
            var songRemove = ""; var shouldIStop = -1; var satisfied = -1;
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                Console.WriteLine("Unesite ime pjesme koju zelite izbrisati:");
                while (shouldIStop != 0)
                {
                    var choice = 0; var shouldIDelete = 0;
                    songRemove = Console.ReadLine();
                    if (!givenPlaylist.ContainsValue(songRemove))
                    {
                        Console.WriteLine("Nije pronadjena pjesma imena '{0}'", songRemove);
                        Console.WriteLine("Zelite li ponovno unijeti ime pjesme koju zelite izbrisati?\n1 - da\n2 - ne, vrati me na izbornik");
                        shouldIDelete = int.Parse(Console.ReadLine());
                        while (satisfied != 0)
                        {
                            switch (shouldIDelete)
                            {
                                case 2:
                                    shouldIStop = 0;
                                    satisfied = 0;
                                    break;
                                case 1:
                                    satisfied = 0;
                                    break;
                                default:
                                    Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jeste li sigurni da zelite izbrisati pjesmu imena '{0}' iz playliste?\n1 - da, izbrisi pjesmu" +
                        "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", songRemove);
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                var index = 0;
                                var numberOfSongs = givenPlaylist.Count;
                                foreach (KeyValuePair<int, string> kvp in givenPlaylist)
                                {
                                    if (kvp.Value == songRemove)
                                    {
                                        index = kvp.Key;
                                        break;
                                    }
                                }
                                givenPlaylist.Remove(index);
                                for (var i = index; i < numberOfSongs; i++)
                                {
                                    givenPlaylist[i] = givenPlaylist[i + 1];
                                    givenPlaylist.Remove(i + 1);
                                }
                                Console.WriteLine("Pjesma '{0}' na rednom broju {1} uspjesno izbrisana.", songRemove, index);
                                shouldIStop = 0;
                                break;
                            case 2:
                                Console.WriteLine("Unesite ime pjesme koju zelite izbrisati:");
                                break;
                            case 0:
                                shouldIStop = 0;
                                Console.WriteLine("Povratak na izbornik");
                                break;
                        }
                    }
                }
            }
        }

        static void RemoveSong_All(Dictionary<int, string> givenPlaylist)
        {
            var choice = 0; var shouldIStop = -1;
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                Console.WriteLine("Jeste li sigurni da zelite izbrisati cijelu playlistu?\n1 - da\n2 - ne, vrati me na izbornik");
                while (shouldIStop != 0)
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            givenPlaylist.Clear();
                            Console.WriteLine("Cijela playlista uspjesno izbrisana.");
                            shouldIStop = 0;
                            break;
                        case 2:
                            Console.WriteLine("Playlista nije izbrisana.");
                            shouldIStop = 0;
                            break;
                        default:
                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                            break;
                    }
                }
            }
        }

        static void EditSongName(Dictionary<int, string> givenPlaylist)
        {
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                var choice = -1; var shouldIStop = -1;
                Console.WriteLine("Zelite li dohvatiti pjesmu po imenu ili po rednom broju?\n1 - dohvacanje po rednom broju\n2 - dohvacanje po imenu\n0 - povratak na izbornik");
                while (shouldIStop != 0)
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            EditSongName_Index(givenPlaylist);
                            shouldIStop = 0;
                            break;
                        case 2:
                            EditSongName_Song(givenPlaylist);
                            shouldIStop = 0;
                            break;
                        case 0:
                            shouldIStop = 0;
                            Console.WriteLine("Povratak na izbornik.");
                            break;
                        default:
                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                            break;
                    }
                }
            }
        }

        static void EditSongName_Index(Dictionary<int, string> givenPlaylist)
        {
            var stopParameter = -1;
            Console.WriteLine("Unesite redni broj pjesme kojoj zelite mijenjati ime:");
            while (stopParameter != 0)
            { 
                var index = int.Parse(Console.ReadLine());
                if (!givenPlaylist.ContainsKey(index))
                {
                    var satisfied = -1;
                    Console.WriteLine("Nije pronadjena pjesma na rednom broju {0}", index);
                    Console.WriteLine("Zelite li ponovno unijeti redni broj pjesme koju zelite izmijeniti?\n1 - da\n2 - ne, vrati me na izbornik");
                    while (satisfied != 0)
                    {
                        var choose = int.Parse(Console.ReadLine());
                        switch (choose)
                        {
                            case 2:
                                satisfied = 0;
                                break;
                            case 1:
                                Console.WriteLine("Unesite redni broj pjesme kojoj zelite mijenjati ime:");
                                satisfied = 0;
                                break;
                            default:
                                Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Jeste li sigurni da zelite izmijeniti pjesmu na rednom broju {0} u playlisti?\n1 - da, izmijeni ime pjesme" +
                                       "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", index);
                    var choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            var songName = ""; var argument = -1; var oldName = givenPlaylist[index];
                            Console.WriteLine("Na rednom broju {0} trenutno je pjesma '{1}'. Unesite novo ime pjesme:", index, oldName);
                            while (argument != 0)
                            {
                                var runningOutOfNames = -1;
                                songName = Console.ReadLine();
                                Console.WriteLine("Jeste li sigurni da zelite izmijeniti pjesmu na rednom broju {0} u playlisti iz '{1}' u '{2}'?\n1 - da, izmijeni ime pjesme" +
                                       "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", index, oldName, songName);
                                while(runningOutOfNames != 0)
                                {
                                    var option = int.Parse(Console.ReadLine());
                                    switch (option)
                                    {
                                        case 1:
                                            givenPlaylist.Remove(index);
                                            givenPlaylist[index] = songName;
                                            Console.WriteLine("Pjesma '{0}' na rednom broju {1} uspjesno izmijenjena u {2}.", index, oldName, songName);
                                            stopParameter = 0; argument = 0; runningOutOfNames = 0;
                                            break;
                                        case 2:
                                            Console.WriteLine("Unesite redni broj pjesme koju zelite izmijeniti:");
                                            runningOutOfNames = 0; argument = 0;
                                            break;
                                        case 0:
                                            Console.WriteLine("Povratak na izbornik");
                                            stopParameter = 0; argument = 0; runningOutOfNames = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                            break;
                                    }
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Unesite redni broj pjesme koju zelite izmijeniti:");
                            break;
                        case 0:
                            Console.WriteLine("Povratak na izbornik");
                            stopParameter = 0; 
                            break;
                        default:
                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                            break;
                    }
                }
            }
        }

        static void EditSongName_Song(Dictionary<int, string> givenPlaylist)
        {
            var stopParameter = -1;
            Console.WriteLine("Unesite ime pjesme kojoj zelite mijenjati ime:");
            while (stopParameter != 0)
            {
                var songName = Console.ReadLine();
                if (!givenPlaylist.ContainsValue(songName))
                {
                    var satisfied = -1;
                    Console.WriteLine("Nije pronadjena pjesma imena '{0}'", songName);
                    Console.WriteLine("Zelite li ponovno unijeti ime pjesme koju zelite izmijeniti?\n1 - da\n2 - ne, vrati me na izbornik");
                    while (satisfied != 0)
                    {
                        var choose = int.Parse(Console.ReadLine());
                        switch (choose)
                        {
                            case 2:
                                satisfied = 0;
                                break;
                            case 1:
                                Console.WriteLine("Unesite ime pjesme kojoj zelite mijenjati ime:");
                                satisfied = 0;
                                break;
                            default:
                                Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Jeste li sigurni da zelite izmijeniti pjesmu na imena '{0}' u playlisti?\n1 - da, izmijeni ime pjesme" +
                                       "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", songName);
                    var choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            var index = 0; var argument = -1; 
                            foreach (KeyValuePair<int, string> kvp in givenPlaylist)
                            {
                                if (kvp.Value == songName)
                                {
                                    index = kvp.Key;
                                    break;
                                }
                            }
                            var oldName = givenPlaylist[index]; var newName = "";
                            Console.WriteLine("Na pjesma '{0}' nalazi se na rednom broju {1}. Unesite novo ime pjesme:", oldName, index);
                            while (argument != 0)
                            {
                                var runningOutOfNames = -1;
                                newName = Console.ReadLine();
                                Console.WriteLine("Jeste li sigurni da zelite izmijeniti pjesmu na rednom broju {0} u playlisti iz '{1}' u '{2}'?\n1 - da, izmijeni ime pjesme" +
                                       "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", index, oldName, newName);
                                while (runningOutOfNames != 0)
                                {
                                    var option = int.Parse(Console.ReadLine());
                                    switch (option)
                                    {
                                        case 1:
                                            givenPlaylist.Remove(index);
                                            givenPlaylist[index] = newName;
                                            Console.WriteLine("Pjesma '{0}' na rednom broju {1} uspjesno izmijenjena u {2}.", index, oldName, newName);
                                            stopParameter = 0; argument = 0; runningOutOfNames = 0;
                                            break;
                                        case 2:
                                            Console.WriteLine("Unesite ime pjesme koju zelite izmijeniti:");
                                            runningOutOfNames = 0; argument = 0;
                                            break;
                                        case 0:
                                            Console.WriteLine("Povratak na izbornik");
                                            stopParameter = 0; argument = 0; runningOutOfNames = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                            break;
                                    }
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Unesite ime pjesme koju zelite izmijeniti:");
                            break;
                        case 0:
                            Console.WriteLine("Povratak na izbornik");
                            stopParameter = 0;
                            break;
                        default:
                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                            break;
                    }
                }
            }
        }

        static void EditSongNumber(Dictionary<int, string> givenPlaylist)
        {
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                var stopParameter = -1;
                Console.WriteLine("Unesite redni broj pjesme kojoj zelite mijenjati redni broj:");
                while (stopParameter != 0)
                {
                    var index = int.Parse(Console.ReadLine());
                    if (!givenPlaylist.ContainsKey(index))
                    {
                        var satisfied = -1;
                        Console.WriteLine("Nije pronadjena pjesma na rednom broju {0}", index);
                        Console.WriteLine("Zelite li ponovno unijeti redni broj pjesme kojoj zelite izmijeniti redni broj?\n1 - da\n2 - ne, vrati me na izbornik");
                        while (satisfied != 0)
                        {
                            var choose = int.Parse(Console.ReadLine());
                            switch (choose)
                            {
                                case 2:
                                    satisfied = 0;
                                    break;
                                case 1:
                                    Console.WriteLine("Unesite redni broj pjesme kojoj zelite mijenjati redni broj:");
                                    satisfied = 0;
                                    break;
                                default:
                                    Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        var stopParameter2 = -1;
                        Console.WriteLine("Jeste li sigurni da zelite izmijeniti redni broj pjesme '{0}' na rednom broju {1} u playlisti?\n1 - da, izmijeni redni broj pjesme" +
                                       "\n2 - ne, vrati me na ponovni unos\n0 - ne, vrati me u izbornik", givenPlaylist[index], index);
                        var choice = int.Parse(Console.ReadLine());
                        while(stopParameter2 != 0)
                        {
                            switch (choice)
                            {
                                case 1:
                                    var songName = givenPlaylist[index];
                                    Console.WriteLine("Unesite novi redni broj pjesme '{0}' (trenutno na broju {1}) - " +
                                        "neka novi redni broj bude cijeli broj od 1 do {2}", songName, index, givenPlaylist.Count);
                                    var newIndex = int.Parse(Console.ReadLine()); var stopParameter3 = -1;

                                    while (stopParameter3 != 0 && (newIndex < 0 || newIndex > givenPlaylist.Count)) //unos pravilnog novog indexa
                                    {
                                        Console.WriteLine("Novi redni broj {0} je izvan dozvoljenih granica od 1 do {1}. Zelite li unijeti novi redni broj?" +
                                            "\n1 - da, zelim unijeti novi redni broj\n2 - ne, vrati me na izbornik", newIndex, givenPlaylist.Count); var stopParameter4 = -1;
                                        while (stopParameter4 != 0)
                                        {
                                            var choice4 = int.Parse(Console.ReadLine());
                                            switch (choice4)
                                            {
                                                case 1:
                                                    Console.WriteLine("Unesite novi redni broj pjesme '{0}' (trenutno na broju {1}) - " +
                                                    "neka novi redni broj bude cijeli broj od 1 do {2}", givenPlaylist[index], index, givenPlaylist.Count);
                                                    newIndex = int.Parse(Console.ReadLine());
                                                    stopParameter4 = 0;
                                                    break;
                                                case 2:
                                                    stopParameter4 = 0; stopParameter3 = 0; stopParameter2 = 0; stopParameter = 0;
                                                    break;
                                                default:
                                                    Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                                    break;
                                            }
                                        }
                                    }

                                    if (newIndex == index)
                                    {
                                        Console.WriteLine("Novi redni broj pjesme je jednak starom - nema promjene - Povratak na izbornik");
                                    }
                                    else if (newIndex < index)
                                    {
                                        var temporary = givenPlaylist[newIndex];
                                        givenPlaylist.Remove(index);
                                        givenPlaylist[newIndex] = songName; songName = temporary;
                                        for (var i = newIndex+1; i < index; i++)
                                        {
                                            temporary = givenPlaylist[i];
                                            givenPlaylist.Remove(i);
                                            givenPlaylist[i] = songName;
                                            songName = temporary;
                                        }
                                        givenPlaylist[index] = songName;
                                        Console.WriteLine("Uspjesno izvrsena zamjena rednog broja, slijedi povratak na izbornik");
                                    }
                                    else
                                    {
                                        var temporary = givenPlaylist[newIndex];
                                        givenPlaylist.Remove(index);
                                        givenPlaylist[newIndex] = songName; songName = temporary;
                                        for (var i = newIndex-1; i > index; i--)
                                        {
                                            temporary = givenPlaylist[i];
                                            givenPlaylist.Remove(i);
                                            givenPlaylist[i] = songName;
                                            songName = temporary;
                                        }
                                        givenPlaylist[index] = songName;
                                        Console.WriteLine("Uspjesno izvrsena zamjena rednog broja, slijedi povratak na izbornik");
                                    }
                                    stopParameter = 0;  stopParameter2 = 0; 
                                    break;
                                case 2:
                                    Console.WriteLine("Unesite redni broj pjesme kojoj zelite mijenjati redni broj:");
                                    stopParameter2 = 0;
                                    break;
                                case 0:
                                    Console.WriteLine("Povratak na izbornik");
                                    stopParameter = 0; stopParameter2 = 0;
                                    break;
                                default:
                                    Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                                    break;
                            }
                        }
                    }
                }
            }
        }

        static Dictionary<int, string> ShufflePlaylist(Dictionary<int, string> givenPlaylist)
        {
            var newPlaylist = new Dictionary<int, string>();
            if (givenPlaylist.Count == 0)
            {
                Console.WriteLine("Playlista je prazna! Povratak na izbornik.");
            }
            else
            {
                var stopArgument = -1;
                Console.WriteLine("Jeste li sigurni da zelite randomizirati playlistu?\n1 - da\n2 - ne, vrati me na izbornik");
                while(stopArgument != 0)
                {
                    var choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            var temporaryList = new List<int>();
                            var rnd = new Random(); var counter = 1;
                            var givenSize = givenPlaylist.Count;

                            for (var i = 1; i < givenSize + 1; i++)
                            {
                                temporaryList.Add(i);
                            }

                            while (temporaryList.Count != 0)
                            {
                                var randomIndex = rnd.Next(temporaryList.Count);
                                newPlaylist[counter] = givenPlaylist[temporaryList[randomIndex]];
                                counter++;
                                temporaryList.Remove(temporaryList[randomIndex]);
                            }
                            Console.WriteLine("Playlista uspjesno randomizirana - Povratak na izbornik");
                            stopArgument = 0;
                            break;
                        case 2:
                            Console.WriteLine("Povratak na izbornik");
                            stopArgument = 0;
                            break;
                        default:
                            Console.WriteLine("Unesena je akcija koja nije na listi. Molimo ponovno unesite akciju.");
                            break;
                    }
                }
            }
            
            return newPlaylist;
        }
    }
}