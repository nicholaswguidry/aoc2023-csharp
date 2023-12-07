# aoc2023-csharp

This repo holds my attempts and solutions to the Advent of Code 2023.

Each Day is given 2 functions in DayFunctions.cs (`DayXPart1` and `DayXPart2`).

Each Day has 2 sets of inputs. Example `Day6Test/input.txt` and `Day6/input.txt`.

While developing, new folders/input files can quickly be created using `dotnet Setup DayX` where `X` is the number of the day.

This will also copy the `DayTemplate.cs` as `DayX.cs` -- just be sure to go in change the class name from `DayX`! After that, add the Day and Part to the switch in `main.cs`.

To run solution:

```bash
dotnet run DayX PartY
```

