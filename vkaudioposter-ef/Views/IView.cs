using System;
using System.Collections.Generic;
using System.Text;

namespace vkaudioposter_ef.Views
{
    interface IView
    {
        public void CreateView(bool isFirstLaunch);
        public void TestView();
    }
}
