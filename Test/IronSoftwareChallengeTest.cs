namespace IronSoftwareTest;

using IronSoftwareChallenge;

[TestClass]
public sealed class IronSoftwareChallengeTest
{
    [TestMethod]
    // Should throw ArgumentException when input does not end with #
    public void ConvertInput_Throws_Invalid_Input_Error()
    {
        string input = "2";
        OldPhonePad opp = new (input);
        Assert.ThrowsException<ArgumentException>(opp.ConvertInput);
    }

    [TestMethod]
    // Test that the private BuildInputParts function correctly splits up 
    // the input into the indivual chars that they represent
    public void ConvertInput_Splits_Input_Into_Output_Chars()
    {
        string input = "2 3344 4*6 66111#99 9 98#";
        OldPhonePad opp = new(input);
        opp.ConvertInput();
        string[] actual = opp.inputParts;
        string[] expected = ["2", "33", "44", "4", "*", "6", "66", "111", "#", "99", "9", "9", "8"];
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    // Test that the inputParts array is correctly mapped to the chars they represent 
    // thus verifying the output will be correct
    public void ConvertInput_Converts_inputParts_Into_Correct_Output()
    {
        string input = "4433555 555666096667775553#";
        OldPhonePad opp = new(input);
        string actual = opp.ConvertInput();
        string expected = "hello world";
        Assert.AreEqual(expected, actual);
    }
}
