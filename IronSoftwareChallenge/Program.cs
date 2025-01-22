using IronSoftwareChallenge;

Console.WriteLine("Please enter the message you would like to convert. Messages must end with a # symbol.\n");
string? oldPhoneInput = Console.ReadLine();

if (oldPhoneInput == null || oldPhoneInput.Length == 0) {
    Console.WriteLine("No message entered");
    throw new ArgumentException("Invalid input. No message entered.");
}

OldPhonePad oldPhonePad = new(oldPhoneInput);
string output = oldPhonePad.ConvertInput();

Console.WriteLine("The converted message is: {0}", output);

Environment.Exit(-1);
