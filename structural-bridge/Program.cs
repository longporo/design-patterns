using System;

namespace strutural_bridge
{
    /// <summary>
    /// Bridge Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Eye eye = new LeftEye();
            // Set implementation and call
            eye.SetEyeStyle = new EyeStyleA();
            eye.Wink();
            // Change implementation and call
            eye.SetEyeStyle = new EyeStyleB();
            eye.Wink();
        }
    }

    /// <summary>
    /// The Eye class is a part of a face emotion, it is able to wink in different eye styles
    /// </summary>
    public class Eye
    {
        protected EyeStyle eyeStyle;

        public EyeStyle SetEyeStyle
        {
            set { eyeStyle = value; }
        }

        public virtual void Wink()
        {
            eyeStyle.Wink();
        }
    }

    /// <summary>
    /// The EyeStyle abstract class define the Wink method
    /// </summary>
    public abstract class EyeStyle
    {
        public abstract void Wink();
    }

    /// <summary>
    /// The LeftEye class
    /// </summary>
    public class LeftEye : Eye
    {
        public override void Wink()
        {
            eyeStyle.Wink();
        }
    }

    /// <summary>
    /// The concrete EyeStyleA class defines the concrete Wink method
    /// </summary>
    public class EyeStyleA : EyeStyle
    {
        public override void Wink()
        {
            Console.WriteLine("Eye winks in Style A");
        }
    }

    /// <summary>
    /// The concrete EyeStyleB class defines the concrete Wink method
    /// </summary>
    public class EyeStyleB : EyeStyle
    {
        public override void Wink()
        {
            Console.WriteLine("Eye winks in Style B");
        }
    }
}