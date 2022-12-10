//https://adventofcode.com/2022/day/2

var input = File.ReadAllLines("input.txt");

int playerRpsScore = 0;
int playerOutcomeScore = 0;

foreach(var round in input) {
    var opponent = GetRpsOpponent(round[0]);
    var player = GetRpsPlayer(round[2]);
    var outcome = GetOutcome(round[2]);

    playerRpsScore += (int)player;
    playerRpsScore += DetermineScore(player, opponent);
    
    //by outcome
    if(outcome == Outcome.Draw) {
        playerOutcomeScore += 3;
        playerOutcomeScore += (int)opponent;
    }
    else if(outcome == Outcome.Lose) {
        if(opponent == Rps.Rock) {
            playerOutcomeScore += (int)Rps.Scissors;
        }
        else if(opponent == Rps.Paper) {
            playerOutcomeScore += (int)Rps.Rock;
        }
        else if(opponent == Rps.Scissors) {
            playerOutcomeScore += (int)Rps.Paper;
        }
    }
    else if(outcome == Outcome.Win) {
        playerOutcomeScore += 6;
        if(opponent == Rps.Rock) {
            playerOutcomeScore += (int)Rps.Paper;
        }
        else if(opponent == Rps.Paper) {
            playerOutcomeScore += (int)Rps.Scissors;
        }
        else if(opponent == Rps.Scissors) {
            playerOutcomeScore += (int)Rps.Rock;
        }
    }
}

Console.WriteLine($"Player total score using RPS {playerRpsScore}");
Console.WriteLine($"Player total score using Outcome {playerOutcomeScore}");

int DetermineScore(Rps player, Rps opponent) {
    int result = 0;
    
    //draw
    if(opponent == player) {
        result += 3;
    }
    //player wins
    if(player == Rps.Rock && opponent == Rps.Scissors ||
    player == Rps.Scissors && opponent == Rps.Paper ||
    player == Rps.Paper && opponent == Rps.Rock
    ) {
        result += 6;
    }

    return result;
}

Rps GetRpsOpponent(char source) {
    if(source == 'A') {
        return Rps.Rock;
    }
    else if(source == 'B') {
        return Rps.Paper;
    }
    else if(source == 'C') {
        return Rps.Scissors;
    }
    throw new ArgumentException();
}

Rps GetRpsPlayer(char source) {
    if(source == 'X') {
        return Rps.Rock;
    }
    else if(source == 'Y') {
        return Rps.Paper;
    }
    else if(source == 'Z') {
        return Rps.Scissors;
    }
    throw new ArgumentException();
}

Outcome GetOutcome(char source) {
    if(source == 'X') {
        return Outcome.Lose;
    }
    else if(source == 'Y') {
        return Outcome.Draw;
    }
    else if(source == 'Z') {
        return Outcome.Win;
    }
    throw new ArgumentException();
}

enum Rps {
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

enum Outcome {
    Win = 6,
    Lose = 0,
    Draw = 3
}