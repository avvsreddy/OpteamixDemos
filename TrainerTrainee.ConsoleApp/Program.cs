namespace TrainerTrainee.ConsoleApp
{
    internal class Program
    {
        
        //Training training = new Training(); //Has-A
        
        static void Main(string[] args)
        {

            Trainer trainer = new Trainer();


            Training training = new Training(); // Uses

            training.Trainer = trainer;

            Organization org = new Organization();
            org.Name = "ABC Company";

            trainer.TheOrganization = org;

            string orgName = training.GetOrganizationName();
            Console.WriteLine(orgName);


            Trainee t1 = new Trainee();
            Trainee t2 = new();
            Trainee t3 = new();
            Trainee t4 = new();
            Trainee t5 = new();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);
            training.Trainees.Add(t4); 
            training.Trainees.Add(t5);

            int participantsCount = training.GetTraineesCount();
            Console.WriteLine($"Trainees count : {participantsCount}");

            Course course = new Course();
            training.Course = course;

            Module m1 = new Module();
            Module m2 = new Module();
            course.Modules.Add(m1);
            course.Modules.Add(m2);

            Unit u1 = new Unit { Duration = 20 };
            Unit u2 = new Unit { Duration = 30 };

            m1.Units.Add(u1);
            m2.Units.Add(u2);

            int duration = training.GetTrainingDuration();
            Console.WriteLine($"Duration : {duration}");

        }
    }

    public class Trainer
    {
        //private Organization organization = new Organization();
        public Organization TheOrganization { get; set; } // has org

        // has many trinees
        //private List<Trainee> traines = new List<Trainee>();

        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        public List<Training> Trainings { get; set; } = new List<Training>();

    }

    public class Trainee
    {
        public Trainer Trainer { get; set; } // has trainer
        public List<Training> Trainings { get; set; } = new List<Training>(); // has many trainings
    }

    public class Organization
    {
        public string Name { get; set; }
    }

    public class Training
    {
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Trainer Trainer { get; set; }

        public Course Course  { get; set; }

        public string GetOrganizationName()
        {
            // return org name
            return Trainer.TheOrganization.Name;
        }

        public int GetTraineesCount()
        {
            return Trainees.Count;
        }

        public int GetTrainingDuration()
        {
            int totDuration = 0;
            // for each module in a course
            foreach (var module in Course.Modules)
            {
                // for each unit in a module
                foreach(var unit  in module.Units) 
                {
                    totDuration += unit.Duration;
                }
            }
            return totDuration;
        }
    }

    public class Course
    {
        public List<Module> Modules { get; set; } = new List<Module>();
    }

    public class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }

    public class Unit
    {
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public int Duration { get; set; }
    }

    public class Topic
    {

    }
}
