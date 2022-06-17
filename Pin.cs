public class Pin
{

    internal PinColor _color;
    internal string _shape = "";

    public Pin ( PinColor color, string shape) 
    {
        this._color = color;
        this._shape = shape;
    }

    public PinColor color { get; set; }
    public string shape { get; set; }


}