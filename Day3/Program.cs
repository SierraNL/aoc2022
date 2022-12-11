//https://adventofcode.com/2022/day/3

var input = File.ReadAllLines("input.txt");

int prioritiesSum = 0;

foreach(var rucksack in input) {
    //split into compartments
    var compartment1 = rucksack.Substring(0, rucksack.Length / 2);
    var compartment2 = rucksack.Substring((rucksack.Length / 2), rucksack.Length / 2);

    //find doubles
    string itemsAlreadyFound = string.Empty;
    foreach(var itemType in compartment1) {
        if(compartment2.Contains(itemType) && !itemsAlreadyFound.Contains(itemType)) {
            //add to already found
            itemsAlreadyFound += itemType;
            //convert to ascii
            var asciiValue = (int)itemType;
            
            //lowercase correction to priority
            if(asciiValue > 96) {
                prioritiesSum += asciiValue - 96;
                Console.WriteLine($"Found {itemType} convert to in {asciiValue} corrected for priority {asciiValue - 96}");
            }
            //uppercase correction to priority
            else {
                prioritiesSum += asciiValue - 38;
                Console.WriteLine($"Found {itemType} convert to in {asciiValue} corrected for priority {asciiValue - 38}");
            }
        }
    }

}

Console.WriteLine($"The sum of all priorities is {prioritiesSum}");