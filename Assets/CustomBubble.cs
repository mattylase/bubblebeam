namespace Bubblebeam
{
    /**
      A CustomBubble allows the user to create their own event
     */
    public abstract class CustomBubble  
    {

      /**
      ShouldPop should return true when listeners should be made aware of the event taking place
      */
		public abstract bool ShouldPop();
    
    }

}