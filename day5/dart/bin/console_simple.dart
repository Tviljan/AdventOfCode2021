import 'dart:async';
import 'dart:collection';
import 'dart:io';
import 'package:equatable/equatable.dart';

void main(List<String> arguments) {
  print("Day 5: Hydrothermal Venture");

  final String exampleInput = """0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2""";
  var inputString = "";
  if (arguments.isNotEmpty) {
    var filePath = arguments.first;
    final file = File(filePath);
    if (file.existsSync()) {
      inputString = file.readAsStringSync();
    }
  } else {
    print("Using example input");
    inputString = exampleInput;
  }

  print("Input:");
  print(inputString);

  var points = HashMap<Point, int>();
  //var points = {};
  print("Loop all input lines");
  inputString.split('\n').forEach((inputLine) {
    print(inputLine);
    var locationBlocks = inputLine.split("->");
    var startLocations =
        locationBlocks[0].split(",").map((x) => int.parse(x.trim())).toList();
    var endLocations =
        locationBlocks[1].split(",").map((x) => int.parse(x.trim())).toList();

    var currentLocation = startLocations;

    while (true) {
      var p = Point(currentLocation[0], currentLocation[1]);

      if (points.containsKey((p))) {
        points[p] = points[p]! + 1;
      } else {
        points[p] = 1;
      }

      if (currentLocation[0] == endLocations[0] &&
          currentLocation[1] == endLocations[1]) {
        break;
      }

      if (currentLocation[0] != endLocations[0]) {
        currentLocation[0] = endLocations[0] > startLocations[0]
            ? currentLocation[0] + 1
            : currentLocation[0] - 1;
      }
      if (currentLocation[1] != endLocations[1]) {
        currentLocation[1] = endLocations[1] > startLocations[1]
            ? currentLocation[1] + 1
            : currentLocation[1] - 1;
      }
    }
  });

  points.removeWhere((key, value) => value == 1);
  var count = points.length;
  print("Total $count overlapping locations");
}

class Point extends Equatable {
  final int x;
  final int y;
  const Point(this.x, this.y);

  @override
  List<Object> get props => [x, y];
}
