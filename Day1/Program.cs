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