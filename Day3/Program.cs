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
            prioritiesSum += GetPriority(itemType);
        }
    }

}

int GetPriority(char input) {
    //convert to ascii
    var asciiValue = (int)input;
    
    //lowercase correction to priority
    if(asciiValue > 96) {
        return asciiValue - 96;
    }
    //uppercase correction to priority
    else {
        return asciiValue - 38;
    }
}

Console.WriteLine($"The sum of all priorities is {prioritiesSum}");

//part 2

var rucksackGroupBadges = new List<int>();
var rucksackGroup = new List<string>();
foreach(var rucksack in input) {
    if(rucksackGroup.Count < 2) {
        rucksackGroup.Add(rucksack);
    }
    else {
        //determine the badge itemtype
        string itemsAlreadyFound = string.Empty;
        foreach(var rucksackInGroup in rucksackGroup) {
            string itemsAlreadyFoundInThisRucksack = string.Empty;
            foreach(var itemType in rucksack) {
                if(rucksackInGroup.Contains(itemType)) {
                    itemsAlreadyFoundInThisRucksack += itemType;
                }
            }
            //to prevent duplicates per rucksack
            itemsAlreadyFound += new string(itemsAlreadyFoundInThisRucksack.Distinct().ToArray());
        }
        var itemTypeBadge = itemsAlreadyFound.GroupBy(x => x).OrderByDescending(o => o.Count()).First().First();
        Console.WriteLine($"In group {rucksackGroup[0]}, {rucksackGroup[1]}, comparing with {rucksack} matching types are {itemsAlreadyFound}, which makes badge {itemTypeBadge}");
        
        rucksackGroupBadges.Add(GetPriority(itemTypeBadge));
        //reset the group
        rucksackGroup = new List<string>();
    }
}

Console.WriteLine($"The sum of all priorities of the badge itemtypes is {rucksackGroupBadges.Sum()}");