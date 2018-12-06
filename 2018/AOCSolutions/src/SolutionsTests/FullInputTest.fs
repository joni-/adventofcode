namespace Tests

open NUnit.Framework
open Solutions
open System
open System.IO


[<TestClass>]
type FullInputTest () =
    let fullPath filename = sprintf "./%s" filename
    let readInput filename = File.ReadAllText(filename |> fullPath)

    [<Test>]
    member this.Puzzle01a () =
        printfn "AAA %s" Environment.CurrentDirectory
        let input = "Puzzle01.input" |> readInput
        Assert.AreEqual(474, Solutions.Puzzle01a.solve(input))

    [<Test>]
    member this.Puzzle01b () =
        let input = "Puzzle01.input" |> readInput
        Assert.AreEqual(137041, Solutions.Puzzle01b.solve(input))

    [<Test>]
    member this.Puzzle02a () =
        let input = "Puzzle02.input" |> readInput
        Assert.AreEqual(5727, Solutions.Puzzle02a.solve(input))

    [<Test>]
    member this.Puzzle02b () =
        let input = "Puzzle02.input" |> readInput
        Assert.AreEqual("uwfmdjxyxlbgnrotcfpvswaqh", Solutions.Puzzle02b.solve(input))

    [<Test>]
    member this.Puzzle03a () =
        let input = "Puzzle03.input" |> readInput
        Assert.AreEqual(113576, Solutions.Puzzle03a.solve(input))

    [<Test>]
    member this.Puzzle03b () =
        let input = "Puzzle03.input" |> readInput

        // Should be just 825
        Assert.AreEqual("#825 @ 689,535: 23x27", Solutions.Puzzle03b.solve(input))

    [<Test>]
    member this.Puzzle04a () =
        let input = "Puzzle04.input" |> readInput

        // Should be just 825
        Assert.AreEqual(26281, Solutions.Puzzle04.solveA(input))

    [<Test>]
    member this.Puzzle04b () =
        let input = "Puzzle04.input" |> readInput

        // Should be just 825
        Assert.AreEqual(73001, Solutions.Puzzle04.solveB(input))
