//https://adventofcode.com/2022/day/1

var input = File.ReadAllLines("input.txt");

var caloriesPerElf = new Dictionary<int, int>();

int elf = 1;
caloriesPerElf.Add(elf, 0);
foreach(var line in input) {

    if(string.IsNullOrWhiteSpace(line)) {
        elf++;
        caloriesPerElf.Add(elf, 0);
    }
    else {
        caloriesPerElf[elf] += int.Parse(line);
    }
}

var elfWithMostCalories = caloriesPerElf.MaxBy(x => x.Value);

Console.WriteLine($"Elf {elfWithMostCalories.Key} has the most calories: {elfWithMostCalories.Value}");

//Elf 31 has the most calories: 66306

//Part 2
var orderedByMostCalories = caloriesPerElf.OrderByDescending(x => x.Value);
var threeElfsWithMostCalories = orderedByMostCalories.Take(3);
var sumOfTop3 = threeElfsWithMostCalories.Sum(x => x.Value);

Console.WriteLine($"The top 3 elves have a combined total of calories of {sumOfTop3}");