namespace Tests

open NUnit.Framework
open Solutions
open Solutions.Puzzle10

[<TestClass>]
type Puzzle10Test () =
    [<Test>]
    member this.TestParsePoint1 () =
        let input = "position=< 9,  1> velocity=< 0,  2>"
        let result = Solutions.Puzzle10.parsePoint(input)
        let expectedPoint = Point(Coordinate(9, 1), Velocity(0, 2))
        Assert.AreEqual(expectedPoint.Coordinate, result.Coordinate)
        Assert.AreEqual(expectedPoint.Velocity, result.Velocity)

    [<Test>]
    member this.TestParsePoint2 () =
        let input = "position=<19,  11> velocity=<10, 12>"
        let result = Solutions.Puzzle10.parsePoint(input)
        let expectedPoint = Point(Coordinate(19, 11), Velocity(10, 12))
        Assert.AreEqual(expectedPoint.Coordinate, result.Coordinate)
        Assert.AreEqual(expectedPoint.Velocity, result.Velocity)

    [<Test>]
    member this.TestParsePoint3 () =
        let input = "position=<-9, -1> velocity=<-1, -2>"
        let result = Solutions.Puzzle10.parsePoint(input)
        let expectedPoint = Point(Coordinate(-9, -1), Velocity(-1, -2))
        Assert.AreEqual(expectedPoint.Coordinate, result.Coordinate)
        Assert.AreEqual(expectedPoint.Velocity, result.Velocity)

    [<Test>]
    member this.TestTopLeft () =
        let input = [Coordinate(-9, -1); Coordinate(1, 3); Coordinate(4, -4)]
        let result = Solutions.Puzzle10.topLeft(input)
        let expected = Coordinate(-9, -4)
        Assert.AreEqual(expected, result)

    [<Test>]
    member this.TestBottomRight () =
        let input = [Coordinate(-9, -1); Coordinate(1, 3); Coordinate(4, -4)]
        let result = Solutions.Puzzle10.bottomRight(input)
        let expected = Coordinate(4, 3)
        Assert.AreEqual(expected, result)

    [<Test>]
    member this.Step1 () =
        let input = Point(Coordinate(1, 1), Velocity(1, 1))
        let result = Solutions.Puzzle10.step 1 input
        let expectedPoint = Point(Coordinate(2, 2), Velocity(1, 1))
        Assert.AreEqual(expectedPoint.Coordinate, result.Coordinate)
        Assert.AreEqual(expectedPoint.Velocity, result.Velocity)

    [<Test>]
    member this.Step2 () =
        let input = Point(Coordinate(1, 1), Velocity(-2, -1))
        let result = Solutions.Puzzle10.step 1 input
        let expectedPoint = Point(Coordinate(-1, 0), Velocity(-2, -1))
        Assert.AreEqual(expectedPoint.Coordinate, result.Coordinate)
        Assert.AreEqual(expectedPoint.Velocity, result.Velocity)

    [<Test>]
    member this.Step3 () =
        let input = Point(Coordinate(1, 1), Velocity(1, 1))
        let result = Solutions.Puzzle10.step 2 input
        let expectedPoint = Point(Coordinate(3, 3), Velocity(1, 1))
        Assert.AreEqual(expectedPoint.Coordinate, result.Coordinate)
        Assert.AreEqual(expectedPoint.Velocity, result.Velocity)
