namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle05Test () =
    [<Test>]
    member this.TestA () =
        let input = "dabAcCaCBAcCcaDA"
        let result = Solutions.Puzzle05.solveA(input)
        Assert.AreEqual(10, result)

    [<Test>]
    member this.TestA_2 () =
        let input = "caAbd"
        let result = Solutions.Puzzle05.solveA(input)
        Assert.AreEqual(3, result)

    [<Test>]
    member this.TestB () =
        let input = "dabAcCaCBAcCcaDA"
        let result = Solutions.Puzzle05.solveB(input)
        Assert.AreEqual(4, result)
