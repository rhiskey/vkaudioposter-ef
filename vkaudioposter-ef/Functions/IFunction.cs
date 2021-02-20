using System;
using System.Collections.Generic;
using System.Text;

namespace vkaudioposter_ef.Functions
{
    interface IFunction
    {
        public void CreateFunction(bool isFirstLaunch);
        public void TestFunction();
    }
}
