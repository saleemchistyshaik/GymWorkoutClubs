A GUID (Globally Unique Identifier) is a 128-bit unique identifier used in the code to uniquely identify classes and bookings. In C#, it's represented by the Guid type.
In our gym workout club ptoject, GUIDs are used for:

Class Identification:

// In GymClass.cs
public Guid Id { get; set; } = Guid.NewGuid();
Booking Identification:

// In Booking.cs
public Guid Id { get; set; } = Guid.NewGuid();

Track relationships between bookings and classes
Ensure each entity has a unique identifier
Avoid ID conflicts when adding new records
