using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Bloodbank.Ui
{
    public class BloodbankUi
    {
        private Color _baseColor = Color.Cyan;
        public async Task InitializeUi()
        {
            Console.WriteLine("Hello New Person.", _baseColor);



            await Task.Delay(-1);
        }
    }
}
