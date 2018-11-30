// Learn more about F# at http://fsharp.org
namespace Solutions.App

open System
open Solutions

module Program = let [<EntryPoint>] main _ =
                  let output = Solutions.Say.hello("World from F#!")
                  printfn (Printf.TextWriterFormat<_> output)
                  0
