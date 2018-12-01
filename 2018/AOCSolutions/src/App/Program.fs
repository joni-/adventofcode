// Learn more about F# at http://fsharp.org
namespace Solutions.App

open System
open Solutions

module Program = let [<EntryPoint>] main _ =
                  let puzzle01aResult = Solutions.Puzzle01a.readFileAndSolve("./src/Solutions/Puzzle01.input")
                  printfn "Puzzle01a: %d" puzzle01aResult
                  let puzzle01bResult = Solutions.Puzzle01b.readFileAndSolve("./src/Solutions/Puzzle01.input")
                  printfn "Puzzle01a: %d" puzzle01bResult
                  0
