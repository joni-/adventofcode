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

                  0
