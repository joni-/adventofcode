﻿// Learn more about F# at http://fsharp.org
namespace Solutions.App

open System.IO

module Program = let [<EntryPoint>] main _ =
                  let fullPath filename = sprintf "./src/Inputs/%s" filename
                  let readInput filename = File.ReadAllText(filename |> fullPath)

                  let puzzle01aResult = Solutions.Puzzle01a.solve("Puzzle01.input" |> readInput)
                  printfn "Puzzle01a: %d" puzzle01aResult
                  let puzzle01bResult = Solutions.Puzzle01b.solve("Puzzle01.input" |> readInput)
                  printfn "Puzzle01b: %d" puzzle01bResult
                  let puzzle02aResult = Solutions.Puzzle02a.solve("Puzzle02.input" |> readInput)
                  printfn "Puzzle02a: %d" puzzle02aResult
                  let puzzle02bResult = Solutions.Puzzle02b.solve("Puzzle02.input" |> readInput)
                  printfn "Puzzle02b: %A" puzzle02bResult
                  let puzzle03aResult = Solutions.Puzzle03.solveA("Puzzle03.input" |> readInput)
                  printfn "Puzzle03a: %A" puzzle03aResult
                  let puzzle03bResult = Solutions.Puzzle03.solveB("Puzzle03.input" |> readInput)
                  printfn "Puzzle03b: %A" puzzle03bResult
                  let puzzle04aResult = Solutions.Puzzle04.solveA("Puzzle04.input" |> readInput)
                  printfn "Puzzle04a: %A" puzzle04aResult
                  let puzzle04bResult = Solutions.Puzzle04.solveB("Puzzle04.input" |> readInput)
                  printfn "Puzzle04b: %A" puzzle04bResult
                  let puzzle05aResult = Solutions.Puzzle05.solveA("Puzzle05.input" |> readInput)
                  printfn "Puzzle05a: %A" puzzle05aResult
                  let puzzle05bResult = Solutions.Puzzle05.solveB("Puzzle05.input" |> readInput)
                  printfn "Puzzle05b: %A" puzzle05bResult
                  let puzzle06aResult = Solutions.Puzzle06.solveA("Puzzle06.input" |> readInput)
                  printfn "Puzzle06a: %A" puzzle06aResult
                  let puzzle06bResult = Solutions.Puzzle06.solveB("Puzzle06.input" |> readInput)
                  printfn "Puzzle06b: %A" puzzle06bResult
                  let puzzle07aResult = Solutions.Puzzle07.solveA("Puzzle07.input" |> readInput)
                  printfn "Puzzle07a: %A" puzzle07aResult

                  // #.......#....#.....###..######..#....#....##....#....#....##..
                  // #.......#....#......#...#.......#...#....#..#...#....#...#..#.
                  // #........#..#.......#...#.......#..#....#....#...#..#...#....#
                  // #........#..#.......#...#.......#.#.....#....#...#..#...#....#
                  // #.........##........#...#####...##......#....#....##....#....#
                  // #.........##........#...#.......##......######....##....######
                  // #........#..#.......#...#.......#.#.....#....#...#..#...#....#
                  // #........#..#...#...#...#.......#..#....#....#...#..#...#....#
                  // #.......#....#..#...#...#.......#...#...#....#..#....#..#....#
                  // ######..#....#...###....#.......#....#..#....#..#....#..#....#
                  // let puzzle10aResult = Solutions.Puzzle10.solveA("Puzzle10.input" |> readInput)
                  // printfn "Puzzle10a: %A" puzzle10aResult

                  // 10312 seconds
                  let puzzle10bResult = Solutions.Puzzle10.solveB("Puzzle10.input" |> readInput)
                  printfn "Puzzle10b: %A" puzzle10bResult
                  0
