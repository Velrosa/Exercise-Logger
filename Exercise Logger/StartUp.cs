using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class StartUp
    {
        UserInput _userInput;
        public StartUp(UserInput userInput)
        {
            _userInput = userInput;
        }

        public async Task Run()
        {
            await _userInput.MainMenu();
        }
    }
}
