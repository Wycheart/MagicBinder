using Microsoft.AspNetCore.Components;

namespace MagicBinder.Frontend.Pages
{

    public partial class Collections : ComponentBase
    {

        protected int currentCount = 0;

        protected void IncrementCount()
        {
            currentCount++;
        }


    }

}
