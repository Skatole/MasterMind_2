namespace MasterMind_Project_2
{
    internal class HintPin : Pin
    {


        // you migh need to use new keyword here because of inheritance
        // if you want to change the color it will need a new Color property
        public HintPin() : base()
        {
        }

        public HintPin(PinColor c) : base(c)
        {
        }

    }
}