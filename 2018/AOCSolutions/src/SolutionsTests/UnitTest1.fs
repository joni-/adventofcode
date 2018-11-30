namespace Tests

open NUnit.Framework
open Solutions

[<TestClass>]
type TestClass () =
    [<Test>]
    member this.Test1 () =
        Assert.AreEqual("Hello, World", Solutions.Say.hello("World"))
