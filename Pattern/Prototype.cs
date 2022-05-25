namespace DesignPattern.Pattern
{
    public abstract class Proto
    {
        public string Name { get;}
        public string Description { get; }

        public Proto( string name, string description)
        {
            Name = name;    
            Description = description;
        }

        public abstract Proto Clone();
    }

    public class ConcreateProto : Proto
    {
        public ConcreateProto(string name, string description):base(name, description)
        {
        }

        public override Proto Clone()
        {
            return (Proto)this.MemberwiseClone();
        }
    }
    internal class Prototype
    {
        public Prototype()
        {
            ConcreateProto c1 = new ConcreateProto("anish", "free thinker");
            ConcreateProto c2 = (ConcreateProto)c1.Clone();
            Console.WriteLine($"{c2.Name},{c2.Description}");
        }
    }
}

/*
//Copy Constructor
public Student(Student student)
{
	this.name = student.name;
	this.rollNo = student.rollNo;
}

Student student1 = new Student(1, "John");
Student student2 = new Student(student1);
 */
