namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle03aTest () =
    [<Test>]
    member this.TestSingleClaim () =
      let claim = "#1 @ 0,0: 1x1"
      let result = Solutions.Puzzle03a.parseSingleClaim(claim)
      Assert.IsTrue(Seq.contains (0,0) result)

    [<Test>]
    member this.TestSingleClaim2 () =
      let claim = "#1 @ 1,1: 1x2"
      let result = Solutions.Puzzle03a.parseSingleClaim(claim)
      Assert.IsTrue(Seq.contains (1, 1) result)
      Assert.IsTrue(Seq.contains (1, 2) result)

    [<Test>]
    member this.TestSingleClaim3 () =
      let claim = "#1 @ 1,1: 2x2"
      let result = Solutions.Puzzle03a.parseSingleClaim(claim)
      Assert.IsTrue(Seq.contains (1, 1) result)
      Assert.IsTrue(Seq.contains (1, 2) result)
      Assert.IsTrue(Seq.contains (1, 2) result)
      Assert.IsTrue(Seq.contains (2, 2) result)

    [<Test>]
    member this.Test1 () =
        let input = "#1 @ 1,3: 4x4
                     #2 @ 3,1: 4x4
                     #3 @ 5,5: 2x2"
        let result = Solutions.Puzzle03a.solve(input)
        Assert.AreEqual(4, result)
