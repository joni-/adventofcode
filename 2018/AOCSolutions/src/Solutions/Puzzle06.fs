// --- Day 6: Chronal Coordinates ---
// The device on your wrist beeps several times, and once again you feel like you're falling.

// "Situation critical," the device announces. "Destination indeterminate. Chronal interference detected. Please specify new target coordinates."

// The device then produces a list of coordinates (your puzzle input). Are they places it thinks are safe or dangerous? It recommends you check manual page 729. The Elves did not give you a manual.

// If they're dangerous, maybe you can minimize the danger by finding the coordinate that gives the largest distance from the other points.

// Using only the Manhattan distance, determine the area around each coordinate by counting the number of integer X,Y locations that are closest to that coordinate (and aren't tied in distance to any other coordinate).

// Your goal is to find the size of the largest area that isn't infinite. For example, consider the following list of coordinates:

// 1, 1
// 1, 6
// 8, 3
// 3, 4
// 5, 5
// 8, 9
// If we name these coordinates A through F, we can draw them on a grid, putting 0,0 at the top left:

// ..........
// .A........
// ..........
// ........C.
// ...D......
// .....E....
// .B........
// ..........
// ..........
// ........F.
// This view is partial - the actual grid extends infinitely in all directions. Using the Manhattan distance, each location's closest coordinate can be determined, shown here in lowercase:

// aaaaa.cccc
// aAaaa.cccc
// aaaddecccc
// aadddeccCc
// ..dDdeeccc
// bb.deEeecc
// bBb.eeee..
// bbb.eeefff
// bbb.eeffff
// bbb.ffffFf
// Locations shown as . are equally far from two or more coordinates, and so they don't count as being closest to any.

// In this example, the areas of coordinates A, B, C, and F are infinite - while not shown here, their areas extend forever outside the visible grid. However, the areas of coordinates D and E are finite: D is closest to 9 locations, and E is closest to 17 (both including the coordinate's location itself). Therefore, in this example, the size of the largest area is 17.

// What is the size of the largest area that isn't infinite?

// --- Part Two ---
// On the other hand, if the coordinates are safe, maybe the best you can do is try to find a region near as many coordinates as possible.

// For example, suppose you want the sum of the Manhattan distance to all of the coordinates to be less than 32. For each location, add up the distances to all of the given coordinates; if the total of those distances is less than 32, that location is within the desired region. Using the same coordinates as above, the resulting region looks like this:

// ..........
// .A........
// ..........
// ...###..C.
// ..#D###...
// ..###E#...
// .B.###....
// ..........
// ..........
// ........F.
// In particular, consider the highlighted location 4,3 located at the top middle of the region. Its calculation is as follows, where abs() is the absolute value function:

// Distance to coordinate A: abs(4-1) + abs(3-1) =  5
// Distance to coordinate B: abs(4-1) + abs(3-6) =  6
// Distance to coordinate C: abs(4-8) + abs(3-3) =  4
// Distance to coordinate D: abs(4-3) + abs(3-4) =  2
// Distance to coordinate E: abs(4-5) + abs(3-5) =  3
// Distance to coordinate F: abs(4-8) + abs(3-9) = 10
// Total distance: 5 + 6 + 4 + 2 + 3 + 10 = 30
// Because the total distance to all coordinates (30) is less than 32, the location is within the region.

// This region, which also includes coordinates D and E, has a total size of 16.

// Your actual region will need to be much larger than this example, though, instead including all locations with a total distance of less than 10000.

// What is the size of the region containing all locations which have a total distance to all given coordinates of less than 10000?

namespace Solutions

open System

module Puzzle06 =
    type Coordinate = int * int

    let UNOCCUPIED_COORDINATE = Coordinate(-1, -1)
    let UNDEFINED_DISTANCE = -1

    type CoordinateStatus(ownedBy: Coordinate, distance: int, coordinate: Coordinate) =
        member this.OwnedBy = ownedBy
        member this.Distance = distance

        member this.Coordinate = coordinate

    let topLeft coordinates: Coordinate =
        let minX = coordinates |> Seq.minBy (fun (x, _) -> x) |> fst
        let minY = coordinates |> Seq.minBy (fun (_, y) -> y) |> snd
        Coordinate(minX, minY)

    let bottomRight coordinates: Coordinate =
        let maxX = coordinates |> Seq.maxBy (fun (x, _) -> x) |> fst
        let maxY = coordinates |> Seq.maxBy (fun (_, y) -> y) |> snd
        Coordinate(maxX, maxY)

    let distance (a: Coordinate) (b: Coordinate) =
        let deltaX = fst a - fst b |> Math.Abs
        let deltaY = snd a - snd b |> Math.Abs
        deltaX + deltaY

    let coordinateSpace (topLeft: Coordinate) (bottomRight: Coordinate) =
        let xs = { fst topLeft .. fst bottomRight }
        let ys = { snd topLeft .. snd bottomRight }
        Seq.fold (fun acc x ->
            Seq.fold (fun (inner: Map<Coordinate, CoordinateStatus>) y ->
                let coordinate = (x, y)
                inner.Add(coordinate, CoordinateStatus(UNOCCUPIED_COORDINATE, UNDEFINED_DISTANCE, coordinate))
            ) acc ys
        ) Map.empty xs

    let createCoordinate (s: string) =
        let parts = s.Split([|','|]) |> Seq.map (fun s -> s.Trim() |> int)
        Coordinate(Seq.head parts, Seq.last parts)

    let findInfinityCoords (topLeft: Coordinate) (bottomRight: Coordinate) (statuses: seq<CoordinateStatus>) =
        statuses
            |> Seq.filter (fun status ->
                let x = fst status.Coordinate
                let y = snd status.Coordinate
                x = fst topLeft || y = snd topLeft || x = fst bottomRight || y = snd bottomRight
            )
            |> Seq.filter (fun status -> status.OwnedBy <> UNOCCUPIED_COORDINATE)
            |> Seq.map (fun status -> status.OwnedBy)
            |> Set.ofSeq

    let solveA (input: string) =
        let coordinates = input |> Util.splitByRow |> Seq.map createCoordinate
        let topLeftCoordinate = coordinates |> topLeft
        let bottomRightCoordinate = coordinates |> bottomRight
        let fullCoordinateSpace = coordinateSpace topLeftCoordinate bottomRightCoordinate

        let grid = Seq.fold (fun acc coordinate ->
                        Map.map (fun k (v: CoordinateStatus) ->
                            let dist = distance coordinate k
                            if v.OwnedBy = UNOCCUPIED_COORDINATE && v.Distance = UNDEFINED_DISTANCE then
                                CoordinateStatus(coordinate, dist, k)
                            elif coordinate = v.Coordinate then CoordinateStatus(coordinate, 0, coordinate)
                            else
                                if dist < v.Distance then CoordinateStatus(coordinate, dist, k)
                                elif dist = v.Distance then CoordinateStatus(UNOCCUPIED_COORDINATE, dist, k)
                                else v
                        ) acc
                    ) fullCoordinateSpace coordinates

        let infiniteCoords = findInfinityCoords topLeftCoordinate bottomRightCoordinate (grid |> Map.toSeq |> Seq.map (fun (k, v) -> v))

        grid
            |> Map.toSeq
            |> Seq.map snd
            |> Seq.filter (fun s -> s.OwnedBy <> UNOCCUPIED_COORDINATE)
            |> Seq.groupBy (fun s -> s.OwnedBy)
            |> Seq.filter (fun (owner, _) -> not (Set.contains owner infiniteCoords))
            |> Seq.maxBy (fun (_, s) -> s |> Seq.length)
            |> snd
            |> Seq.length

    let solveB (input: string) =
        let coordinates = input |> Util.splitByRow |> Seq.map createCoordinate
        let topLeftCoordinate = coordinates |> topLeft
        let bottomRightCoordinate = coordinates |> bottomRight
        let fullCoordinateSpace = coordinateSpace topLeftCoordinate bottomRightCoordinate
        fullCoordinateSpace
            |> Map.map (fun k _ -> coordinates |> Seq.sumBy (fun c -> distance k c))
            |> Map.filter (fun _ v -> v < 10000)
            |> Map.count
