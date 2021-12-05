Console.WriteLine("Day 5: Hydrothermal Venture");
const string exampleInput = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

var inputString = string.Empty;

if (args.Length > 0){
    var filePath =args[0];

    if (File.Exists(filePath)){
        inputString = File.ReadAllText(filePath);
    }
}else{
    
    Console.WriteLine("Using example input");
    inputString = exampleInput;
}
Console.WriteLine("Input:");
Console.WriteLine(inputString);

Dictionary<Point, int> points = new();

Console.WriteLine("Loop all input lines");
foreach(var inputLine in inputString.Split(Environment.NewLine)){

    Console.WriteLine(inputLine);
    var locationBlocks = inputLine.Split("->", 2, StringSplitOptions.TrimEntries);
    var startLocations = locationBlocks[0].Split(",", 2, StringSplitOptions.TrimEntries).Select(x=>int.Parse(x)).ToArray();
    var endLocations = locationBlocks[1].Split(",", 2, StringSplitOptions.TrimEntries).Select(x=>int.Parse(x)).ToArray();

    var currentLocation = startLocations;
    while(true){
        
        var p = new Point(currentLocation[0], currentLocation[1]);

        if (points.TryGetValue(p, out int value)){
            points[p] = value + 1;
        }else{
            points.Add(p,1);
        };

        if (currentLocation.SequenceEqual(endLocations)){
            break;
        }

        if (currentLocation[0] != endLocations[0] ){
            currentLocation[0] = endLocations[0] > startLocations[0] ? currentLocation[0] + 1 : currentLocation[0] - 1;  
        }   
        if (currentLocation[1] != endLocations[1] ){
            currentLocation[1] = endLocations[1] > startLocations[1] ? currentLocation[1] + 1 : currentLocation[1] - 1;  
        }
    };
}

var overlappingPointCount = points.Count(x=>x.Value > 1);

Console.WriteLine($"Total {overlappingPointCount} overlapping locations");

public struct Point : IEquatable<Point>
{
    public readonly int X {get;}
    public readonly int Y {get;}

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public bool Equals(Point other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }
}