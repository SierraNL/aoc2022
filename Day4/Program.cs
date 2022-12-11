//https://adventofcode.com/2022/day/4

var input = File.ReadAllLines("input.txt");
int totalConveringPairs = 0;

foreach(var pair in input) {
    var elf1 = GetRange(pair.Split(',')[0]);
    var elf2 = GetRange(pair.Split(',')[1]);

    if(IsCovering(elf1, elf2)) {
        totalConveringPairs++;
    }
}

Console.WriteLine($"The assignments contain {totalConveringPairs} covering pairs of elfs.");

IEnumerable<int> GetRange(string input) {
    var result = new List<int>();

    var start = int.Parse(input.Split('-')[0]);
    var end = int.Parse(input.Split('-')[1]);

    for(int i = start; i<=end; i++) {
        result.Add(i);
    }

    return result;
}

bool IsCovering(IEnumerable<int> elf1, IEnumerable<int> elf2) {
    bool result = false;

    if(elf1.All(x => elf2.Contains(x)) || elf2.All(x => elf1.Contains(x))) {
        Console.WriteLine($"Pairs {string.Join(",", elf1)} and {string.Join(",", elf2)} are covering pairs of elfs.");
        result = true;
    }

    return result;
}