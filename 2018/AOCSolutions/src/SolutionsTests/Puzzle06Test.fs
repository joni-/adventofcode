namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle06Test () =
    [<Test>]
    member this.TopLeft () =
        let coordinates = [(1, 1); (0, 2); (2, 1); (2, 2)]
        Assert.AreEqual((0, 1), Solutions.Puzzle06.topLeft(coordinates))

    [<Test>]
    member this.BottomRight () =
        let coordinates = [(1, 1); (1, 4); (2, 1); (2, 2)]
        Assert.AreEqual((2, 4), Solutions.Puzzle06.bottomRight(coordinates))

    [<Test>]
    member this.Distance () =
        Assert.AreEqual(2, Solutions.Puzzle06.distance (0, 0) (1, 1))
        Assert.AreEqual(1, Solutions.Puzzle06.distance (0, 0) (0, 1))
        Assert.AreEqual(4, Solutions.Puzzle06.distance (1, 1) (3, 3))

    [<Test>]
    member this.TestA () =
        let input = "1, 1
1, 6
8, 3
3, 4
5, 5
8, 9"
        let result = Solutions.Puzzle06.solveA(input)
        Assert.AreEqual(17, result)
