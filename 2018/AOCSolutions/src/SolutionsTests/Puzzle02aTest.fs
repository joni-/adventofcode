namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type Puzzle02aTest () =
    [<Test>]
    member this.TestContainsTwo () =
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterTwice("abcdef"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterTwice("bababc"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterTwice("abbcde"))
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterTwice("abcccd"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterTwice("aabcdd"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterTwice("abcdee"))
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterTwice("ababab"))

    [<Test>]
    member this.TestContainsThree () =
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterThreeTimes("abcdef"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterThreeTimes("bababc"))
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterThreeTimes("abbcde"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterThreeTimes("abcccd"))
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterThreeTimes("aabcdd"))
      Assert.IsFalse(Solutions.Puzzle02a.containsLetterThreeTimes("abcdee"))
      Assert.IsTrue(Solutions.Puzzle02a.containsLetterThreeTimes("ababab"))

    [<Test>]
    member this.Test1 () =
        let input = "abcdef\n\
                     bababc\n\
                     abbcde\n\
                     abcccd\n\
                     aabcdd\n\
                     abcdee\n\
                     ababab"
        Assert.AreEqual(4 * 3, Solutions.Puzzle02a.solve(input))
