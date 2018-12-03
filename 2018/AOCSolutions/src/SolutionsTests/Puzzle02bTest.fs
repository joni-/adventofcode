namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle02bTest () =
    [<Test>]
    member this.Test1 () =
        let input = "abcde\n\
                     fghij\n\
                     klmno\n\
                     pqrst\n\
                     fguij\n\
                     axcye\n\
                     wvxyz"
        Assert.AreEqual("fgij", Solutions.Puzzle02b.solve(input))
