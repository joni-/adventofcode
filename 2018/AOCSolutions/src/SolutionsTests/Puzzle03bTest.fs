namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle03bTest () =
    [<Test>]
    member this.Test1 () =
        let input = "#1 @ 1,3: 4x4
                     #2 @ 3,1: 4x4
                     #3 @ 5,5: 2x2"
        let result = Solutions.Puzzle03b.solve(input)
        Assert.AreEqual("#3 @ 5,5: 2x2", result)
