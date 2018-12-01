namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle01aTest () =
    [<Test>]
    member this.Test1 () =
        Assert.AreEqual(3, Solutions.Puzzle01a.solve("+1\n+1\n+1"))
        Assert.AreEqual(0, Solutions.Puzzle01a.solve("+1\n+1\n-2"))
        Assert.AreEqual(-6, Solutions.Puzzle01a.solve("-1\n-2\n-3"))
