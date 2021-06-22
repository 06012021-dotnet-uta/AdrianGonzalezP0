
namespace EcommerceBusinessLayer
{
    struct UserInput
    {
        string userInput;
        sbyte outResult;
        bool isValid;

        public UserInput(string userInput, sbyte outResult, bool isValid)
        {
            this.userInput = userInput;
            this.outResult = outResult;
            this.isValid = isValid;
        }
    }
}
