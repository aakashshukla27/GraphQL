using Bogus;

namespace GraphQL.API.Schema
{
    public class Query
    {
        [GraphQLDeprecated("This query is deprecated")]
        public string Instructions => "Some Message";

        public IEnumerable<CourseType> GetCourses()
        {
            var instructorFaker = new Faker<InstructorType>()
                .RuleFor(x => x.Id, y => Guid.NewGuid())
                .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                .RuleFor(x => x.LastName, y => y.Name.LastName())
                .RuleFor(x => x.Salary, y => y.Random.Double(0, 100000));

            var studentFaker = new Faker<StudentType>()
                .RuleFor(x => x.Id, y => Guid.NewGuid())
                .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                .RuleFor(x => x.LastName, y => y.Name.LastName())
                .RuleFor(x => x.GPA, f => f.Random.Double(1, 4));

            var courseFaker = new Faker<CourseType>()
                .RuleFor(x => x.Id, y => Guid.NewGuid())
                .RuleFor(x => x.Name, y => y.Name.JobTitle())
                .RuleFor(x => x.Subject, y => y.PickRandom<Subject>())
                .RuleFor(x => x.Instructor, y => instructorFaker.Generate())
                .RuleFor(x => x.Students, y => studentFaker.Generate(3));
            var courses = courseFaker.Generate(5);
            return courses;
        }
    }
}
