// Learn more about F# at http://fsharp.org
namespace Solutions.App

open System
open Solutions

module Program = let [<EntryPoint>] main _ =
                  let puzzle01aResult = Solutions.Puzzle01a.readFileAndSolve("./src/Solutions/Puzzle01.input")
                  printfn "Puzzle01a: %d" puzzle01aResult
                  let puzzle01bResult = Solutions.Puzzle01b.readFileAndSolve("./src/Solutions/Puzzle01.input")
                  printfn "Puzzle01b: %d" puzzle01bResult
                  let puzzle02aResult = Solutions.Puzzle02a.readFileAndSolve("./src/Solutions/Puzzle02.input")
                  printfn "Puzzle02a: %d" puzzle02aResult
                  let puzzle02bResult = Solutions.Puzzle02b.readFileAndSolve("./src/Solutions/Puzzle02.input")
                  printfn "Puzzle02b: %A" puzzle02bResult
                  let puzzle03aResult = Solutions.Puzzle03a.readFileAndSolve("./src/Solutions/Puzzle03.input")
                  printfn "Puzzle03a: %A" puzzle03aResult
                  let puzzle03bResult = Solutions.Puzzle03b.readFileAndSolve("./src/Solutions/Puzzle03.input")
                  printfn "Puzzle03b: %A" puzzle03bResult
                  let puzzle04aResult = Solutions.Puzzle04.readFileAndSolveA("./src/Solutions/Puzzle04.input")
                  printfn "Puzzle04a: %A" puzzle04aResult
                  let puzzle04bResult = Solutions.Puzzle04.readFileAndSolveB("./src/Solutions/Puzzle04.input")
                  printfn "Puzzle04b: %A" puzzle04bResult
                  0
