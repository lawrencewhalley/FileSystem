using System.Collections;
using System.Xml.Serialization;

// Name LawrenceWhalley    Date: 15/03/2023

//Note: For What to Do point 6:
// i would use my search function and replace the "Directory.GetFiles(rootNode);" with
// Directory.GetFiles(rootfolder, "*.fileextension", SearchOption.AllDirectories);



bool Quit = false;

while (Quit == false) {
    Console.WriteLine("Welcome to my applcation");
    Console.WriteLine("Please enter a number to selecet your action");
    Console.WriteLine("1: add an item or folder");
    Console.WriteLine("2: remove an item or folder");
    Console.WriteLine("3: move an item or folder");
    Console.WriteLine("4: search for an item or folder");
    Console.WriteLine("9: Quit");

    string dir = @"C:\rootFolder";
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }

    int choice = Convert.ToInt32(Console.ReadLine());
    ArrayList Items = new ArrayList();
    ArrayList Folders = new ArrayList();

    if (choice == 1)
    {
        Console.WriteLine("Please enter a 1 to add a folder or 2 to add an item");
        int selection = Convert.ToInt32(Console.ReadLine());
        if (selection == 1)
        {
            Console.WriteLine("Please enter the folder name");
            string folderName = Console.ReadLine();
            new Folder(folderName);
        }
        else if (selection == 2)
        {
            Console.WriteLine("Please enter the file name");
            string itemName = Console.ReadLine();
            new Item(itemName);
        }

    }
    else if (choice == 2)
    {
        Console.WriteLine("Please enter a 1 to remove a folder or 2 to remove an item");
        int selection = Convert.ToInt32(Console.ReadLine());
        if (selection == 1)
        {
            Console.WriteLine("Please enter the folder path you want to delete");
            string Location = Console.ReadLine();
            String standardPath = @"C:\rootFolder\";
            String deletePath = standardPath + Location;
            Directory.Delete(deletePath);
        }
        else if (selection == 2)
        {
            Console.WriteLine("Please enter the file path you want to delete");
            string Location = Console.ReadLine();
            String standardPath = @"C:\rootFolder\";
            String deletePath = standardPath + Location;
            File.Delete(deletePath);
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine("Please enter a 1 to move a folder or 2 to move an item");
        int selection = Convert.ToInt32(Console.ReadLine());
        if (selection == 1)
        {
            Console.WriteLine("Please enter the folder path you want to move");
            string originalLocation = Console.ReadLine();
            Console.WriteLine("Please enter the path you want to move the folder to including the name of the folder");
            string MovedLocation = Console.ReadLine();
            String standardPath = @"C:\rootFolder\";
            String MovedPath = standardPath + MovedLocation;
            String originalPath = standardPath + originalLocation;
            Directory.Move(originalPath, MovedPath);


        }
        else if (selection == 2)
        {
            Console.WriteLine("Please enter the file path you want to move");
            string originalLocation = Console.ReadLine();
            Console.WriteLine("Please enter the path you want to move the file to including the file name");
            string MovedLocation = Console.ReadLine();
            String standardPath = @"C:\rootFolder\";
            String MovedPath = standardPath + MovedLocation;
            String originalPath = standardPath + originalLocation;
            File.Move(originalPath, MovedPath);

        }
    }
    else if (choice == 4)
    {
        Console.WriteLine("Please enter the name of the file or folder you want to search for:");
        String searchKey = Console.ReadLine();
        String rootNode = @"C:\rootFolder\";
        string[] files = Directory.GetFiles(rootNode);

        Console.WriteLine("Items Found: ");

        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine(files[i]);
        }

        Console.WriteLine("-------------------------------");

    }
    else if (choice == 9)
    {
        Quit = true;
    }
    else
    {
        Console.WriteLine(" Invalid Input Please Try Again");
    }
}

    class Item
    {
        public Item(string itemName)
        {
            String standardPath = @"C:\rootFolder\";
            String itemPath = standardPath + itemName;
            File.Create(itemPath);
        }
    }
    class Folder
    {
        public Folder(string folderName)
        {
            String standardPath = @"C:\rootFolder\";
            String folderPath = standardPath + folderName;
            Directory.CreateDirectory(folderPath);

        }
    }