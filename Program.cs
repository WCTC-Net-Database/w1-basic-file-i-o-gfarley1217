class Program
{
    static void Main()
    {

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");

        var menuOption = Console.ReadLine();

        if (menuOption == "1")
        {
            var lines = File.ReadAllLines("input.csv");

            for (int i = 0; i < lines.Length; i++)
            {
                var cols = lines[i].Split(",");

                var name = cols[0];
                var profession = cols[1];
                var level = cols[2];
                var hitPoints = cols[3];
                var equipment = cols[4];
                //var items = equipment.Split("|") <--to split the equipment into separate lines

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Job: {profession}");
                Console.WriteLine($"Level: {level}");
                Console.WriteLine($"Hit Points: {hitPoints}");
                Console.WriteLine($"Equipment: {equipment}");
                Console.WriteLine();
            }
        }

        if (menuOption == "2")
        {
            using (StreamWriter writer = new StreamWriter("input.csv", true))
            {
                Console.Write("Enter your character's name: ");
                string name = Console.ReadLine();

                Console.Write("Enter your character's class: ");
                string characterClass = Console.ReadLine();

                Console.Write("Enter your character's level: ");
                int level = int.Parse(Console.ReadLine());

                Console.Write("Enter your character's Hit Points: ");
                int hitPoints = int.Parse(Console.ReadLine());  

                Console.Write("Enter your character's equipment (separate items with a '|'): ");
                string[] equipment = Console.ReadLine().Split('|');

                //Used chatgpt to help me figure out the equipment aspect of the following code. The equipment would come out as "System String[]" prior to my asking for AI's assistance
                writer.WriteLine($"\r\n{name},{characterClass},{level},{hitPoints},{string.Join("|", equipment)}");

                Console.WriteLine($"Welcome, {name} the {characterClass}! You are level {level} with {hitPoints} Hit Points and your equipment includes: {string.Join(", ", equipment)}.");
            }

            
        }

        if (menuOption == "3")
        {

            // The following is code that was very heavily assisted by AI. I understand everything in this code aside from the line with a comment above it.
            // I felt quite overwhelmed attempting to access and modify a specific column within a line on my own
            // The commented out code below this that I created on my own would output the following into the csv file: "____'s level has been upgraded to a __"

            var lines = File.ReadAllLines("input.csv");
            var updatedLines = new List<string>();

            Console.Write("Enter the name of the character you wish to edit: ");
            string nameToEdit = Console.ReadLine();

            bool characterFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var cols = lines[i].Split(",");

                var name = cols[0];
                var profession = cols[1];
                var level = int.Parse(cols[2]);
                var hitPoints = cols[3];
                var equipment = cols[4];

                // I definitely do not understand the line below. Particularly the OrdinalIgnoreCase.
                // I feel this is likely a bit advanced for what we are supposed to be doing at the moment
                // However, this is the only way I was able to get Menu Option 3 to work for me

                if (name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Enter the new level for the character: ");
                    int newLevel = int.Parse(Console.ReadLine());

                    cols[2] = newLevel.ToString();

                    string updatedLine = string.Join(",", cols);
                    updatedLines.Add(updatedLine);

                    characterFound = true;
                    Console.WriteLine($"Congratulations! {name} has been upgraded to level {newLevel}.");
                }
                else
                {
                    updatedLines.Add(lines[i]);
                }
            }

            if (!characterFound)
            {
                Console.WriteLine("Character not found.");
            }
            else
            {
                File.WriteAllLines("input.csv", updatedLines);
            }

            // THE FOLLOWING IS CODE I CAME UP WITH ON MY OWN
            // It does not accomplish the desired outcome of editing a character
            // I wanted to display my logic
            // Plan on asking more questions going forward

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    var cols = lines[i].Split(",");
            //
            //    var name = cols[0];
            //    var profession = cols[1];
            //    var level = cols[2];
            //    var hitPoints = cols[3];
            //    var equipment = cols[4];
            //}
            //using (StreamWriter writer = new StreamWriter("input.csv", true))
            //{
            //    Console.Write("Enter name of character you wish to edit: ");
            //    string name = Console.ReadLine();
            //
            //    Console.Write("Enter character new level: ");
            //    int level = int.Parse(Console.ReadLine());
            //
            //    writer.WriteLine($"\r\n {name}'s level has been upgraded to {level}");
            //
            //    Console.WriteLine($"Congratulations! {name} has been upgraded to level {level}.");


        }
    }


}


