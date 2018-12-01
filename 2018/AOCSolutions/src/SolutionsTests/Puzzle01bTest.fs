namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle01bTest () =
    [<Test>]
    member this.Test1 () =
        Assert.AreEqual(0, Solutions.Puzzle01b.solve("+1\n-1"))
        Assert.AreEqual(10, Solutions.Puzzle01b.solve("+3\n+3\n+4\n-2\n-4"))
        Assert.AreEqual(5, Solutions.Puzzle01b.solve("-6\n+3\n+8\n+5\n-6"))
        Assert.AreEqual(14, Solutions.Puzzle01b.solve("+7\n+7\n-2\n-7\n-4"))
