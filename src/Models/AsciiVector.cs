namespace Orikivo.Ascii
{
    /// <summary>
    /// The vector used for an <see cref="AsciiObject"/> that contains its initial velocity and acceleration values.
    /// </summary>
    public class AsciiVector
    {
        public static AsciiVector Zero = new AsciiVector(0f, 0f, 0f, 0f);

        /// <summary>
        /// Creates a new <see cref="AsciiVector"/> with the specified velocity and acceleration values in both the X and Y direction.
        /// </summary>
        public AsciiVector(float vX, float vY, float aX, float aY)
        {
            VX = vX;
            VY = vY;
            AX = aX;
            AY = aY;
        }

        /// <summary>
        /// Creates a new <see cref="AsciiVector"/> with the specified velocity and angle.
        /// </summary>
        public static AsciiVector Velocity(float velocity, float angle)
            => new AsciiVector(Utils.GetAngledVectorX(velocity, angle), Utils.GetAngledVectorY(velocity, angle), 0f, 0f);

        /// <summary>
        /// Creates a new <see cref="AsciiVector"/> with the specified acceleration and angle.
        /// </summary>
        public static AsciiVector Acceleration(float acceleration, float angle)
            => new AsciiVector(0f, 0f, Utils.GetAngledVectorX(acceleration, angle), Utils.GetAngledVectorY(acceleration, angle));

        /// <summary>
        /// Creates a new <see cref="AsciiVector"/> with the specified velocity, acceleration, and their corresponding angles.
        /// </summary>
        public static AsciiVector FromAngle(float velocity, float acceleration, float velocityAngle, float accelerationAngle)
            => new AsciiVector(Utils.GetAngledVectorX(velocity, velocityAngle), Utils.GetAngledVectorY(velocity, velocityAngle),
                Utils.GetAngledVectorX(acceleration, accelerationAngle), Utils.GetAngledVectorY(acceleration, accelerationAngle));
        
        /// <summary>
        /// The initial velocity for the X vector.
        /// </summary>
        public float VX { get; }
        
        /// <summary>
        /// The initial acceleration for the X vector.
        /// </summary>
        public float AX { get; }

        /// <summary>
        /// The initial velocity for the Y vector.
        /// </summary>
        public float VY { get; }
        
        /// <summary>
        /// The initial acceleration for the Y vector.
        /// </summary>
        public float AY { get; }
    }
}
